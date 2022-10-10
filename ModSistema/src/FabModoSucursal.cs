using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.src
{
    
    public class FabModoSucursal: IFabrica
    {

        public void CrearIniciarFrm_PanelPrincipal(Gestion ctr)
        {
            var frm = new Form1();
            frm.setControlador(ctr);
            frm.ShowDialog();
        }

        public TasaDivisa.IGestion CrearInstancia_TasaDivisa()
        {
            return new TasaDivisa.Sist.Gestion();
        }

    }

}