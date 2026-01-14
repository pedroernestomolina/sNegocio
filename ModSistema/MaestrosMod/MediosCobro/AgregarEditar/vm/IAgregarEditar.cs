using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModSistema.MaestrosMod.MediosCobro.AgregarEditar.vm
{
    public interface IAgregarEditar: IMaestroAgregarEditar
    {
        string GetNombre { get;  }
        string GetCodigo { get; }
        bool GetEstatusCobranza { get; }
        bool GetEstatusPago { get; }
        object GetMonedasSource { get; }
        string GetIdMoneda { get; }
        bool GetAplicaLoteReferencia { get; }
        bool GetAplicaModuloCobroAnticipo { get; }
        bool GetAplicaParaBonoPagoDivisa { get; }
        bool GetAplicaParaIGTF { get; }
        bool GetAplicaParaPOS { get; }
        bool GetAplicaRetornoCambioVuelto { get; }
        //
        void setCodigo(string p);
        void setNombre(string p);
        void setParaCobranza(bool p);
        void setParaPago(bool p);
        void setAplicaParaPos(bool aplic);
        void setAplicaLoteRef(bool aplic);
        void setAplicaBonoPagoDivisa(bool aplic);
        void setAplicaIGTF(bool aplic);
        void setAplicaRetornoCambioVuelto(bool aplic);
        void setAplicaModuloCobroAnticipo(bool aplic);
        void setMoneda(object moneda);
    }
}