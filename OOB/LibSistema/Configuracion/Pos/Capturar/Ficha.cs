using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Configuracion.Pos.Capturar
{
    
    public class Ficha
    {

        public decimal tasaManejoDivisaSist { get; set; }
        public decimal tasaManejoDivisaPos { get; set; }
        public bool permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa { get; set; }
        public decimal valorMaximoDescuentoPermitido { get; set; }


        public Ficha()
        {
            tasaManejoDivisaPos = 0m;
            tasaManejoDivisaSist = 0m;
            permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa = false;
            valorMaximoDescuentoPermitido = 0m;
        }

    }

}