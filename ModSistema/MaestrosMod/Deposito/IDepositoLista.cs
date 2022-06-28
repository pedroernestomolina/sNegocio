using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Deposito
{
    
    public interface IDepositoLista: IMaestroLista
    {

        data ItemActual { get; }


        void Agregar(data data);
        void Actualizar(data data);
        void setLista(IEnumerable<data> lst);

    }

}