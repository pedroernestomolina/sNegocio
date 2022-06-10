using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Sucursal
{
    
    public class Maestro: ITipoMaestro
    {

        private List<data> _lst;
        private IAgregarEditar _gAgregar;
        private IAgregarEditar _gEditar;
        private Helpers.Lista.ILista _gListaDep;
        private data _dataAgregarEditar;
        private bool _activarInactivarIsOk;


        public string GetTitulo { get { return "Maestro: SUCURSALES"; } }
        public IEnumerable<data> Lista { get { return _lst; } }


        public Maestro(
            IAgregarEditar agregar, 
            IAgregarEditar editar,
            Helpers.Lista.ILista listDep)
        {
            _gAgregar = agregar;
            _gEditar = editar;
            _gListaDep = listDep;
            _lst = new List<data>();
            _dataAgregarEditar = null;
            _activarInactivarIsOk = false;
        }


        public void Inicializa()
        {
            _gAgregar.Inicializa();
            _gEditar.Inicializa();
            _gListaDep.Inicializa();
            _lst.Clear();
            _dataAgregarEditar = null;
            _activarInactivarIsOk = false;
        }

        public bool CargarData()
        {
            _lst.Clear();
            var filtroOOB = new OOB.LibSistema.Sucursal.Lista.Filtro();
            var r01 = Sistema.MyData.Sucursal_GetLista(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            foreach (var rg in r01.Lista)
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

            return true;
        }

        MaestroFrm frm;
        public void Inicia(IMaestro ctr)
        {
            if (frm == null)
            {
                frm = new MaestroFrm();
                frm.setControlador(ctr);
            }
            frm.ShowDialog();
        }


        public bool AgregarIsOk { get { return _gAgregar.IsOk; } }
        public data ItemAgregarEditar { get { return _dataAgregarEditar; } }
        public void AgregarItem()
        {
            _dataAgregarEditar = null;
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
                    _dataAgregarEditar = new data()
                    {
                        auto = rg.auto.ToString(),
                        codigo = rg.codigo,
                        descripcion = rg.nombre,
                        esActivo = rg.esActivo,
                        mSucGrupo = rg.nombreGrupo,
                        mSucFactMayor = rg.activarFactMayor,
                        mSucFactCredito = rg.activarVentaCredito,
                    };
                }
            }
        }

        public bool EditarIsOk { get { return _gEditar.IsOk; } }
        public void EditarItem(data ItemActual)
        {
            _dataAgregarEditar = null;
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
                    _dataAgregarEditar = new data()
                    {
                        auto = rg.auto.ToString(),
                        codigo = rg.codigo,
                        descripcion = rg.nombre,
                        esActivo = rg.esActivo,
                        mSucGrupo = rg.nombreGrupo,
                        mSucFactMayor = rg.activarFactMayor,
                        mSucFactCredito = rg.activarVentaCredito,
                    };
                }
            }
        }

        public bool EliminarItemIsOk { get { return false; } }
        public void EliminarItem(data ItemActual)
        {
        }


        public bool ActivarInactivarIsOk { get { return _activarInactivarIsOk; } }
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


        public void Funcion_Sucursales(data ItemActual)
        {
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