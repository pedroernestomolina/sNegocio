using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IMediosCobroPago
    {

        OOB.ResultadoLista<OOB.LibSistema.MediosCobroPago.Entidad.Ficha>
            MediosCobroPago_GetLista(OOB.LibSistema.MediosCobroPago.Lista.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibSistema.MediosCobroPago.Entidad.Ficha>
            MediosCobroPago_GetFicha_ById(string id);
        OOB.ResultadoAuto
            MediosCobroPago_AgregarFicha(OOB.LibSistema.MediosCobroPago.Agregar.Ficha ficha);
        OOB.Resultado
            MediosCobroPago_EditarFicha(OOB.LibSistema.MediosCobroPago.Editar.Ficha ficha);

    }

}