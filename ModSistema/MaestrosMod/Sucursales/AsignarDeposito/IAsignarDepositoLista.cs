using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.AsignarDeposito
{
    
    public interface IAsignarDepositoLista: IMaestroLista
    {

        data ItemActual { get; }


        void Agregar(data data);
        void Actualizar(data data);
        void EliminarItemActual();
        void setLista(IEnumerable<data> lst);

    }

}
