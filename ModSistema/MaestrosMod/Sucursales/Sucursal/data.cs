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
        public bool mSucPosVentaSurtido { get; set; }
        public bool mSucPosVueltoDivisa { get; set; }


        public data() 
        {
            auto = "";
            codigo = "";
            descripcion = "";
            esActivo = false;
            mSucGrupo = "";
            mSucFactMayor = false;
            mSucFactCredito = false;
            mSucPosVentaSurtido = false;
            mSucPosVueltoDivisa = false;
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