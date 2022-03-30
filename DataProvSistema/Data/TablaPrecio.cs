using DataProvSistema.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{
    
    
    public partial class DataProv : IData
    {

        public OOB.ResultadoId 
            TablaPrecio_Agregar(OOB.LibSistema.TablaPrecio.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoId();

            var fichaDTO = new DtoLibSistema.TablaPrecio.Agregar.Ficha()
            {
                descripcion = ficha.descripcion,
            };
            var r01 = MyData.TablaPrecio_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Id = r01.Id;

            return rt;
        }
        public OOB.Resultado 
            TablaPrecio_Editar(OOB.LibSistema.TablaPrecio.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.TablaPrecio.Editar.Ficha()
            {
                id = ficha.id,
                descripcion = ficha.descripcion,
            };
            var r01 = MyData.TablaPrecio_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibSistema.TablaPrecio.Entidad.Ficha> 
            TablaPrecio_GetById(int id)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.TablaPrecio.Entidad.Ficha>();

            var r01 = MyData.TablaPrecio_GetById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s = r01.Entidad;
            var ent = new OOB.LibSistema.TablaPrecio.Entidad.Ficha()
            {
                codigo = s.codigo,
                descripcion = s.descripcion,
                estatus = s.estatus,
                id = s.id,
            };
            rt.Entidad = ent;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibSistema.TablaPrecio.Entidad.Ficha> 
            TablaPrecio_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.TablaPrecio.Entidad.Ficha>();

            var r01 = MyData.TablaPrecio_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.LibSistema.TablaPrecio.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.TablaPrecio.Entidad.Ficha()
                        {
                            codigo = s.codigo,
                            descripcion = s.descripcion,
                            estatus = s.estatus,
                            id = s.id,
                        };
                    }).ToList();
                }
            }
            rt.Lista = lst;

            return rt;
        }

    }

}