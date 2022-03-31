using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface ISucursal
    {

        OOB.ResultadoLista<OOB.LibSistema.Sucursal.Entidad.Ficha> 
            Sucursal_GetLista(OOB.LibSistema.Sucursal.Lista.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibSistema.Sucursal.Entidad.Ficha> 
            Sucursal_GetFicha(string auto);
        OOB.ResultadoAuto 
            Sucursal_Agregar(OOB.LibSistema.Sucursal.Agregar.Ficha ficha);
        OOB.Resultado 
            Sucursal_Editar(OOB.LibSistema.Sucursal.Editar.Ficha ficha);
        OOB.Resultado 
            Sucursal_AsignarDepositoPrincipal(OOB.LibSistema.Sucursal.AsignarDepositoPrincipal.Ficha ficha);
        OOB.Resultado 
            Sucursal_QuitarDepositoPrincipal(string autoSuc);

    }

}