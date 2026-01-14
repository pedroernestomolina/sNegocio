using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModSistema.MaestrosMod.MediosCobro.AgregarEditar.vm
{
    public interface IAgregar: IAgregarEditar
    {
        OOB.LibSistema.MediosCobroPago.Entidad.Ficha GetItemRegistrado { get; }
    }
}