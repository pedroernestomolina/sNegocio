using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.AsignarDeposito
{


    public interface IAsignarDepositoEditar : IMaestroAgregarEditar
    {

        BindingSource DepositoSource { get;  }
        string GetDepositoId { get;  }
        void SetDeposito(string id);
        string GetSucursal { get; }

    }

}