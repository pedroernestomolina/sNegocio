using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod
{
    
    public interface IMaestroLista
    {

        int CntItems { get; }
        BindingSource Source { get; }


        void Inicializa();

    }

}