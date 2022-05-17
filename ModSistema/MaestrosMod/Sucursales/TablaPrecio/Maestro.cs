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


        public data ItemAgregarEditar { get { return _dataAgregarEditar; } }


        public bool AgregarIsOk { get { return _gAgregar.IsOk; } }
        public void AgregarItem()
        {
            _dataAgregarEditar = null;
            _gAgregar.Inicializa();

            var r00 = Sistema.MyData.Permiso_ControlSucursal_TablaPrecio_Agregar(Sistema.UsuarioP.autoGrupo);
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
        }

        public bool EditarIsOk { get { return _gEditar.IsOk; } }
        public void EditarItem(data ItemActual)
        {
            _dataAgregarEditar = null;
            _gEditar.Inicializa();

            var r00 = Sistema.MyData.Permiso_ControlSucursal_TablaPrecio_Editar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var _idEditar = ItemActual.id;
                _gEditar.setIdItemEditar(_idEditar);
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

        public bool EliminarItemIsOk { get { return false; } }
        public void EliminarItem(data ItemActual)
        {
        }


        public void Funcion_Sucursales(data ItemActual)
        {
        }
        public void Funcion_Depositos(data ItemActual)
        {
        }


        public bool ActivarInactivarIsOk { get { return false; } }
        public void ActivarInactivar(data ItemActual)
        {
        }

    }

}