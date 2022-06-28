using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Grupo
{


    public interface IGrupoAgregarEditar : IMaestroAgregarEditar
    {

        BindingSource PrecioSource { get;  }
        string GetPrecioId { get;  }
        void SetPrecio(string id);

        string GetNombre { get; }
        void setNombre(string p);

    }

}