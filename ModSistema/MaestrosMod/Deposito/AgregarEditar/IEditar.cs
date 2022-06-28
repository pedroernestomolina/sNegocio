using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Deposito.AgregarEditar
{
    
    public interface IEditar: IDepositoAgregarEditar
    {

        void setIdItemEditar(string _idEditar);

    }

}