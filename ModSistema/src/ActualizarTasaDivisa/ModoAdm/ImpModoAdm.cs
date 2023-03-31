using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.src.ActualizarTasaDivisa.ModoAdm
{
    public class ImpModoAdm: IModoAdm
    {
        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private decimal _tasaDivisaActual;
        private decimal _tasaDivisaNueva;


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _tasaDivisaActual = 0m;
            _tasaDivisaNueva = 0m;
        }
        private Frm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }

        public bool ProcesarIsOK { get { return _procesarIsOk; } }
        public void Procesar()
        {
            _procesarIsOk = false;
            if (_tasaDivisaNueva > 0)
            {
                var msg = MessageBox.Show("Actualizar Tasa Divisa Actual ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    ProcesarCambios();
                }
            }
        }


        public string Get_TituloFuncion { get { return "Tasa Divisa Actual ?"; } }
        public decimal Get_TasaDivisaValorActual { get { return _tasaDivisaActual; } }
        public decimal Get_TasaDivisaValorNuevo { get { return _tasaDivisaNueva; } }
        public void setTasaDivisa(decimal monto)        
        {
            _tasaDivisaNueva = monto;
        }


        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Configuracion_TasaCambioActual();
                _tasaDivisaActual = r01.Entidad;
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void ProcesarCambios()
        {
            try
            {
                var r01 = Sistema.MyData.AjustarTasaDivisa_ModoAdm_CapturarData();
                var r02 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta();
                if (r02.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(r02.Mensaje);
                }
                var r03 = Sistema.MyData.Configuracion_PreferenciaRegistroPrecio();
                if (r03.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r03.Mensaje);
                }

                var ficha = new OOB.LibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.Ficha()
                {
                    TasaDivisaNueva = _tasaDivisaNueva,
                    estacion = Environment.MachineName,
                    nota = "CAMBIO MASIVO TASA DIVISA: " + _tasaDivisaNueva.ToString("n2"),
                    usuCodigo = Sistema.UsuarioP.codigo,
                    usuNombre = Sistema.UsuarioP.nombre,

                    noAdmDivisa = new OOB.LibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.NoAdmDivisa()
                    {
                        prd = r01.Lista.
                             GroupBy(g => new { autoPrd = g.autoPrd, descPrd = g.descPrd, costo = g.costoMonLocalEmpCompra, estatusDivisa = g.estatusDivisa }).
                             Where(w => w.Key.estatusDivisa.Trim().ToUpper() != "1").
                             Select(s =>
                             {
                                 var nr = new OOB.LibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.PrdNoAdmDivisa()
                                 {
                                     autoprd = s.Key.autoPrd,
                                     costoDivisa = ConvDivisa(s.Key.costo, _tasaDivisaNueva),
                                     descPrd = s.Key.descPrd,
                                 };
                                 return nr;
                             }).ToList(),
                        precio = r01.Lista.
                             Where(w => w.estatusDivisa.Trim().ToUpper() != "1").
                             Select(s =>
                             {
                                 var nr = new OOB.LibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.PrecioNoAdmDivisa()
                                 {
                                     descPrd = s.descPrd,
                                     idPrecioVta = s.idPrecioVta,
                                     pDivisaFull = ConvDivisa(Full(s.pNetoMonLocalEmpVta, s.tasaIva), _tasaDivisaNueva),
                                 };
                                 return nr;
                             }).ToList(),
                    },

                    siAdmDivisa = new OOB.LibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.SiAdmDivisa()
                    {
                        prd = r01.Lista.
                             GroupBy(g => new { autoPrd = g.autoPrd, descPrd = g.descPrd, costo = g.costoDivisaEmpCompra, estatusDivisa = g.estatusDivisa, contEmpCompra = g.contEmpCompra }).
                             Where(w => w.Key.estatusDivisa.Trim().ToUpper() == "1").
                             Select(s =>
                             {
                                 var _costo = ConvMonLocal(s.Key.costo, _tasaDivisaNueva);
                                 var _costoUnd = Math.Round((_costo / s.Key.contEmpCompra), 2, MidpointRounding.AwayFromZero);

                                 var nr = new OOB.LibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.PrdSiAdmDivisa()
                                 {
                                     autoprd = s.Key.autoPrd,
                                     descPrd = s.Key.descPrd,
                                     costo = _costo,
                                     costoImp = 0m,
                                     costoImpUnd = 0m,
                                     costoProv = _costo,
                                     costoProvUnd = _costoUnd,
                                     costoUnd = _costoUnd,
                                     costoVario = 0m,
                                     costoVarioUnd = 0m,
                                 };
                                 return nr;
                             }).ToList(),
                        precio = r01.Lista.
                             Where(w => w.estatusDivisa.Trim().ToUpper() == "1").
                             Select(s =>
                             {
                                 var nr = new OOB.LibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.PrecioSiAdmDivisa()
                                 {
                                     descPrd = s.descPrd,
                                     idPrecioVta = s.idPrecioVta,
                                     pnetoMonLocal = ConvMonLocal(Neto(s.pFullDivisaEmpVta, s.tasaIva), _tasaDivisaNueva),
                                 };
                                 return nr;
                             }).ToList(),
                        historia = r01.Lista.
                             Where(w => w.estatusDivisa.Trim().ToUpper() == "1").
                             Select(s =>
                             {
                                 var nr = new OOB.LibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.Historia()
                                 {
                                     autoPrd = s.autoPrd,
                                     empCont = s.contEmpVta,
                                     empDesc = s.descEmpVta,
                                     fullDivisa = s.pFullDivisaEmpVta,
                                     netoMonLocal = s.pNetoMonLocalEmpVta,
                                     prdCodigo = s.codigoPrd,
                                     prdDesc = s.descPrd,
                                     tipoEmpaqueVenta = s.tipoEmpVta,
                                     tipoPrecioVenta = "1",
                                 };
                                 return nr;
                             }).ToList(),
                    },
                };
                var r04 = Sistema.MyData.AjustarTasaDivisa_ModoAdm_Ajustar(ficha);
                _procesarIsOk = true;
                Helpers.Msg.OK();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private decimal ConvMonLocal(decimal monto, decimal _tasaDivisaNueva)
        {
            var m = monto;
            m *= _tasaDivisaNueva;
            return m;
        }

        private decimal Neto(decimal monto, decimal tasaIva)
        {
            var m = monto;
            if (tasaIva > 0m) 
            {
                var f = 1 + (tasaIva / 100m);
                m /= f;
                m = Math.Round(m, 2, MidpointRounding.AwayFromZero);
            }
            return m;
        }
        private decimal Full(decimal neto, decimal tasaIva)
        {
            var m = neto;
            if (tasaIva > 0m)
            {
                m += (m * tasaIva / 100) ;
            }
            m = Math.Round(m, 2, MidpointRounding.AwayFromZero);
            return m;
        }
        private decimal ConvDivisa (decimal costoMonLocal, decimal _tasaDivisaNueva)
        {
            var m = 0m;
            if (_tasaDivisaNueva > 0m) 
            {
                m = costoMonLocal / _tasaDivisaNueva;
            }
            m = Math.Round(m, 2, MidpointRounding.AwayFromZero);
            return m;
        }
    }
}