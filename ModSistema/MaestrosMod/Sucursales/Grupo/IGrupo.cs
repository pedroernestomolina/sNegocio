using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.Grupo
{
    
    public interface IGrupo: IMaestroTipo
    {

        bool EliminarItemIsOk { get; }
        void EliminarItem();

        void Funcion_Sucursales();

    }

}