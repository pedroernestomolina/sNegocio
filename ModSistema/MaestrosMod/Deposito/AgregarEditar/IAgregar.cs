using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Deposito.AgregarEditar
{
    
    public interface IAgregar: IDepositoAgregarEditar
    {

        string IdItemRegistrado { get; }

    }

}