using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod
{
    
    
    public interface ITipoMaestro
    {

        string GetTitulo { get; }
        IEnumerable<data> Lista { get; }


        bool CargarData();
        void Inicia(IMaestro ctr);


        bool AgregarIsOk { get; }
        data ItemAgregar { get; }
        void AgregarItem();

    }

}