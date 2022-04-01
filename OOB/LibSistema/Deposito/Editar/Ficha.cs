using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Deposito.Editar
{
    
    
    public class Ficha
    {

        public string auto { get; set; }
        public string nombre { get; set; }
        public string autoSucurusal { get; set; }
        public string codigoSucursal { get; set; }


        public Ficha()
        {
            auto = "";
            nombre = "";
            autoSucurusal = "";
            codigoSucursal = "";
        }

    }

}