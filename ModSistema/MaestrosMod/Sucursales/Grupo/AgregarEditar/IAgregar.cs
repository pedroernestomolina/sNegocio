using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.Grupo.AgregarEditar
{
    
    public interface IAgregar: IGrupoAgregarEditar
    {

        string IdItemRegistrado { get; }

    }

}