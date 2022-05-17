using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IPrecioEtiqueta
    {

        OOB.ResultadoEntidad<OOB.LibSistema.PrecioEtiqueta.Entidad.Ficha> 
            PrecioEtiqueta_GetFicha();
        OOB.Resultado
            PrecioEtiqueta_Actualizar(OOB.LibSistema.PrecioEtiqueta.Actualizar.Ficha ficha);

    }

}