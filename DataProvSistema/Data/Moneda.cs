using DataProvSistema.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{
    public partial class DataProv: IData
    {
        public OOB.ResultadoEntidad<OOB.LibSistema.Moneda.Entidad.Ficha>
            Moneda_GetFichaById(int id)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibSistema.Moneda.Entidad.Ficha>();
            //
            try
            {
                var rt = MyData.Moneda_GetFichaById(id);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                if (rt.Entidad == null)
                {
                    throw new Exception("DATA [ MONEDA ] NO CARGADA");
                }
                var s = rt.Entidad;
                var ent = new OOB.LibSistema.Moneda.Entidad.Ficha()
                {
                    codigo = s.codigo,
                    id = s.id,
                    nombre = s.nombre,
                    simbolo = s.simbolo,
                    tasaRespectoMonReferencia = s.tasaRespectoMonReferencia,
                };
                result.Entidad = ent;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
        public OOB.ResultadoLista<OOB.LibSistema.Moneda.Entidad.Ficha> 
            Moneda_GetLista(OOB.LibSistema.Moneda.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibSistema.Moneda.Entidad.Ficha>();
            //
            try
            {
                var _lst = new List<OOB.LibSistema.Moneda.Entidad.Ficha>();
                var filtroDTO = new DtoLibSistema.Moneda.Filtro();
                var rt = MyData.Moneda_GetLista(filtroDTO);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                if (rt.Lista == null)
                {
                    throw new Exception("DATA NO CARGADA");
                }
                if (rt.Lista.Count > 0) 
                {
                    _lst = rt.Lista.Select(s =>
                    {
                        var ent = new OOB.LibSistema.Moneda.Entidad.Ficha()
                        {
                            codigo = s.codigo,
                            id = s.id,
                            nombre = s.nombre,
                            simbolo = s.simbolo,
                            tasaRespectoMonReferencia = s.tasaRespectoMonReferencia,
                        };
                        return ent;
                    }).ToList();
                }
                result.Lista = _lst;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
    }
}