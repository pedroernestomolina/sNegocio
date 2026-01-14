using LibUtilitis.Herramimentas.Mensajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModSistema.MaestrosMod.MediosCobro.AgregarEditar.vm
{
    public class AgregarNew: baseAgregarEditar, IAgregar
    {
        private bool _medioPagoIsOk;
        private OOB.LibSistema.MediosCobroPago.Entidad.Ficha _itemRegistrado;
        //
        public override string Titulo { get { return "Agregar: MEDIO DE COBRO / PAGO"; } }
        public override bool ProcesarIsOk { get { return _medioPagoIsOk; } }
        public OOB.LibSistema.MediosCobroPago.Entidad.Ficha GetItemRegistrado { get { return _itemRegistrado; } }
        //
        public AgregarNew() 
            : base()
        {
            _medioPagoIsOk = false;
            _itemRegistrado = null;
        }
        public override void Inicializa()
        {
            base.Inicializa();
            _medioPagoIsOk = false;
            _itemRegistrado = null;
        }
        AgregarEditarFrm frm;
        public override void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public override void Procesar()
        {
            _medioPagoIsOk = false;
            _itemRegistrado = null;
            BtProcesar.Execute();
            if (BtProcesar.ResultIsOK)
            {
                try
                {
                    var _idMoneda = MiModelo.GetMoneda == null ? 0 : MiModelo.GetMoneda.Ficha.id;
                    var fichaOOB = new OOB.LibSistema.MediosCobroPago.Agregar.Ficha()
                    {
                        codigo = MiModelo.GetCodigoMedioPago.Trim().ToUpper(),
                        descripcion = MiModelo.GetNombreMedioPago.Trim().ToUpper(),
                        estatusCobro = MiModelo.GetAplicaParaCobranza ? "1" : "0",
                        estatusPago = MiModelo.GetAplicaParaPago ? "1" : "0",
                        aplicaParaPos = MiModelo.GetAplicaParaPos ? "1" : "0",
                        aplicaLoteRef = MiModelo.GetAplicaLoteRef ? "1" : "0",
                        aplicaBonoPagoDivisa = MiModelo.GetAplicaBonoPagoDivisa ? "1" : "0",
                        aplicaIGTF = MiModelo.GetAplicaIGTF ? "1" : "0",
                        aplicaModuloCobroAnticipo = MiModelo.GetAplicaModuloCobroAnticipo ? "1" : "0",
                        aplicaRetornoCambioVuelto = MiModelo.GetAplicaRetornoCambioVuelto ? "1" : "0",
                        idMoneda = _idMoneda,
                    };
                    _itemRegistrado = UC.AgregarMedioPago(fichaOOB);
                    _medioPagoIsOk = true;
                    Msg.AgregarOk();
                }
                catch (Exception e)
                {
                    Msg.Error(e.Message);
                }
            }
        }
        //
        private bool cargarData()
        {
            try
            {
                var _lstMonedas = UC.CargarMonedas();
                var _lst = _lstMonedas.Select(s =>
                {
                    return new Domain.Models.Monedas()
                    {
                        Ficha = s,
                        codigo = s.codigo,
                        desc = s.nombre.Trim()+"/ "+s.simbolo,
                        id = s.id.ToString(),
                    };
                }).ToList();
                CtrlMonedas.setData(_lst);
                return true;
            }
            catch (Exception e)
            {
                Msg.Error(e.Message);
                return false;
            }
        }
    }
}