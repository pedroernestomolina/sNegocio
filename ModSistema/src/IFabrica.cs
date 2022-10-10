using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.src
{
    
    public interface IFabrica
    {

        void CrearIniciarFrm_PanelPrincipal(Gestion gestion);
        TasaDivisa.IGestion CrearInstancia_TasaDivisa();

    }

}