using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{

    public interface ISucursalGrupo
    {

        OOB.ResultadoLista<OOB.LibSistema.SucursalGrupo.Entidad.Ficha> 
            SucursalGrupo_GetLista();
        OOB.ResultadoEntidad<OOB.LibSistema.SucursalGrupo.Entidad.Ficha> 
            SucursalGrupo_GetFicha(string auto);
        OOB.ResultadoAuto 
            SucursalGrupo_Agregar(OOB.LibSistema.SucursalGrupo.Agregar.Ficha ficha);
        OOB.Resultado
            SucursalGrupo_Editar(OOB.LibSistema.SucursalGrupo.Editar.Ficha ficha);
        OOB.Resultado
            SucursalGrupo_Eliminar(string id);

    }

}