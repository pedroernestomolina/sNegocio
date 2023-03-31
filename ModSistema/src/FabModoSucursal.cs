using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.src
{
    
    public class FabModoSucursal: IFabrica
    {
        public void 
            CrearIniciarFrm_PanelPrincipal(Gestion ctr)
        {
            var frm = new src.PanelPrincipal.ModoSucursal.Principal();
            frm.setControlador(ctr);
            frm.ShowDialog();
        }
        public TasaDivisa.IGestion 
            CrearInstancia_TasaDivisa()
        {
            return new TasaDivisa.Sist.Gestion();
        }
        public ActualizarTasaDivisa.ITasa 
            CrearInstancia_ActualizarTasaDivisa()
        {
            return null;
        }
    }
}