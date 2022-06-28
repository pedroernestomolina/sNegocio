using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.Grupo
{
    
    public class data
    {

        public string auto { get; set; }
        public string descripcion { get; set; }
        public bool esActivo { get; set; }
        public string mGrupoPrecioRef { get; set; }


        public data()
        {
            auto = "";
            descripcion = "";
            esActivo = false;
            mGrupoPrecioRef = "";
        }

    }

}