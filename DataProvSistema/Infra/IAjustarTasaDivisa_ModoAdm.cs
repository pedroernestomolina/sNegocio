using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    public interface IAjustarTasaDivisa_ModoAdm
    {
        OOB.ResultadoLista<OOB.LibSistema.AjustarTasaDivisa.ModoAdm.CapturarData>
            AjustarTasaDivisa_ModoAdm_CapturarData();
        OOB.ResultadoEntidad<int>
            AjustarTasaDivisa_ModoAdm_Ajustar(OOB.LibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.Ficha ficha);
    }
}