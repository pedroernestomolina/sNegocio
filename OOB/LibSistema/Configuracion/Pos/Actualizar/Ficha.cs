using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Configuracion.Pos.Actualizar
{
    
    public class Ficha
    {

        public bool permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa { get; set; }
        public decimal valorMaximoDescuentoPermitido { get; set; }


        public Ficha()
        {
            permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa = false;
            valorMaximoDescuentoPermitido = 0m;
        }

    }

}