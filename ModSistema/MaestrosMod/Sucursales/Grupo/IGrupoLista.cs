using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.Grupo
{

    public interface IGrupoLista: IMaestroLista
    {

        data ItemActual { get; }


        void Agregar(data data);
        void Actualizar(data data);
        void EliminarItemActual();
        void setLista(IEnumerable<data> lst);

    }

}