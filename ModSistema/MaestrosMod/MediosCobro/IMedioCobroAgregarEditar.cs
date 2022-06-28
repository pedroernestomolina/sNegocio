using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.MediosCobro
{


    public interface IMedioCobroAgregarEditar : IMaestroAgregarEditar
    {

        void setNombre(string p);
        string GetNombre { get;  }
        void setCodigo(string p);
        string GetCodigo { get; }
        void setParaCobranza(bool p);
        bool GetEstatusCobranza { get; }
        void setParaPago(bool p);
        bool GetEstatusPago { get; }

    }

}