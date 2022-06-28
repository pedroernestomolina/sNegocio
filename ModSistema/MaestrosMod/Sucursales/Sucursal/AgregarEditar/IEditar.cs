using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.Sucursal.AgregarEditar
{
    
    public interface IEditar: ISucursalAgregarEditar
    {

        void setIdItemEditar(string _idEditar);

    }

}