using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.Sucursal
{
    
    public class data
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public bool esActivo { get; set; }
        public string mSucGrupo{ get; set; }
        public bool mSucFactMayor { get; set; }
        public bool mSucFactCredito { get; set; }


        public data() 
        {
            auto = "";
            codigo = "";
            descripcion = "";
            esActivo = false;
            mSucGrupo = "";
            mSucFactMayor = false;
            mSucFactCredito = false;
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