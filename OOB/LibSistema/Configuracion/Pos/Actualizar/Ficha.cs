using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Configuracion.Pos.Actualizar
{
    public class Ficha
    {
        public decimal tasaManejoDivisaPos { get; set; }
        public bool permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa { get; set; }
        public decimal valorMaximoDescuentoPermitido { get; set; }
        public List<OOB.LibSistema.AjustarTasaPos.AjustarData.Producto> productosAjustar { get; set; }
        public List<OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio> historicoPreciosAgregar { get; set; }
        //
        public Ficha()
        {
            tasaManejoDivisaPos = 0m;
            permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa = false;
            valorMaximoDescuentoPermitido = 0m;
            productosAjustar = null;
            historicoPreciosAgregar = null;
        }

        public string estacion { get; set; }

        public string usuario { get; set; }
    }
}