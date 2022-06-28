using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.AsignarDeposito
{
    
    public class data
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public bool esActivo { get; set; }
        public string mSucDeposito { get; set; }


        public data()
        {
            auto = "";
            codigo = "";
            descripcion = "";
            esActivo = false;
            mSucDeposito = "";
        }


        public void setInactivar()
        {
            esActivo = false;
        }
        public void setActivar()
        {
            esActivo = true;
        }

    }

}