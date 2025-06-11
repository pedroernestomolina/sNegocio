using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    public interface IAjustarTasaPos
    {
        OOB.ResultadoEntidad<OOB.LibSistema.AjustarTasaPos.CapturarData.Ficha>
            AjustarTasaPos_CapturarData();
    }
}