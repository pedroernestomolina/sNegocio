using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.SerieFiscal.Agregar
{
    public class Ficha
    {
        public string serie { get; set; }
        public int correlativo { get; set; }
        public string control { get; set; }
        public bool estatusFactura { get; set; }
        public bool estatusNtDebito { get; set; }
        public bool estatusNtCredito { get; set; }
        public bool estatusNtEntrega { get; set; }
        public bool estatusAplicaLibroVenta { get; set; }
    }
}