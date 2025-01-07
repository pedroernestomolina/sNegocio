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
        public ResultadoAuto SerieFiscal_AgregarFicha(OOB.LibSistema.SerieFiscal.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();
            //
            var fichaDTO = new DtoLibSistema.SerieFiscal.Agregar.Ficha()
            {
                control = ficha.control,
                correlativo = ficha.correlativo,
                serie = ficha.serie,
                estatusFactura = ficha.estatusFactura ? "1" : "0",
                estatusNtCredito = ficha.estatusNtCredito ? "1" : "0",
                estatusNtDebito = ficha.estatusNtDebito ? "1" : "0",
                estatusNtEntrega = ficha.estatusNtEntrega ? "1" : "0",
                estatusAplicaLibroVenta = ficha.estatusAplicaLibroVenta ? "1" : "0",
            };
            var r01 = MyData.SerieFiscal_AgregarFicha(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            rt.Auto = r01.Auto;
            return rt;
        }
    }
}