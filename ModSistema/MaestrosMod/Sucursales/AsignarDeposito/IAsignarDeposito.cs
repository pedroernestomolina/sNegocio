using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.AsignarDeposito
{
    
    public interface IAsignarDeposito: IMaestroTipo
    {

        bool EliminarItemIsOk { get; }
        void EliminarItem();

    }

}