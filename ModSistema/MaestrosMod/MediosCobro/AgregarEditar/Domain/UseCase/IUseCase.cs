using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.MediosCobro.AgregarEditar.Domain.UseCase
{
    public interface IUseCase
    {
        OOB.LibSistema.MediosCobroPago.Entidad.Ficha
            AgregarMedioPago(OOB.LibSistema.MediosCobroPago.Agregar.Ficha ficha);
        OOB.LibSistema.MediosCobroPago.Entidad.Ficha
            CargarMedioPago(string id);
        OOB.LibSistema.MediosCobroPago.Entidad.Ficha
            EditarMedioPago(OOB.LibSistema.MediosCobroPago.Editar.Ficha ficha);
        List<OOB.LibSistema.Moneda.Entidad.Ficha>
            CargarMonedas();
    }
}