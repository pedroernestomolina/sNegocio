using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.Sucursal
{
    
    public class Maestro: ITipoMaestro
    {

        private List<data> _lst;
        private IAgregarEditar _gAgregar;
        private IAgregarEditar _gEditar;
        private data _dataAgregarEditar;


        public string GetTitulo { get { return "Maestro: SUCURSALES"; } }
        public IEnumerable<data> Lista { get { return _lst; } }


        public Maestro(IAgregarEditar agregar, IAgregarEditar editar)
        {
            _gAgregar = agregar;
            _gEditar = editar;
            _lst = new List<data>();
            _dataAgregarEditar = null;
        }


        public void Inicializa()
        {
            _gAgregar.Inicializa();
            _gEditar.Inicializa();
            _lst.Clear();
            _dataAgregarEditar = null;
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
                };
            }
        }

        public bool EliminarItemIsOk { get { return false; } }
        public void EliminarItem(data ItemActual)
        {
        }


        public void Funcion_Sucursales(data ItemActual)
        {
        }

    }

}