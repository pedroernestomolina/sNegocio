using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod
{


    public interface IMaestro: IGestion
    {

        BindingSource Source { get; }
        string Titulo { get; }
        int CntItems { get; }


        void setTipoMaestro(ITipoMaestro maestro);


        void AgregarItem();
        bool AgregarIsOk { get; }


        void EditarItem();
        bool EditarIsOk { get; }

    }

}