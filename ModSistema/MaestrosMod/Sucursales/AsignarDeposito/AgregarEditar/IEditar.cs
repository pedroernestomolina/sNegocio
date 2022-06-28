using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.AsignarDeposito.AgregarEditar
{

    public interface IEditar: IAsignarDepositoEditar 
    {

        void setIdItemEditar(string p);

    }

}