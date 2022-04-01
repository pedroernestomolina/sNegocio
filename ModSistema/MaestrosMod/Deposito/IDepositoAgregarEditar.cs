using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Deposito
{


    public interface IDepositoAgregarEditar : IAgregarEditar
    {

        BindingSource SucursalSource { get; }
        string GetSucursalId { get; }
        void setSucursal(string id);

        void setNombre(string p);
        string GetNombre { get;  }

    }

}