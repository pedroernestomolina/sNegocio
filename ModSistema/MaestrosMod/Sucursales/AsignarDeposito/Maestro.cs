using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.AsignarDeposito
{
    
    public class Maestro: IAsignarDeposito
    {

        private IAsignarDepositoLista _gLista;
        private AgregarEditar.IEditar _gEditar;
        private bool _eliminarIsOk;


        public string Titulo { get { return "SUCURSALES - Depósito Principal Asignado"; } }
        public BindingSource Source { get { return _gLista.Source; } }
        public int CntItems { get { return _gLista.CntItems; } }


        public Maestro(IAsignarDepositoLista lista, 
            AgregarEditar.IEditar editar)
        {
            _gLista = lista;
            _gEditar = editar;
            _eliminarIsOk = false;
        }


        public void Inicializa()
        {
            _gLista.Inicializa();
            _gEditar.Inicializa();
            _eliminarIsOk=false;
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
                    mSucDeposito= rg.nombreDepositoPrincipal,
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


        public bool AgregarIsOk { get { return false; } }
        public void AgregarItem()
        {
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
            var r00 = Sistema.MyData.Permiso_AsignarDepositoSucursal_EditarAsignacion(Sistema.UsuarioP.autoGrupo);
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
                        mSucDeposito = rg.nombreDepositoPrincipal,
                    };
                    _gLista.Actualizar(_dataAgregarEditar);
                }
            }
        }

        public bool EliminarItemIsOk { get { return _eliminarIsOk; } }
        public void EliminarItem()
        {
            if (_gLista.ItemActual != null)
            {
                EliminarItem(_gLista.ItemActual);
            }
        }
        public void EliminarItem(data ItemActual)
        {
            var r00 = Sistema.MyData.Permiso_AsignarDepositoSucursal_EliminarAsignacion(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var r01 = Sistema.MyData.Sucursal_GetFicha(ItemActual.auto);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                if (r01.Entidad.autoDepositoPrincipal == "")
                {
                    Helpers.Msg.Error("SUCURSAL ACTUAL, NO POSEE NINGÚN DEPOSITO ASIGNADO");
                    return;
                }
                _eliminarIsOk = false;
                var xmsg = "Eliminar Asignación ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var r02 = Sistema.MyData.Sucursal_QuitarDepositoPrincipal(ItemActual.auto);
                    if (r02.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return;
                    }
                    ItemActual.mSucDeposito = "";
                    Helpers.Msg.EditarOk();
                }
            }
        }

    }

}