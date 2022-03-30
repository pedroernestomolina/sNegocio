using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.TablaPrecio
{

    
    public interface IAgregarEditar: IGestion
    {

        bool IsOk { get;  }
        data DataAgregar { get;  }

    }

}