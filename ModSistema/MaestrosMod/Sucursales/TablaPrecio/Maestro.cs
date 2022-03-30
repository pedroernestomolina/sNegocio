using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.TablaPrecio
{
    
    public class Maestro: ITipoMaestro
    {

        private List<data> _lst;
        private IAgregarEditar _gAgregar;
        private IAgregarEditar _gEditar;
        private data _dataAgregarEditar;


        public string GetTitulo { get { return "Maestro: TABLA PRECIOS"; } }
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
            var r01 = Sistema.MyData.TablaPrecio_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            foreach (var rg in r01.Lista)
            {
                var nr = new data()
                {
                    id=rg.id,
                    auto=rg.id.ToString(),
                    codigo = rg.codigo,
                    descripcion = rg.descripcion,
                    esActivo = rg.esActivo,
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
                var id = (int)_gAgregar.IdItemRegistrado;
                var r01 = Sistema.MyData.TablaPrecio_GetById(id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var rg = r01.Entidad;
                _dataAgregarEditar = new data()
                {
                    id = rg.id,
                    auto = rg.id.ToString(),
                    codigo = rg.codigo,
                    descripcion = rg.descripcion,
                    esActivo = rg.esActivo,
                };
            }
        }

        public bool EditarIsOk { get { return _gEditar.IsOk; } }
        public void EditarItem(data ItemActual)
        {
            var _idEditar = ItemActual.id;
            _dataAgregarEditar = null;
            _gEditar.Inicializa();
            _gEditar.setIdItemEditar(ItemActual.id);
            _gEditar.Inicia();
            if (_gEditar.IsOk)
            {
                var r01 = Sistema.MyData.TablaPrecio_GetById(_idEditar);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var rg = r01.Entidad;
                _dataAgregarEditar = new data()
                {
                    id = rg.id,
                    auto = rg.id.ToString(),
                    codigo = rg.codigo,
                    descripcion = rg.descripcion,
                    esActivo = rg.esActivo,
                };
            }
        }

    }

}