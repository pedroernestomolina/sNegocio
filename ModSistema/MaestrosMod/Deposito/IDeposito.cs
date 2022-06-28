using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Deposito
{
    
    public interface IDeposito: IMaestroTipo
    {

        void ActivarInactivar();
        bool ActivarInactivarIsOk { get; }

    }

}