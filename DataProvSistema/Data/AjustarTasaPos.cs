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
        public OOB.ResultadoEntidad<OOB.LibSistema.AjustarTasaPos.CapturarData.Ficha> 
            AjustarTasaPos_CapturarData()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.AjustarTasaPos.CapturarData.Ficha>();
            //
            var r01 = MyData.AjustarTasaPos_CapturarData();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<OOB.LibSistema.AjustarTasaPos.CapturarData.Item>();
            if (r01.Entidad==null)
                throw new Exception("PROBLEMA AL CARGAR DATA");
            if (r01.Entidad.items==null)
                throw new Exception("PROBLEMA AL CARGAR LISTA");
            if (r01.Entidad.items.Count>0)
            {
                _lst = r01.Entidad.items.Select(s =>
                {
                    var nr = new OOB.LibSistema.AjustarTasaPos.CapturarData.Item()
                    {
                        codigoPrd = s.codigoPrd,
                        contEmp1 = s.contEmp1,
                        contEmp2 = s.contEmp2,
                        contEmp3 = s.contEmp3,
                        descEmp1 = s.descEmp1,
                        descEmp2 = s.descEmp2,
                        descEmp3 = s.descEmp3,
                        dsp1 = s.dsp1,
                        dsp2 = s.dsp2,
                        dsp3 = s.dsp3,
                        dsp4 = s.dsp4,
                        idPrd = s.idPrd,
                        may1 = s.may1,
                        may2 = s.may2,
                        may3 = s.may3,
                        may4 = s.may4,
                        nombrePrd = s.nombrePrd,
                        p1 = s.p1,
                        p2 = s.p2,
                        p3 = s.p3,
                        p4 = s.p4,
                    };
                    return nr;
                }).ToList();
            }
            rt.Entidad = new OOB.LibSistema.AjustarTasaPos.CapturarData.Ficha()
            {
                items = _lst,
            };
            //
            return rt;
        }
    }
}