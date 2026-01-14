using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.MediosCobroPago.Entidad
{
    public class Ficha
    {
        public string auto { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public bool estatusCobro { get; set; }
        public bool estatusPago { get; set; }
        public bool aplicaParaBonoPagoEnDivisa { get; set; }
        public bool aplicaParaIGTF { get; set; }
        public bool aplicaParaModuloCobroAnticipo { get; set; }
        public bool aplicaParaPOS { get; set; }
        public bool aplicaParaRetornoCambioVuelto { get; set; }
        public bool aplicaParaSolicitarLoteReferencia { get; set; }
        public int idMoneda { get; set; }
        public Ficha()
        {
            auto = "";
            codigo = "";
            descripcion = "";
            estatusCobro = false;
            estatusPago = false;
            aplicaParaBonoPagoEnDivisa = false;
            aplicaParaIGTF = false;
            aplicaParaModuloCobroAnticipo = false;
            aplicaParaPOS = false;
            aplicaParaRetornoCambioVuelto = false;
            aplicaParaSolicitarLoteReferencia = false;
            idMoneda = 0;
        }
    }
}