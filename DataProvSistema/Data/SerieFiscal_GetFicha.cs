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
        public ResultadoEntidad<OOB.LibSistema.SerieFiscal.Entidad.Ficha> 
            SerieFiscal_GetFicha_ById(string id)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.SerieFiscal.Entidad.Ficha>();
            //
            var r01 = MyData.SerieFiscal_GetFicha_ById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            var s = r01.Entidad;
            var nr = new OOB.LibSistema.SerieFiscal.Entidad.Ficha()
            {
                id = s.id,
                serie = s.serie,
                control = s.control,
                correlativo = s.correlativo,
                estatusFactura = s.estatusFactura.Trim().ToUpper()=="1",
                estatusNtCredito = s.estatusNtCredito.Trim().ToUpper() == "1",
                estatusNtDebito = s.estatusNtDebito.Trim().ToUpper() == "1",
                estatusNtEntrega = s.estatusNtEntrega.Trim().ToUpper() == "1",
                estatusAplicaLibroVenta = s.estatusAplicaLibroVenta.Trim().ToUpper() == "1",
                estatus= s.estatus,
            };
            //
            rt.Entidad = nr;
            return rt;
        }
    }
}