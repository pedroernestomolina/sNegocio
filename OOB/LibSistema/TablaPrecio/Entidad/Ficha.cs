using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.TablaPrecio.Entidad
{

    
    public class Ficha
    {

        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string estatus { get; set; }
        public bool esActivo { get { return estatus == "1" ? true : false; } }


        public Ficha() 
        {
            id = -1;
            codigo = "";
            descripcion = "";
            estatus = "";
        }

    }

}