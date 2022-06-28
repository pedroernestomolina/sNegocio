using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Deposito
{
    
    public class Maestro: IDeposito
    {

        private IDepositoLista _gLista;
        private Deposito.AgregarEditar.IAgregar _gAgregar;
        private Deposito.AgregarEditar.IEditar _gEditar;
        private bool _activarInactivarIsOk;


        public string Titulo { get { return "Maestro: DEPOSITOS"; } }
        public BindingSource Source { get { return _gLista.Source; } }
        public int CntItems { get { return _gLista.CntItems; } }


        public Maestro(IDepositoLista lista, 
            Deposito.AgregarEditar.IAgregar agregar, 
            Deposito.AgregarEditar.IEditar editar)
        {
            _gLista = lista;
            _gAgregar = agregar;
            _gEditar = editar;
            _activarInactivarIsOk = false;
        }


        public void Inicializa()
        {
            _gLista.Inicializa();
            _gAgregar.Inicializa();
            _gEditar.Inicializa();
            _activarInactivarIsOk = false;
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

        public bool CargarData()
        {
            var filtroOOB = new OOB.LibSistema.Deposito.Lista.Filtro();
            var r01 = Sistema.MyData.Deposito_GetLista (filtroOOB);
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
                };
                _lst.Add(nr);
            }
            _gLista.setLista(_lst);

            return true;
        }


        public bool AgregarIsOk { get { return _gAgregar.IsOk; } }
        public void AgregarItem()
        {
            _gAgregar.Inicializa();

            var r00 = Sistema.MyData.Permiso_ControlDeposito_Agregar(Sistema.UsuarioP.autoGrupo);
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
                    var r01 = Sistema.MyData.Deposito_GetFicha(id);
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

            var r00 = Sistema.MyData.Permiso_ControlDeposito_Editar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                if (!ItemActual.esActivo) 
                {
                    Helpers.Msg.Error("DEPOSITO EN ESTADO INACTIVO");
                    return;
                }
                var _idEditar = ItemActual.auto;
                _gEditar.setIdItemEditar(_idEditar);
                _gEditar.Inicia();
                if (_gEditar.IsOk)
                {
                    var r01 = Sistema.MyData.Deposito_GetFicha(_idEditar);
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

            var r00 = Sistema.MyData.Permiso_ControlDeposito_ActivarInactivar(Sistema.UsuarioP.autoGrupo);
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
                        var r01 = Sistema.MyData.Deposito_Inactivar(ItemActual.auto);
                        if (r01.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r01.Mensaje);
                            return;
                        }
                        _activarInactivarIsOk = true;
                        ItemActual.setInactivar();
                        Helpers.Msg.OK("DEPOSITO HA CAMBIADO DE ESTATUS A : INACTIVA");
                    }
                }
                else
                {
                    var xmsg = "Activar Ficha ?";
                    var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.Yes)
                    {
                        var r01 = Sistema.MyData.Deposito_Activar(ItemActual.auto);
                        if (r01.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r01.Mensaje);
                            return;
                        }
                        _activarInactivarIsOk = true;
                        ItemActual.setActivar();
                        Helpers.Msg.OK("DEPOSITO HA CAMBIADO DE ESTATUS A : ACTIVA");
                    }
                }
            }
        }

    }

}