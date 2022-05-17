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

        public OOB.ResultadoEntidad<OOB.LibSistema.PrecioEtiqueta.Entidad.Ficha> 
            PrecioEtiqueta_GetFicha()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.PrecioEtiqueta.Entidad.Ficha>();

            var r01 = MyData.PrecioEtiqueta_GetFicha();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s= r01.Entidad;
            var nr = new OOB.LibSistema.PrecioEtiqueta.Entidad.Ficha()
            {
                descripcion_1 = s.descripcion_1,
                descripcion_2 = s.descripcion_2,
                descripcion_3 = s.descripcion_3,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.Resultado 
            PrecioEtiqueta_Actualizar(OOB.LibSistema.PrecioEtiqueta.Actualizar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.PrecioEtiqueta.Actualizar.Ficha()
            {
                descripcion_1 = ficha.descripcion_1,
                descripcion_2 = ficha.descripcion_2,
                descripcion_3 = ficha.descripcion_3,
            };
            var r01 = MyData.PrecioEtiqueta_Actualizar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}