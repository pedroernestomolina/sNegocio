using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Deposito.Agregar
{


    public class Ficha
    {

        public string nombre { get; set; }
        public string autoSucurusal { get; set; }
        public string codigoSucursal { get; set; }


        public Ficha() 
        {
            nombre = "";
            autoSucurusal = "";
            codigoSucursal = "";
        }

    }

}