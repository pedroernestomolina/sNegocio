using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IConfiguracion
    {

        OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> 
            Configuracion_ForzarRedondeoPrecioVenta();
        OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio> 
            Configuracion_PreferenciaRegistroPrecio();

        OOB.ResultadoEntidad<decimal> 
            Configuracion_TasaCambioActual();
        OOB.ResultadoEntidad<decimal> 
            Configuracion_TasaRecepcionPos();

        OOB.Resultado 
            Configuracion_Actualizar_TasaRecepcionPos(OOB.LibSistema.Configuracion.ActualizarTasaRecepcionPos.Ficha ficha);
        OOB.ResultadoLista<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha> 
            Configuracion_Actualizar_TasaDivisa_CapturarData();
        OOB.ResultadoLista<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.dataHndPrecio>
            Configuracion_Actualizar_TasaDivisa_CapturarData_HndPrecio();
        OOB.Resultado
            Configuracion_Actualizar_TasaDivisa_ActualizarData(OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.Ficha ficha);

        OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Modulo.Capturar.Ficha> 
            Configuracion_Modulo_Capturar();
        OOB.Resultado
            Configuracion_Modulo_Actualizar(OOB.LibSistema.Configuracion.Modulo.Actualizar.Ficha ficha);
        
        OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Pos.Capturar.Ficha> 
            Configuracion_Pos_Capturar();
        OOB.Resultado
            Configuracion_Pos_Actualizar(OOB.LibSistema.Configuracion.Pos.Actualizar.Ficha ficha);

    }

}