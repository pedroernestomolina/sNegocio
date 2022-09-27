using DataProvSistema.Infra;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<decimal> 
            Configuracion_TasaCambioActual()
        {
            var rt = new OOB.ResultadoEntidad<decimal>();

            var r01 = MyData.Configuracion_TasaCambioActual();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var cnf = r01.Entidad;
            var m1 = 0.0m;
            if (cnf.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                Decimal.TryParse(cnf, style, culture, out m1);
            }
            rt.Entidad = m1;

            return rt;
        }
        public OOB.ResultadoEntidad<decimal> 
            Configuracion_TasaRecepcionPos()
        {
            var rt = new OOB.ResultadoEntidad<decimal>();

            var r01 = MyData.Configuracion_TasaRecepcionPos();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var cnf = r01.Entidad;
            var m1 = 0.0m;
            if (cnf.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                Decimal.TryParse(cnf, style, culture, out m1);
            }
            rt.Entidad = m1;

            return rt;
        }
        public OOB.Resultado 
            Configuracion_Actualizar_TasaRecepcionPos(OOB.LibSistema.Configuracion.ActualizarTasaRecepcionPos.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Configuracion.ActualizarTasaRecepcionPos.Ficha()
            {
                 ValorNuevo=ficha.valorNuevo,
            };
            var r01 = MyData.Configuracion_Actualizar_TasaRecepcionPos(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha> 
            Configuracion_Actualizar_TasaDivisa_CapturarData()
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha>();

            var r01 = MyData.Configuracion_Actualizar_TasaDivisa_CapturarData ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha()
                        {
                            autoPrd = s.autoPrd,
                            contenido = s.contenido,
                            costoDivisa = s.costoDivisa,
                            costoMoneda = s.costoMoneda,
                            isAdmDivisa = s.isAdmDivisa,
                            precioFullDivisa_1 = s.precioFullDivisa_1,
                            precioFullDivisa_2 = s.precioFullDivisa_2,
                            precioFullDivisa_3 = s.precioFullDivisa_3,
                            precioFullDivisa_4 = s.precioFullDivisa_4,
                            precioFullDivisa_5 = s.precioFullDivisa_5,
                            precioFullDivisaMay_1 = s.precioFullDivisaMay_1,
                            precioFullDivisaMay_2 = s.precioFullDivisaMay_2,
                            precioFullDivisaMay_3 = s.precioFullDivisaMay_3,
                            precioFullDivisaMay_4 = s.precioFullDivisaMay_4,
                            precioNetoMoneda_1 = s.precioNetoMoneda_1,
                            precioNetoMoneda_2 = s.precioNetoMoneda_2,
                            precioNetoMoneda_3 = s.precioNetoMoneda_3,
                            precioNetoMoneda_4 = s.precioNetoMoneda_4,
                            precioNetoMoneda_5 = s.precioNetoMoneda_5,
                            precioNetoMonedaMay_1 = s.precioNetoMonedaMay_1,
                            precioNetoMonedaMay_2 = s.precioNetoMonedaMay_2,
                            precioNetoMonedaMay_3 = s.precioNetoMonedaMay_3,
                            precioNetoMonedaMay_4 = s.precioNetoMonedaMay_4,
                            //
                            precioNetoMonedaDsp_1 = s.precioNetoMonedaDsp_1,
                            precioNetoMonedaDsp_2 = s.precioNetoMonedaDsp_2,
                            precioNetoMonedaDsp_3 = s.precioNetoMonedaDsp_3,
                            precioNetoMonedaDsp_4 = s.precioNetoMonedaDsp_4,
                            precioFullDivisaDsp_1 = s.precioFullDivisaDsp_1,
                            precioFullDivisaDsp_2 = s.precioFullDivisaDsp_2,
                            precioFullDivisaDsp_3 = s.precioFullDivisaDsp_3,
                            precioFullDivisaDsp_4 = s.precioFullDivisaDsp_4,
                            //
                            tasaIva = s.tasaIva,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.dataHndPrecio>
            Configuracion_Actualizar_TasaDivisa_CapturarData_HndPrecio()
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.dataHndPrecio>();

            var r01 = MyData.Configuracion_Actualizar_TasaDivisa_CapturarData_HndPrecio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.dataHndPrecio>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.dataHndPrecio()
                        {
                            autoProducto = s.autoProducto,
                            cont_1 = s.cont_1,
                            cont_2 = s.cont_2,
                            cont_3 = s.cont_3,
                            estatusDivisa = s.estatusDivisa,
                            fullDivisa_1 = s.fullDivisa_1,
                            fullDivisa_2 = s.fullDivisa_2,
                            fullDivisa_3 = s.fullDivisa_3,
                            idPrecio = s.idPrecio,
                            neto_1 = s.neto_1,
                            neto_2 = s.neto_2,
                            neto_3 = s.neto_3,
                            tasaIva = s.tasaIva,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;

            return rt;
        }
        public OOB.Resultado 
            Configuracion_Actualizar_TasaDivisa_ActualizarData(OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.Ficha()
            {
                autoUsuario = ficha.autoUsuario,
                codigoUsuario = ficha.codigoUsuario,
                EstacionEquipo = ficha.EstacionEquipo,
                nombreUsuario = ficha.nombreUsuario,
                ValorDivisa = ficha.ValorDivisa,
            };

            var lstProdCostoSinDivisa = new List<DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoCostoSinDivisa>();
            foreach (var rg in ficha.productosCostoSinDivisa)
            {
                var nr = new DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoCostoSinDivisa()
                {
                    autoPrd = rg.autoPrd,
                    costoDivisa = rg.costoDivisa,
                    precioMonedaEnDivisaFull_1 = rg.precioMonedaEnDivisaFull_1,
                    precioMonedaEnDivisaFull_2 = rg.precioMonedaEnDivisaFull_2,
                    precioMonedaEnDivisaFull_3 = rg.precioMonedaEnDivisaFull_3,
                    precioMonedaEnDivisaFull_4 = rg.precioMonedaEnDivisaFull_4,
                    precioMonedaEnDivisaFull_5 = rg.precioMonedaEnDivisaFull_5,
                    precioMonedaEnDivisaFull_May_1 = rg.precioMonedaEnDivisaFull_May_1,
                    precioMonedaEnDivisaFull_May_2 = rg.precioMonedaEnDivisaFull_May_2,
                    precioMonedaEnDivisaFull_May_3 = rg.precioMonedaEnDivisaFull_May_3,
                    precioMonedaEnDivisaFull_May_4 = rg.precioMonedaEnDivisaFull_May_4,
                    precioMonedaEnDivisaFull_Dsp_1 = rg.precioMonedaEnDivisaFull_Dsp_1,
                    precioMonedaEnDivisaFull_Dsp_2 = rg.precioMonedaEnDivisaFull_Dsp_2,
                    precioMonedaEnDivisaFull_Dsp_3 = rg.precioMonedaEnDivisaFull_Dsp_3,
                    precioMonedaEnDivisaFull_Dsp_4 = rg.precioMonedaEnDivisaFull_Dsp_4,
                };
                lstProdCostoSinDivisa.Add(nr);
            }
            fichaDTO.productosCostoSinDivisa = lstProdCostoSinDivisa;

            var lstProdDivisaCostoPrecio = new List<DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoCostoPrecioDivisa>();
            foreach (var rg in ficha.productosCostoPrecioDivisa)
            {
                var nr = new DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoCostoPrecioDivisa()
                {
                    autoPrd = rg.autoPrd,
                    costo = rg.costo,
                    costoDivisa = rg.costoDivisa,
                    costoImportacion = rg.costoImportacion,
                    costoImportacionUnd = rg.costoImportacionUnd,
                    costoProveedor = rg.costoProveedor,
                    costoProveedorUnd = rg.costoProveedorUnd,
                    costoUnd = rg.costoUnd,
                    costoVario = rg.costoVario,
                    costoVarioUnd = rg.costoVarioUnd,
                    documento = rg.documento,
                    nota = rg.nota,
                    precio_1 = rg.precio_1,
                    precio_2 = rg.precio_2,
                    precio_3 = rg.precio_3,
                    precio_4 = rg.precio_4,
                    precio_5 = rg.precio_5,
                    precioMay_1 = rg.precioMay_1,
                    precioMay_2 = rg.precioMay_2,
                    precioMay_3 = rg.precioMay_3,
                    precioMay_4 = rg.precioMay_4,
                    precioDsp_1 = rg.precioDsp_1,
                    precioDsp_2 = rg.precioDsp_2,
                    precioDsp_3 = rg.precioDsp_3,
                    precioDsp_4 = rg.precioDsp_4,
                    serie = rg.serie,
                };
                lstProdDivisaCostoPrecio.Add(nr);
            }
            fichaDTO.productosCostoPrecioDivisa = lstProdDivisaCostoPrecio;

            var lstProdPrecioHistorico = new List<DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoPrecioHistorico>();
            foreach (var rg in ficha.productosPrecioHistorico)
            {
                var nr = new DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoPrecioHistorico()
                {
                    autoPrd = rg.autoPrd,
                    idPrecio = rg.idPrecio,
                    nota = rg.nota,
                    precio = rg.precio,
                };
                lstProdPrecioHistorico.Add(nr);
            }
            fichaDTO.productosPrecioHistorico = lstProdPrecioHistorico;


            var lstHndPrecio = new List<DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaHndPrecio>(); 
            foreach (var rg in ficha.productosHndPrecio)
            {
                var nr = new DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaHndPrecio()
                {
                    autoProducto = rg.autoProducto,
                    esAdmDivisa = rg.esAdmDivisa,
                    fullDivisa_1 = rg.fullDivisa_1,
                    fullDivisa_2 = rg.fullDivisa_2,
                    fullDivisa_3 = rg.fullDivisa_3,
                    idPrecio = rg.idPrecio,
                    neto_1 = rg.neto_1,
                    neto_2 = rg.neto_2,
                    neto_3 = rg.neto_3,
                };
                lstHndPrecio.Add(nr);
            }
            fichaDTO.productosHndPrecio = lstHndPrecio;

            var r01 = MyData.Configuracion_Actualizar_TasaDivisa_ActualizarData(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> 
            Configuracion_ForzarRedondeoPrecioVenta()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta>();

            var r01 = MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta)s;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio> 
            Configuracion_PreferenciaRegistroPrecio()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio>();

            var r01 = MyData.Configuracion_PreferenciaRegistroPrecio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio)s;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Modulo.Capturar.Ficha> 
            Configuracion_Modulo_Capturar()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Modulo.Capturar.Ficha>(); 

            var r01 = MyData.Configuracion_Modulo_Capturar();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var f= r01.Entidad;
            var cnt = 1000;
            if (f.cantDocVisualizar.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                int.TryParse(f.cantDocVisualizar, style, culture, out cnt);
            }

            rt.Entidad = new OOB.LibSistema.Configuracion.Modulo.Capturar.Ficha()
            {
                claveNivMaximo = f.claveNivMaximo,
                claveNivMedio = f.claveNivMedio,
                claveNivMinimo = f.claveNivMinimo,
                visualizarPrdInactivos = f.visualizarPrdInactivos.Trim().ToUpper() == "SI" ? true : false,
                cantDocVisualizar = cnt,
            };

            return rt;
        }
        public OOB.Resultado 
            Configuracion_Modulo_Actualizar(OOB.LibSistema.Configuracion.Modulo.Actualizar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Configuracion.Modulo.Actualizar.Ficha()
            {
                claveNivMaximo = ficha.claveNivMaximo,
                claveNivMedio = ficha.claveNivMedio,
                claveNivMinimo = ficha.claveNivMinimo,
                visualizarPrdInactivos = ficha.visualizarPrdInactivos,
                cantDocVisualizar = ficha.cantDocVisualizar,
            };
            var r01 = MyData.Configuracion_Modulo_Actualizar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Pos.Capturar.Ficha> 
            Configuracion_Pos_Capturar()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Pos.Capturar.Ficha>();

            var r01 = MyData.Configuracion_Pos_Capturar();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var f = r01.Entidad;
            var mont = 0m;
            if (f.valorMaximoDescuentoPermitido.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                decimal.TryParse(f.valorMaximoDescuentoPermitido, style, culture, out mont);
            }
            var tasaDivSist=0m;
            if (f.tasaManejoDivisaSist.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                decimal.TryParse(f.tasaManejoDivisaSist, style, culture, out tasaDivSist);
            }
            var tasaDivPos = 0m;
            if (f.tasaManejoDivisaPos.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                decimal.TryParse(f.tasaManejoDivisaPos, style, culture, out tasaDivPos);
            }
            rt.Entidad = new OOB.LibSistema.Configuracion.Pos.Capturar.Ficha()
            {
                tasaManejoDivisaSist = tasaDivSist,
                tasaManejoDivisaPos = tasaDivPos,
                valorMaximoDescuentoPermitido = mont,
                permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa = f.permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa.Trim().ToUpper() == "SI" ? true : false,
            };

            return rt;
        }
        public OOB.Resultado 
            Configuracion_Pos_Actualizar(OOB.LibSistema.Configuracion.Pos.Actualizar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Configuracion.Pos.Actualizar.Ficha()
            {
                tasaRecepcionPos = ficha.tasaManejoDivisaPos.ToString(),
                valorMaximoDescuentoPermitido = ficha.valorMaximoDescuentoPermitido.ToString(),
                permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa = ficha.permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa ? "Si" : "No",
            };
            var r01 = MyData.Configuracion_Pos_Actualizar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}