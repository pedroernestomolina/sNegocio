using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Grupo
{
    
    public class Maestro: IGrupo
    {

        private IGrupoLista _gLista;
        private Grupo.AgregarEditar.IAgregar _gAgregar;
        private Grupo.AgregarEditar.IEditar _gEditar;
        private Helpers.Lista.ILista _gListaSuc;
        private bool _eliminarIsOk;


        public string Titulo { get { return "Maestro: SUCURSAL - GRUPOS"; } }
        public BindingSource Source { get { return _gLista.Source; } }
        public int CntItems { get { return _gLista.CntItems; } }


        public Maestro( 
            IGrupoLista lista,
            Grupo.AgregarEditar.IAgregar agregar, 
            Grupo.AgregarEditar.IEditar editar,
            Helpers.Lista.ILista listaSuc) 
        {
            _gLista=lista;
            _gAgregar = agregar;
            _gEditar = editar;
            _gListaSuc = listaSuc;
            _eliminarIsOk = false;
        }


        public void Inicializa()
        {
            _gAgregar.Inicializa();
            _gEditar.Inicializa();
            _gLista.Inicializa();
            _gListaSuc.Inicializa();
            _eliminarIsOk = false;
        }

        public bool CargarData()
        {
            var r01 = Sistema.MyData.SucursalGrupo_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var _lst = new List<data>();
            foreach (var rg in r01.Lista) 
            {
                var nr = new data()
                {
                    auto = rg.auto,
                    descripcion = rg.nombre,
                    esActivo = rg.esActivo,
                    mGrupoPrecioRef= rg.refPrecio,
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
            var r00 = Sistema.MyData.Permiso_ControlSucursalGrupo_Agregar(Sistema.UsuarioP.autoGrupo);
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
                    var r01 = Sistema.MyData.SucursalGrupo_GetFicha(id);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    var rg = r01.Entidad;
                    var _dataAgregarEditar = new data()
                    {
                        auto = rg.auto,
                        descripcion = rg.nombre,
                        esActivo = rg.esActivo,
                        mGrupoPrecioRef = rg.refPrecio,
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
            var r00 = Sistema.MyData.Permiso_ControlSucursalGrupo_Editar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var _idEditar = ItemActual.auto;
                _gEditar.setIdItemEditar(_idEditar);
                _gEditar.Inicia();
                if (_gEditar.IsOk)
                {
                    var r01 = Sistema.MyData.SucursalGrupo_GetFicha(_idEditar);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    var rg = r01.Entidad;
                    var _dataAgregarEditar = new data()
                    {
                        auto = rg.auto,
                        descripcion = rg.nombre,
                        esActivo = rg.esActivo,
                        mGrupoPrecioRef = rg.refPrecio,
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
            _eliminarIsOk = false;
            var r00 = Sistema.MyData.Permiso_ControlSucursalGrupo_Eliminar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var xmsg = "Eliminar Ficha ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var r01 = Sistema.MyData.SucursalGrupo_Eliminar(ItemActual.auto);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _eliminarIsOk = true;
                    _gLista.EliminarItemActual();
                    Helpers.Msg.EliminarOk();
                }
            }
        }

        public void Funcion_Sucursales()
        {
            if (_gLista.ItemActual != null)
            {
                Funcion_Sucursales(_gLista.ItemActual);
            }
        }
        public void Funcion_Sucursales(data ItemActual)
        {
            var filtroOOB = new OOB.LibSistema.Sucursal.Lista.Filtro() { autoGrupo = ItemActual.auto };
            var r01 = Sistema.MyData.Sucursal_GetLista(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var _lst = new List<Helpers.Lista.data>();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lst.Add(new Helpers.Lista.data() { codigo = rg.codigo, descripcion = rg.nombre, esActivo = true, id = rg.auto });
            }
            _gListaSuc.Inicializa();
            _gListaSuc.setTitulo("Lista de Sucursales");
            _gListaSuc.setData(_lst);
            _gListaSuc.Inicia();
        }

    }

}