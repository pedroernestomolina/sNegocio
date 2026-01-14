using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModSistema.MaestrosMod.MediosCobro.AgregarEditar.vm
{
    public interface IEditar:IAgregarEditar
    {
        OOB.LibSistema.MediosCobroPago.Entidad.Ficha GetItemRegistrado { get; }
        //
        void setIdItemEditar(string _idEditar);
    }
}