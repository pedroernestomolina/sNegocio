using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Grupo
{
    
    public class Maestro: ITipoMaestro
    {

        private List<data> _lst;
        private IAgregarEditar _gAgregar;
        private IAgregarEditar _gEditar;
        private Helpers.Lista.ILista _gListaSuc;
        private bool _eliminarIsOk;
        private data _dataAgregarEditar;


        public string GetTitulo { get { return "Maestro: SUCURSAL - GRUPOS"; } }
        public IEnumerable<data> Lista { get { return _lst; } }


        public Maestro(IAgregarEditar agregar, IAgregarEditar editar, Helpers.Lista.ILista lista) 
        {
            _gAgregar = agregar;
            _gEditar = editar;
            _gListaSuc = lista;
            _lst = new List<data>();
            _dataAgregarEditar = null;
            _eliminarIsOk = false;
        }


        public void Inicializa()
        {
            _gAgregar.Inicializa();
            _gEditar.Inicializa();
            _lst.Clear();
            _dataAgregarEditar = null;
            _eliminarIsOk = false;
        }

        public bool CargarData()
        {
            _lst.Clear();
            var r01 = Sistema.MyData.SucursalGrupo_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
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


        public data ItemAgregarEditar { get { return _dataAgregarEditar; } }
        public bool AgregarIsOk { get { return _gAgregar.IsOk; } }
        public void AgregarItem()
        {
            _dataAgregarEditar = null;
            _gAgregar.Inicializa();
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
                _dataAgregarEditar = new data()
                {
                    auto = rg.auto,
                    descripcion = rg.nombre,
                    esActivo = rg.esActivo,
                    mGrupoPrecioRef = rg.refPrecio,
                };
            }
        }


        public bool EditarIsOk { get { return _gEditar.IsOk; } }
        public void EditarItem(data ItemActual)
        {
            var _idEditar = ItemActual.auto;
            _dataAgregarEditar = null;

            _gEditar.Inicializa();
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
                _dataAgregarEditar = new data()
                {
                    auto = rg.auto,
                    descripcion = rg.nombre,
                    esActivo = rg.esActivo,
                    mGrupoPrecioRef = rg.refPrecio,
                };
            }
        }


        public bool EliminarItemIsOk { get { return _eliminarIsOk; } }
        public void EliminarItem(data ItemActual)
        {
            _eliminarIsOk = false;
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
                Helpers.Msg.EliminarOk();
            }
        }


        public void Funcion_Sucursales(data ItemActual)
        {
            var filtroOOB = new OOB.LibSistema.Sucursal.Lista.Filtro() { autoGrupo = ItemActual.auto };
            var r01 = Sistema.MyData.Sucursal_GetLista(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return ;
            }
            var lst = new List<Helpers.Lista.data>();
            foreach (var rg in r01.Lista.OrderBy(o=>o.nombre).ToList()) 
            {
                lst.Add(new Helpers.Lista.data() { codigo = rg.codigo, descripcion = rg.nombre, esActivo = true, id = rg.auto });
            }

            _gListaSuc.Inicializa();
            _gListaSuc.setTitulo("Lista de Sucursales");
            _gListaSuc.setData(lst);
            _gListaSuc.Inicia();
        }

    }

}