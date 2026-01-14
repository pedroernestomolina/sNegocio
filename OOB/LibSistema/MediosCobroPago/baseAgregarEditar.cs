using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.MediosCobroPago
{
    public abstract class baseAgregarEditar
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string estatusCobro {get;set;}
        public string estatusPago { get; set; }
        public string aplicaParaPos { get; set; }
        public string aplicaLoteRef { get; set; }
        public string aplicaBonoPagoDivisa { get; set; }
        public string aplicaIGTF { get; set; }
        public string aplicaModuloCobroAnticipo { get; set; }
        public string aplicaRetornoCambioVuelto { get; set; }
        public int idMoneda { get; set; }
    }
}