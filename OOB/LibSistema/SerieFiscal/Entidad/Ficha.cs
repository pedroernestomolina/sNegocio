using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.SerieFiscal.Entidad
{
    public class Ficha
    {
        public string id { get; set; }
        public string serie { get; set; }
        public int correlativo { get; set; }
        public string control { get; set; }
        public bool estatusFactura { get; set; }
        public bool estatusNtDebito { get; set; }
        public bool estatusNtCredito { get; set; }
        public bool estatusNtEntrega { get; set; }
        public bool estatusAplicaLibroVenta { get; set; }
        public string estatus { get; set; }
        public bool IsActivo { get { return estatus.Trim().ToUpper() == "ACTIVO"; } }
    }
}