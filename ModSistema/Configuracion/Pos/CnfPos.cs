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


        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public bool ProcesarIsOK { get { return _procesarIsOk; } }


        public CnfPos()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _maximoPorcDsctoPermitido = 0m;
            _permitirDsctoUnicamentoPagoDivisa = false;
            _tasaManejoDivPos = 0m;
            _tasaManejoDivSist = 0m;
            _difPorct = 0m;
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
                if (_tasaManejoDivPos <=0m)
                {
                    var msg = "TASA RECEPCION POS DEBE SER MAYOR A CERO(0)";
                    Helpers.Msg.Alerta(msg);
                    return;
                }
                if (_permitirDsctoUnicamentoPagoDivisa && _maximoPorcDsctoPermitido <= 0m)
                {
                    var msg = "TASA/BONO PARA PAGO CON DIVISA DEBE SER MAYOR A CERO(0)";
                    Helpers.Msg.Alerta(msg);
                    return;
                }
                var fichaOOB = new OOB.LibSistema.Configuracion.Pos.Actualizar.Ficha()
                {
                    tasaManejoDivisaPos= _tasaManejoDivPos,
                    permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa = _permitirDsctoUnicamentoPagoDivisa,
                    valorMaximoDescuentoPermitido = _maximoPorcDsctoPermitido,
                };
                var r01 = Sistema.MyData.Configuracion_Pos_Actualizar(fichaOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Helpers.Msg.OK();
                _procesarIsOk = true;
            }
        }


        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_Pos_Capturar();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _tasaManejoDivSist = r01.Entidad.tasaManejoDivisaSist;
            _tasaManejoDivPos = r01.Entidad.tasaManejoDivisaPos;
            _maximoPorcDsctoPermitido = r01.Entidad.valorMaximoDescuentoPermitido;
            _permitirDsctoUnicamentoPagoDivisa = r01.Entidad.permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa;
            setTasaPos(_tasaManejoDivPos);

            return rt;
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
                _difPorct = (1 - (_tasaManejoDivPos / _tasaManejoDivSist)) * 100;
            }
        }


        public decimal GetDsctoMaximoPermitido { get { return _maximoPorcDsctoPermitido; } }
        public bool GetPermisoDsctoPagoDivisa { get { return _permitirDsctoUnicamentoPagoDivisa; } }
        public decimal GetTasaManejoDivSist { get { return _tasaManejoDivSist; } }
        public decimal GetTasaManejoDivPos { get { return _tasaManejoDivPos; } }
        public decimal GetDiferenciaPorct { get { return _difPorct; } }

    }

}