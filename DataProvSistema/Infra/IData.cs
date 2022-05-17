using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IData: IDeposito, ISucursal, IUsuario, IPrecioEtiqueta,
        IFuncion, IUsuarioGrupo, IServConf, IPermisos, IConfiguracion, IVendedor, ICobrador ,
        ISerieFiscal, IReconversionMonetaria, INegocio, IControlAcceso, IPrueba,
        ITablaPrecio, ISucursalGrupo

    {

        OOB.ResultadoEntidad<DateTime> FechaServidor();
        OOB.ResultadoEntidad<OOB.LibSistema.Empresa.Data.Ficha> Empresa_Datos();

    }

}