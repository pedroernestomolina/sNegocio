using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Deposito.Entidad
{
    

    public class Ficha
    {

        public string auto { get; set; }
        public string autoSucursal { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string codigoSucursal { get; set; }
        public string nombreSucursal { get; set; }
        public string estatus { get; set; }
        public bool esActivo { get { return estatus.Trim().ToUpper() == "1" ? true : false; } }


        public Ficha()
        {
            auto = "";
            codigo = "";
            nombre = "";
            estatus = "";
            autoSucursal = "";
            codigoSucursal = "";
            nombreSucursal = "";
        }

    }

}