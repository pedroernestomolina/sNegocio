using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.MediosCobro.AgregarEditar
{
    
    public interface IAgregar: IMedioCobroAgregarEditar
    {

        string IdItemRegistrado { get; }

    }

}