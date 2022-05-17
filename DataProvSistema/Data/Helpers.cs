using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    class Helpers
    {
        

        public static OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> 
            PermisoRt(Func<string, DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha>> met, string grupo) 
        {
            var rs = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var rt=met(grupo);
            if (rt.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                rs.Mensaje = rt.Mensaje;
                rs.Result = OOB.Enumerados.EnumResult.isError;
                return rs;
            }
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = rt.Entidad.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)rt.Entidad.NivelSeguridad,
            };
            rs.Entidad = nr;

            return rs;
        }

    }

}