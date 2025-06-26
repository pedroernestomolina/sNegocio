using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Configuracion.Pos
{
    public interface ICnfPos: IGestion, Helpers.IAbandonar, Helpers.IProcesar
    {
        decimal GetDsctoMaximoPermitido { get; }
        bool GetPermisoDsctoPagoDivisa { get; }
        decimal GetTasaManejoDivSist { get; }
        decimal  GetTasaManejoDivPos { get; }
        decimal GetDiferenciaPorct { get; }
        decimal GetPorcAumentoPrecioPosNoAdmDivisa { get; }
        //
        void setTasaPos(decimal tasaPos);
        void setMaximoDscto(decimal dscto);
        void setHabilitarDsctoPagoDivisa(bool p);
        void setPorcAumentoPrecioNoAdmDivisa(decimal porc);
    }
}