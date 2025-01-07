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
        public Resultado 
            SerieFiscal_ActivarFicha(OOB.LibSistema.SerieFiscal.ActivarInactivar.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            //
            var fichaDTO = new DtoLibSistema.SerieFiscal.ActivarInactivar.Ficha()
            {
                id = ficha.id,
            };
            var r01 = MyData.SerieFiscal_Activar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            return rt;
        }

        public Resultado 
            SerieFiscal_InactivarFicha(OOB.LibSistema.SerieFiscal.ActivarInactivar.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            //
            var fichaDTO = new DtoLibSistema.SerieFiscal.ActivarInactivar.Ficha()
            {
                id = ficha.id,
            };
            var r01 = MyData.SerieFiscal_Inactivar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            return rt;
        }
    }
}