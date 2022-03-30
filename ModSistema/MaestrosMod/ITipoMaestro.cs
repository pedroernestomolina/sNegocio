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
        void Inicializa();
        void Inicia(IMaestro ctr);


        data ItemAgregarEditar { get; }
        bool AgregarIsOk { get; }
        void AgregarItem();
        void EditarItem(data ItemActual);
        bool EditarIsOk { get; }

    }

}