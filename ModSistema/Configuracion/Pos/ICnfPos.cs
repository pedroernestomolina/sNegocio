using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Configuracion.Pos
{
    
    public interface ICnfPos: IGestion, Helpers.IAbandonar, Helpers.IProcesar
    {

        void setMaximoDscto(decimal dscto);
        void setHabilitarDsctoPagoDivisa(bool p);


        decimal GetDsctoMaximoPermitido { get; }
        bool GetPermisoDsctoPagoDivisa { get; }

    }

}