using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.src
{
    
    public class FabModoAdm: IFabrica
    {
        public void 
            CrearIniciarFrm_PanelPrincipal(Gestion ctr)
        {
            var frm = new PanelPrincipal.ModoAdm.Principal();
            frm.setControlador(ctr);
            frm.ShowDialog();
        }
        public TasaDivisa.IGestion 
            CrearInstancia_TasaDivisa()
        {
            return null;
        }
        public ActualizarTasaDivisa.ITasa 
            CrearInstancia_ActualizarTasaDivisa()
        {
            return new ActualizarTasaDivisa.ModoAdm.ImpModoAdm();
        }
    }
}