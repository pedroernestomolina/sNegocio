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


        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public bool ProcesarIsOK { get { return _procesarIsOk; } }


        public CnfPos()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _maximoPorcDsctoPermitido = 0m;
            _permitirDsctoUnicamentoPagoDivisa = false;
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _maximoPorcDsctoPermitido = 0m;
            _permitirDsctoUnicamentoPagoDivisa = false;
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
                var fichaOOB = new OOB.LibSistema.Configuracion.Pos.Actualizar.Ficha()
                {
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
            _maximoPorcDsctoPermitido = r01.Entidad.valorMaximoDescuentoPermitido;
            _permitirDsctoUnicamentoPagoDivisa = r01.Entidad.permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa;

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


        public decimal GetDsctoMaximoPermitido { get { return _maximoPorcDsctoPermitido; } }
        public bool GetPermisoDsctoPagoDivisa { get { return _permitirDsctoUnicamentoPagoDivisa; } }

    }

}