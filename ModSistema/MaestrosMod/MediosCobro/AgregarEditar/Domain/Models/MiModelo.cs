using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.MediosCobro.AgregarEditar.Domain.Models
{
    public class MiModelo
    {
        private string _codigoMP;
        private string _nombreMP;
        private bool _aplicaParaCobranza;
        private bool _aplicaParaPago;
        private Domain.Models.Monedas _moneda;
        private bool _aplicaParaPos;
        private bool _aplicaLoteRef;
        private bool _aplicaBonoPagoDivisa;
        private bool _aplicaIGTF;
        private bool _aplicaRetornoCambioVuelto;
        private bool _aplicaModuloCobroAnticipo;
        //
        public string GetNombreMedioPago { get { return _nombreMP.Trim(); } }
        public string GetCodigoMedioPago { get { return _codigoMP.Trim(); } }
        public bool GetAplicaParaCobranza { get { return _aplicaParaCobranza; } }
        public bool GetAplicaParaPago { get { return _aplicaParaPago; } }
        public bool GetAplicaParaPos { get { return _aplicaParaPos; } }
        public bool GetAplicaLoteRef { get { return _aplicaLoteRef; } }
        public bool GetAplicaIGTF { get { return _aplicaIGTF; } }
        public bool GetAplicaBonoPagoDivisa { get { return _aplicaIGTF; } }
        public bool GetAplicaRetornoCambioVuelto{ get { return _aplicaRetornoCambioVuelto; } }
        public bool GetAplicaModuloCobroAnticipo{ get { return _aplicaModuloCobroAnticipo; } }
        public Domain.Models.Monedas GetMoneda { get { return _moneda; } }
        //
        public MiModelo()
        {
            _codigoMP = "";
            _nombreMP = "";
            _aplicaParaCobranza = false;
            _aplicaParaPago = false;
            _aplicaLoteRef = false;
            _aplicaParaPos = false;
            _aplicaBonoPagoDivisa = false;
            _aplicaIGTF = false;
            _aplicaModuloCobroAnticipo = false;
            _aplicaRetornoCambioVuelto = false;
            _moneda = null;
        }
        public void Inicializa()
        {
            _codigoMP = "";
            _nombreMP = "";
            _aplicaParaCobranza = false;
            _aplicaParaPago = false;
            _aplicaLoteRef = false;
            _aplicaParaPos = false;
            _aplicaBonoPagoDivisa = false;
            _aplicaIGTF = false;
            _aplicaModuloCobroAnticipo = false;
            _aplicaRetornoCambioVuelto = false;
            _moneda = null;;
        }
        public void setCodigoMedioPago(string p)
        {
            _codigoMP = p;
        }
        public void setNombreMedioPago(string p)
        {
            _nombreMP = p;
        }
        public void setAplicaParaCobranza(bool p)
        {
            _aplicaParaCobranza=p;
        }
        public void setAplicaParaPago(bool p)
        {
            _aplicaParaPago = p;
        }
        public void setAplicaParaPos(bool aplic)
        {
            _aplicaParaPos = aplic;
        }
        public void setAplicaLoteRef(bool aplic)
        {
            _aplicaLoteRef = aplic;
        }
        public void setMoneda(Monedas ficha)
        {
            _moneda = ficha;
        }
        public void setAplicaBonoPagoDivisa(bool aplic)
        {
            _aplicaBonoPagoDivisa = aplic;
        }
        public void setAplicaIGTF(bool aplic)
        {
            _aplicaIGTF = aplic;
        }
        public void setAplicaRetornoCambioVuelto(bool aplic)
        {
            _aplicaRetornoCambioVuelto = aplic;
        }
        public void setAplicaModuloCobroAnticipo(bool aplic)
        {
            _aplicaModuloCobroAnticipo = aplic;
        }
    }
}