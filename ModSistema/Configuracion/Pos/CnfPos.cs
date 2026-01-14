using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Configuracion.Pos
{
    public class CnfPos: ICnfPos
    {
        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private decimal _maximoPorcDsctoPermitido;
        private bool _permitirDsctoUnicamentoPagoDivisa;
        private decimal _tasaManejoDivSist;
        private decimal _tasaManejoDivPos;
        private decimal _difPorct;
        private decimal _porcAumentoPreciosPosPrdNoAdmPorDivisa;
        //
        private Models.ActualizarTasaPos _modeloTasaPos;
        private UseCase.ProcesarCambio _ucProcesarCambio;
        private UseCase.CapturarDataAjustar _ucCapturarDataAjustar;
        private UseCase.CapturarModoCalculoPrecioProductosNacionales _ucCapturaModoCalculoPrecioPrdNac;
        //
        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public bool ProcesarIsOK { get { return _procesarIsOk; } }
        //
        public CnfPos()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _maximoPorcDsctoPermitido = 0m;
            _permitirDsctoUnicamentoPagoDivisa = false;
            _tasaManejoDivPos = 0m;
            _tasaManejoDivSist = 0m;
            _difPorct = 0m;
            //
            _modeloTasaPos = new Models.ActualizarTasaPos();
            _ucProcesarCambio = new UseCase.ProcesarCambio();
            _ucCapturarDataAjustar = new UseCase.CapturarDataAjustar();
            _ucCapturaModoCalculoPrecioPrdNac = new UseCase.CapturarModoCalculoPrecioProductosNacionales();
        }
        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _maximoPorcDsctoPermitido = 0m;
            _permitirDsctoUnicamentoPagoDivisa = false;
            _tasaManejoDivPos = 0m;
            _tasaManejoDivSist = 0m;
            _difPorct = 0m;
            _modoCalculoDifTasa = "";
            _porcAumentoPreciosPosPrdNoAdmPorDivisa = 0m;
            //
            _modeloTasaPos.Inicializa();
        }
        private CnfPosFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new CnfPosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }
        public void Procesar()
        {
            _procesarIsOk = false;
            if (Helpers.Msg.Procesar())
            {
                try
                {
                    if (_tasaManejoDivPos <= 0m)
                    {
                        var msg = "TASA RECEPCION POS DEBE SER MAYOR A CERO(0)";
                        throw new Exception(msg);
                    }
                    if (_permitirDsctoUnicamentoPagoDivisa && _maximoPorcDsctoPermitido <= 0m)
                    {
                        var msg = "TASA/BONO PARA PAGO CON DIVISA DEBE SER MAYOR A CERO(0)";
                        throw new Exception(msg);
                    }
                    var rst = Sistema.MyData.Configuracion_MonedaLocal();
                    if (rst.Result == OOB.Enumerados.EnumResult.isError) 
                    {
                        throw new Exception(rst.Mensaje);
                    }
                    if (_modeloTasaPos.GetMonedaReferencia == null)
                    {
                        throw new Exception("MONEDA REFERENCIA NO DEFINIDA");
                    }
                    //
                    if (1 == 1)
                    {
                        _modeloTasaPos.setDesctoPermitir(_maximoPorcDsctoPermitido);
                        _modeloTasaPos.setTasaPosNueva(_tasaManejoDivPos);
                        _modeloTasaPos.setAceptarDsctoPorPagoDivisa(_permitirDsctoUnicamentoPagoDivisa);
                        _modeloTasaPos.setPorcAumentoPreciosPrdNoAdmDivisa(_porcAumentoPreciosPosPrdNoAdmPorDivisa);
                        _modeloTasaPos.setPorctDiferenciaTasaSistemaTasaPos(_difPorct);
                        _ucCapturarDataAjustar.Execute(_modeloTasaPos);
                    }
                    _modeloTasaPos.setIdMonLocal(rst.Entidad.id);
                    _ucProcesarCambio.Execute(_modeloTasaPos);
                    _procesarIsOk = true;
                    Helpers.Msg.OK();
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }


        private string _modoCalculoDifTasa;
        private bool CargarData()
        {
            try
            {
                var r00 = Sistema.MyData.Configuracion_CalculoDiferenciaEnreTasas();
                if (r00.Entidad == DataProvSistema.Enumerados.modoCalculoDiferenciaEntreTasas.BCV)
                {
                    _modoCalculoDifTasa = "BCV";
                }
                var r01 = Sistema.MyData.Configuracion_Pos_Capturar();
                var _modoCalculoPrecioPrdNac = _ucCapturaModoCalculoPrecioPrdNac.Execute();
                //
                var rst = Sistema.MyData.Configuracion_MonedaReferencia();
                if (rst.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rst.Mensaje);
                }
                _modeloTasaPos.setMonedaReferencia(rst.Entidad);
                //
                _tasaManejoDivSist = r01.Entidad.tasaManejoDivisaSist;
                _tasaManejoDivPos = r01.Entidad.tasaManejoDivisaPos;
                _maximoPorcDsctoPermitido = r01.Entidad.valorMaximoDescuentoPermitido;
                _permitirDsctoUnicamentoPagoDivisa = r01.Entidad.permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa;
                _porcAumentoPreciosPosPrdNoAdmPorDivisa = r01.Entidad.porcAumentoEnPreciosProductosNoAdmPorDivisa;
                setTasaPos(_tasaManejoDivPos);
                //
                _modeloTasaPos.setTasaPosActual(r01.Entidad.tasaManejoDivisaPos);
                _modeloTasaPos.setTasaDivisa(r01.Entidad.tasaManejoDivisaSist);
                _modeloTasaPos.setPorctDifEntreTasas(r01.Entidad.valorMaximoDescuentoPermitido);
                _modeloTasaPos.setAplicarFormulaCalculoPrecio(_modoCalculoPrecioPrdNac);
                _modeloTasaPos.setPorcAumentoPreciosPrdNoAdmDivisa(_porcAumentoPreciosPosPrdNoAdmPorDivisa);
                //
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        public void setMaximoDscto(decimal dscto)
        {
            _maximoPorcDsctoPermitido = dscto;
        }
        public void setHabilitarDsctoPagoDivisa(bool permiso)
        {
            _permitirDsctoUnicamentoPagoDivisa = permiso;
        }
        public void setTasaPos(decimal tasaPos)
        {
            _difPorct = 0m;
            _tasaManejoDivPos = tasaPos;
            if (_tasaManejoDivSist > 0) {
                if (_modoCalculoDifTasa == "BCV")
                {
                    _difPorct = ((_tasaManejoDivSist / _tasaManejoDivPos) ) * 100m;
                }
                else
                {
                    _difPorct = (1 - (_tasaManejoDivPos / _tasaManejoDivSist)) * 100;
                }

                var _tasaBono = ((1m - (tasaPos / _tasaManejoDivSist)) * 100m);
                _tasaBono = Math.Round(_tasaBono, 4, MidpointRounding.AwayFromZero);
                setMaximoDscto(_tasaBono);
            }
        }
        public void setPorcAumentoPrecioNoAdmDivisa(decimal porc)
        {
            _porcAumentoPreciosPosPrdNoAdmPorDivisa = porc;
        }

        public decimal GetDsctoMaximoPermitido { get { return _maximoPorcDsctoPermitido; } }
        public bool GetPermisoDsctoPagoDivisa { get { return _permitirDsctoUnicamentoPagoDivisa; } }
        public decimal GetTasaManejoDivSist { get { return _tasaManejoDivSist; } }
        public decimal GetTasaManejoDivPos { get { return _tasaManejoDivPos; } }
        public decimal GetDiferenciaPorct { get { return _difPorct; } }
        public decimal GetPorcAumentoPrecioPosNoAdmDivisa { get { return _porcAumentoPreciosPosPrdNoAdmPorDivisa; } }
    }
}