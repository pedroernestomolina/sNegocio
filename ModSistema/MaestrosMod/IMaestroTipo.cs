using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod
{
    
    public interface IMaestroTipo: IGestion
    {

        BindingSource Source { get; }
        string Titulo { get; }
        int CntItems { get; }


        void AgregarItem();
        bool AgregarIsOk { get; }

        void EditarItem();
        bool EditarIsOk { get; }

    }

}