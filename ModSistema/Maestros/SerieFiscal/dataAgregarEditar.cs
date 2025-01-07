using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros.SerieFiscal
{
    public class dataAgregarEditar
    {
        private string _serie; 
        private int _correlativo;
        private string _control;
        private bool _aplicaFactura;
        private bool _aplicaNtCredito;
        private bool _aplicaNtDebito;
        private bool _aplicaNtEntrega;
        private bool _aplicaLibroVenta;
        //
        public string Serie { get { return _serie; } }
        public int Correlativo { get { return _correlativo; } }
        public string Control { get { return _control; } }
        public bool Get_SwFactura { get { return _aplicaFactura; } }
        public bool Get_SwNtDebito { get { return _aplicaNtDebito; } }
        public bool Get_SwNtCredito { get { return _aplicaNtCredito; } }
        public bool Get_SwNtEntrega { get { return _aplicaNtEntrega; } }
        public bool Get_SwLibroVenta { get { return _aplicaLibroVenta; } }
        //
        public dataAgregarEditar() 
        {
            limpiar();
        }
        public void Inicializa()
        {
            limpiar();
        }
        private void limpiar()
        {
            _serie = "";
            _correlativo = 0;
            _control = "";
            _aplicaFactura = false;
            _aplicaNtDebito = false;
            _aplicaNtCredito = false;
            _aplicaNtEntrega = false;
            _aplicaLibroVenta = false;
        }
        public void setSerie(string p)
        {
            _serie= p;
        }
        public void setCorrelativo(int p)
        {
            _correlativo= p;
        }
        public void setControl (string p)
        {
            _control= p;
        }
        public bool VerificarAgregarIsOk()
        {
            var rt = true;
            if (_serie.Trim() == "") 
            {
                Helpers.Msg.Error("CAMPO SERIE NO PUEDE ESTAR VACIO");
                return false;
            }
            return rt;
        }
        public void CargarData(OOB.LibSistema.SerieFiscal.Entidad.Ficha ficha)
        {
            _serie = ficha.serie;
            _correlativo = ficha.correlativo;
            _control = ficha.control;
            _aplicaFactura = ficha.estatusFactura;
            _aplicaNtDebito = ficha.estatusNtDebito;
            _aplicaNtCredito= ficha.estatusNtCredito;
            _aplicaNtEntrega = ficha.estatusNtEntrega;
            _aplicaLibroVenta = ficha.estatusAplicaLibroVenta;
        }
        public bool VerificarEditarIsOk()
        {
            var rt = true;
            if (_serie.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO SERIE NO PUEDE ESTAR VACIO");
                return false;
            }
            return rt;
        }
        public void setFactura()
        {
            _aplicaFactura = !_aplicaFactura;
        }
        public void setNtDebito()
        {
            _aplicaNtDebito = !_aplicaNtDebito;
        }
        public void setNtCredito()
        {
            _aplicaNtCredito = !_aplicaNtCredito;
        }
        public void setNtEntrega()
        {
            _aplicaNtEntrega = !_aplicaNtEntrega;
        }
        public void setLibroVenta()
        {
            _aplicaLibroVenta = !_aplicaLibroVenta;
        }
    }
}