using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.src
{
    
    public class FabModoBasico: IFabrica
    {

        public void CrearIniciarFrm_PanelPrincipal(Gestion ctr)
        {
            var frm = new PanelPrincipal.ModoBasico.Principal();
            frm.setControlador(ctr);
            frm.ShowDialog();
        }

        public TasaDivisa.IGestion CrearInstancia_TasaDivisa()
        {
            return new TasaDivisa.Sist.GestionBasico();
        }

    }

}