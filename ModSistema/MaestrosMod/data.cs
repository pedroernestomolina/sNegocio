using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod
{
    
    public class data
    {

        public int id { get; set; }
        public string auto { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public bool esActivo { get; set; }
        public string precioManeja { get; set; }


        public data() 
        {
            id = -1;
            auto = "";
            codigo = "";
            descripcion = "";
            esActivo = false;
            precioManeja = "";
        }
    
    }

}