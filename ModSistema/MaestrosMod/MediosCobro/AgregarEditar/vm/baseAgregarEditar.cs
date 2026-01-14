using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModSistema.MaestrosMod.MediosCobro.AgregarEditar.vm
{
    public abstract class baseAgregarEditar: IAgregarEditar
    {
        private LibUtilitis.Herramimentas.Botones.IBtAbandonar _btAbandonar;
        private LibUtilitis.Herramimentas.Botones.IBtProcesar _btProcesar;
        private LibUtilitis.Opcion.IOpcion _monedas;
        private Domain.Models.MiModelo _miModelo;
        private Domain.UseCase.IUseCase _uc;
        //
        public Domain.Models.MiModelo MiModelo { get { return _miModelo; } }
        public LibUtilitis.Herramimentas.Botones.IBtProcesar BtProcesar { get { return _btProcesar; } }
        public Domain.UseCase.IUseCase UC { get { return _uc; } }
        public LibUtilitis.Opcion.IOpcion CtrlMonedas { get { return _monedas; } }
        //
        public string GetNombre { get { return _miModelo.GetNombreMedioPago; } }
        public string GetCodigo { get { return _miModelo.GetCodigoMedioPago; } }
        public bool GetEstatusCobranza { get { return _miModelo.GetAplicaParaCobranza; ;} }
        public bool GetEstatusPago { get { return _miModelo.GetAplicaParaPago; } }
        public bool GetAplicaLoteReferencia { get { return _miModelo.GetAplicaLoteRef; } }
        public bool GetAplicaModuloCobroAnticipo { get { return _miModelo.GetAplicaModuloCobroAnticipo; } }
        public bool GetAplicaParaBonoPagoDivisa { get { return _miModelo.GetAplicaBonoPagoDivisa; } }
        public bool GetAplicaParaIGTF { get { return _miModelo.GetAplicaIGTF; } }
        public bool GetAplicaParaPOS { get { return _miModelo.GetAplicaParaPos; } }
        public bool GetAplicaRetornoCambioVuelto { get { return _miModelo.GetAplicaRetornoCambioVuelto; } }
        public object GetMonedasSource { get { return _monedas.Source; } }
        public string GetIdMoneda { get { return _miModelo.GetMoneda == null ? "" : _miModelo.GetMoneda.id; } }
        public bool IsOk { get { return ProcesarIsOk; } }
        public bool AbandonarIsOk { get { return _btAbandonar.ResultIsOK; } }
        //
        public abstract string Titulo { get; }
        public abstract bool ProcesarIsOk { get; }
        //
        public baseAgregarEditar()
        {
            _btAbandonar = new LibUtilitis.Herramimentas.Botones.BtAbandonarImp();
            _btProcesar = new LibUtilitis.Herramimentas.Botones.BtProcesarImp();
            _monedas = new LibUtilitis.Opcion.Imp();
            _miModelo = new Domain.Models.MiModelo();
            _uc = new Domain.UseCase.UseCaseImpl();
        }
        public void setCodigo(string dat)
        {
            _miModelo.setCodigoMedioPago(dat);
        }
        public void setNombre(string dat)
        {
            _miModelo.setNombreMedioPago(dat);
        }
        public void setParaCobranza(bool dat)
        {
            _miModelo.setAplicaParaCobranza(dat);
        }
        public void setParaPago(bool dat)
        {
            _miModelo.setAplicaParaPago(dat);
        }
        public void setIdMoneda(string id)
        {
            if (id.Trim() != "")
            {
                _miModelo.setMoneda(((Domain.Models.Monedas)CtrlMonedas.Item));
            }
        }
        public void setMoneda(object moneda)
        {
            _miModelo.setMoneda(null);
            if (moneda != null)
            {
                _miModelo.setMoneda(((Domain.Models.Monedas)moneda));
            }
        }
        public void setAplicaParaPos(bool aplic)
        {
            _miModelo.setAplicaParaPos(aplic);
        }
        public void setAplicaLoteRef(bool aplic)
        {
            _miModelo.setAplicaLoteRef(aplic);
        }
        public void setAplicaBonoPagoDivisa(bool aplic)
        {
            _miModelo.setAplicaBonoPagoDivisa(aplic);
        }
        public void setAplicaIGTF(bool aplic)
        {
            _miModelo.setAplicaIGTF(aplic);
        }
        public void setAplicaRetornoCambioVuelto(bool aplic)
        {
            _miModelo.setAplicaRetornoCambioVuelto(aplic);
        }
        public void setAplicaModuloCobroAnticipo(bool aplic)
        {
            _miModelo.setAplicaModuloCobroAnticipo(aplic);
        }
        //
        public virtual void Inicializa()
        {
            _miModelo.Inicializa();
            _btAbandonar.Inicializa();
            _btProcesar.Inicializa();
            _monedas.Inicializa();
        }
        public abstract void Inicia();
        public abstract void Procesar();
        public void Abandonar()
        {
            _btAbandonar.Execute();
        }
    }
}