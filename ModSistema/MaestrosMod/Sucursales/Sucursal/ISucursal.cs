using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.Sucursal
{
    
    public interface ISucursal: IMaestroTipo
    {

        void ActivarInactivar();
        bool ActivarInactivarIsOk { get; }


        void Funcion_Depositos();
    }

}