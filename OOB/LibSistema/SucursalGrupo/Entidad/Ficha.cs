using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.SucursalGrupo.Entidad
{


    public class Ficha
    {

        public string auto { get; set; }
        public int idPrecio { get; set; }
        public string nombre { get; set; }
        public string estatus { get; set; }
        public string refPrecio { get; set; }
        public bool esActivo { get { return estatus == "1" ? true : false; } }


        public Ficha()
        {
            auto = "";
            idPrecio = -1;
            nombre = "";
            estatus = "";
            refPrecio = "";
        }

    }

}