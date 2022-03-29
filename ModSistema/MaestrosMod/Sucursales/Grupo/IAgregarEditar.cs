using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Grupo
{

    
    public interface IAgregarEditar: IGestion
    {

        bool IsOk { get; }
        data DataAgregar { get; }

        string Titulo { get; }

        BindingSource PrecioSource { get;  }
        string GetPrecioId { get;  }
        string GetNombre { get; }

        void setNombre(string p);
        void SetPrecio(string id);

        void Procesar();
        bool ProcesarIsOk { get; }

        void Abandonar();
        bool AbandonarIsOk { get; }


    }

}