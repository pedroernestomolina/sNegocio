using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    public interface IMoneda
    {
        OOB.ResultadoEntidad<OOB.LibSistema.Moneda.Entidad.Ficha>
            Moneda_GetFichaById(int id);
    }
}