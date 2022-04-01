using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.AsignarDeposito
{
    
    public class Maestro: ITipoMaestro
    {

        private List<data> _lst;
        private IAgregarEditar _gEditar;
        private data _dataAgregarEditar;
        private bool _eliminarIsOk;


        public string GetTitulo { get { return "SUCURSALES - Depósito Principal Asignado"; } }
        public IEnumerable<data> Lista { get { return _lst; } }


        public Maestro(IAgregarEditar editar)
        {
            _gEditar = editar;
            _lst = new List<data>();
            _dataAgregarEditar = null;
            _eliminarIsOk = false;
        }


        public void Inicializa()
        {
            _gEditar.Inicializa();
            _lst.Clear();
            _dataAgregarEditar = null;
            _eliminarIsOk=false;
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
                    mSucDeposito= rg.nombreDepositoPrincipal,
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


        public bool AgregarIsOk { get { return false; } }
        public void AgregarItem()
        {
        }

        public data ItemAgregarEditar { get { return _dataAgregarEditar; } }
        public bool EditarIsOk { get { return _gEditar.IsOk; } }
        public void EditarItem(data ItemActual)
        {
            _dataAgregarEditar = null;
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
                    _dataAgregarEditar = new data()
                    {
                        auto = rg.auto.ToString(),
                        codigo = rg.codigo,
                        descripcion = rg.nombre,
                        esActivo = rg.esActivo,
                        mSucDeposito = rg.nombreDepositoPrincipal,
                    };
                }
            }
        }

        public bool EliminarItemIsOk { get { return _eliminarIsOk; } }
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
                    Helpers.Msg.Error("SUCURSAL ACTUAL, NO POSEE INGUN DEPOSITO ASIGNADO");
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
                }
            }
        }


        public void Funcion_Sucursales(data ItemActual)
        {
        }

        public bool ActivarInactivarIsOk { get { return false; } }
        public void ActivarInactivar(data ItemActual)
        {
        }

    }

}