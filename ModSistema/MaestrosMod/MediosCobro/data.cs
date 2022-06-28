using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.MediosCobro
{
    
    public class data
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public bool isParaCobro { get; set; }
        public bool isParaPago { get; set; }


        public data()
        {
            auto = "";
            codigo = "";
            descripcion = "";
            isParaCobro = false;
            isParaPago = false;
        }

    }

}