using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Sucursal
{


    public interface ISucursalAgregarEditar : IAgregarEditar
    {

        BindingSource GrupoSource { get;  }
        string GetGrupoId { get;  }
        void SetGrupo(string id);

        string GetNombre { get; }
        void setNombre(string p);
        void setFactMayor(bool p);
        bool GetFactMayor { get; }

        bool GetFactCredito { get; }
        void setVentaCredito(bool p);

    }

}