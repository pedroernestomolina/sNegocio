using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod
{
    
    public interface ILista
    {

        int CntItems { get; }
        BindingSource Source { get; }
        data ItemActual { get; }


        void Inicializa();
        void Agregar(data data);
        void Actualizar(data data);
        void EliminarItemActual();
        void setLista(IEnumerable<data> lst);

    }

}