using DataProvSistema.Infra;
using OOB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{
    public partial class DataProv : IData
    {
        public ResultadoLista<OOB.LibSistema.SerieFiscal.Entidad.Ficha> 
            SerieFiscal_GetLista(OOB.LibSistema.SerieFiscal.Lista.Filtro filtro)
        {
            var rt = new ResultadoLista<OOB.LibSistema.SerieFiscal.Entidad.Ficha>();
            //
            var filtroDto = new DtoLibSistema.SerieFiscal.Lista.Filtro();
            var r01 = MyData.SerieFiscal_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var _lst = new List<OOB.LibSistema.SerieFiscal.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.SerieFiscal.Entidad.Ficha()
                        {
                            id = s.id,
                            control = s.control,
                            correlativo = s.correlativo,
                            serie = s.serie,
                            estatus = s.estatus,
                        };
                    }).ToList();
                }
            }
            rt.Lista = _lst;
            //
            return rt;
        }
    }
}