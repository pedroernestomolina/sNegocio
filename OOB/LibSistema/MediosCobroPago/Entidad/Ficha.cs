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
        public string estatusCobro { get; set; }
        public string estatusPago { get; set; }
        public bool isParaCobro { get { return estatusCobro.Trim().ToUpper() == "1"; } }
        public bool isParaPago { get { return estatusPago.Trim().ToUpper() == "1"; } }


        public Ficha()
        {
            auto = "";
            codigo = "";
            descripcion = "";
            estatusCobro = "";
            estatusPago = "";
        }

    }

}