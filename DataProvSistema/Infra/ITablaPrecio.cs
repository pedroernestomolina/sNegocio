using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{


    public interface ITablaPrecio
    {

        OOB.ResultadoId
            TablaPrecio_Agregar(OOB.LibSistema.TablaPrecio.Agregar.Ficha ficha);
        OOB.Resultado
            TablaPrecio_Editar(OOB.LibSistema.TablaPrecio.Editar.Ficha ficha);
        OOB.ResultadoEntidad<OOB.LibSistema.TablaPrecio.Entidad.Ficha>
            TablaPrecio_GetById(int id);
        OOB.ResultadoLista<OOB.LibSistema.TablaPrecio.Entidad.Ficha>
            TablaPrecio_GetLista();

    }

}