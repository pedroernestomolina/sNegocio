using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Sucursal
{
    
    public class Maestro: ISucursal
    {

        private ISucursalLista _gLista;
        private AgregarEditar.IAgregar _gAgregar;
        private AgregarEditar.IEditar _gEditar;
        private Helpers.Lista.ILista _gListaDep;
        private bool _activarInactivarIsOk;


        public string Titulo{ get { return "Maestro: SUCURSALES"; } }
        public BindingSource Source { get { return _gLista.Source; } }
        public int CntItems { get { return _gLista.CntItems; } }


        public Maestro(
            ISucursalLista lista,
            AgregarEditar.IAgregar agregar, 
            AgregarEditar.IEditar editar,
            Helpers.Lista.ILista listDep)
        {
            _gLista = lista;
            _gAgregar = agregar;
            _gEditar = editar;
            _gListaDep = listDep;
            _activarInactivarIsOk = false;
        }


        public void Inicializa()
        {
            _gLista.Inicializa();
            _gAgregar.Inicializa();
            _gEditar.Inicializa();
            _gListaDep.Inicializa();
            _activarInactivarIsOk = false;
        }

        public bool CargarData()
        {
            var filtroOOB = new OOB.LibSistema.Sucursal.Lista.Filtro();
            var r01 = Sistema.MyData.Sucursal_GetLista(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var _lst = new List<data>();
            foreach (var rg in r01.Lista.OrderBy(o=>o.nombre).ToList())
            {
                var nr = new data()
                {
                    auto = rg.auto.ToString(),
                    codigo = rg.codigo,
                    descripcion = rg.nombre,
                    esActivo = rg.esActivo,
                    mSucGrupo = rg.nombreGrupo,
                    mSucFactMayor = rg.activarFactMayor,
                    mSucFactCredito = rg.activarVentaCredito,
                };
                _lst.Add(nr);
            }
            _gLista.setLista(_lst);

            return true;
        }
        MaestroFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new MaestroFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public bool AgregarIsOk { get { return _gAgregar.IsOk; } }
        public void AgregarItem()
        {
            _gAgregar.Inicializa();

            var r00 = Sistema.MyData.Permiso_ControlSucursal_Agregar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gAgregar.Inicia();
                if (_gAgregar.IsOk)
                {
                    var id = (string)_gAgregar.IdItemRegistrado;
                    var r01 = Sistema.MyData.Sucursal_GetFicha(id);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    var rg = r01.Entidad;
                    var _dataAgregarEditar = new data()
                    {
                        auto = rg.auto.ToString(),
                        codigo = rg.codigo,
                        descripcion = rg.nombre,
                        esActivo = rg.esActivo,
                        mSucGrupo = rg.nombreGrupo,
                        mSucFactMayor = rg.activarFactMayor,
                        mSucFactCredito = rg.activarVentaCredito,
                    };
                    _gLista.Agregar(_dataAgregarEditar);
                }
            }
        }

        public bool EditarIsOk { get { return _gEditar.IsOk; } }
        public void EditarItem()
        {
            if (_gLista.ItemActual != null)
            {
                EditarItem(_gLista.ItemActual);
            }
        }
        public void EditarItem(data ItemActual)
        {
            _gEditar.Inicializa();
            var r00 = Sistema.MyData.Permiso_ControlSucursal_Editar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                if (!ItemActual.esActivo) 
                {
                    Helpers.Msg.Error("SUCURSAL EN ESTADO INACTIVO");
                    return;
                }
                var _idEditar = ItemActual.auto;
                _gEditar.setIdItemEditar(_idEditar);
                _gEditar.Inicia();
                if (_gEditar.IsOk)
                {
                    var r01 = Sistema.MyData.Sucursal_GetFicha(_idEditar);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    var rg = r01.Entidad;
                    var _dataAgregarEditar = new data()
                    {
                        auto = rg.auto.ToString(),
                        codigo = rg.codigo,
                        descripcion = rg.nombre,
                        esActivo = rg.esActivo,
                        mSucGrupo = rg.nombreGrupo,
                        mSucFactMayor = rg.activarFactMayor,
                        mSucFactCredito = rg.activarVentaCredito,
                    };
                    _gLista.Actualizar(_dataAgregarEditar);
                }
            }
        }

        public bool ActivarInactivarIsOk { get { return _activarInactivarIsOk; } }
        public void ActivarInactivar()
        {
            if (_gLista.ItemActual != null)
            {
                ActivarInactivar(_gLista.ItemActual);
            }
        }
        public void ActivarInactivar(data ItemActual)
        {
            _activarInactivarIsOk = false;
            var r00 = Sistema.MyData.Permiso_ControlSucursal_ActivarInactivar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                if (ItemActual.esActivo)
                {
                    var xmsg = "Inactivar Ficha ?";
                    var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.Yes)
                    {
                        var r01 = Sistema.MyData.Sucursal_Inactivar(ItemActual.auto);
                        if (r01.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r01.Mensaje);
                            return;
                        }
                        _activarInactivarIsOk = true;
                        ItemActual.setInactivar();
                        Helpers.Msg.OK("SUCURSAL HA CAMBIADO DE ESTATUS A : INACTIVA");
                    }
                }
                else 
                {
                    var xmsg = "Activar Ficha ?";
                    var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.Yes)
                    {
                        var r01 = Sistema.MyData.Sucursal_Activar(ItemActual.auto);
                        if (r01.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r01.Mensaje);
                            return;
                        }
                        _activarInactivarIsOk = true;
                        ItemActual.setActivar();
                        Helpers.Msg.OK("SUCURSAL HA CAMBIADO DE ESTATUS A : ACTIVA");
                    }
                }
            }
        }


        public void Funcion_Depositos()
        {
            if (_gLista.ItemActual != null)
            {
                Funcion_Depositos(_gLista.ItemActual);
            }
        }
        public void Funcion_Depositos(data ItemActual)
        {
            var filtroOOB = new OOB.LibSistema.Deposito.Lista.Filtro() { sucCodigo = ItemActual.codigo };
            var r01 = Sistema.MyData.Deposito_GetLista(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var lst = new List<Helpers.Lista.data>();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                lst.Add(new Helpers.Lista.data() { codigo = rg.codigo, descripcion = rg.nombre, esActivo = true, id = rg.auto });
            }
            _gListaDep.Inicializa();
            _gListaDep.setTitulo("Lista de Depósitos");
            _gListaDep.setData(lst);
            _gListaDep.Inicia();
        }

    }

}