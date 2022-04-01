using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    class Helpers
    {
        
        public static OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso(DtoLibSistema.Permiso.Ficha ficha)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var s = ficha;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}
