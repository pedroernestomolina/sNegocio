using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.TablaPrecio
{

    
    public interface ITablaPrecioAgregarEditar: IAgregarEditar
    {

        string GetNombre { get; }
        void setNombre(string p);

    }

}