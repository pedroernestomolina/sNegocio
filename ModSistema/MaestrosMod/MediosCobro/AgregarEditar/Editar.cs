using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.MediosCobro.AgregarEditar
{

    public class Editar : IEditar
    {

        private string _nombre;
        private string _codigo;
        private bool _estatusCobranza;
        private bool _estatusPago;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private string _idItemEditar;


        public string Titulo { get { return "Editar: MEDIO DE COBRO / PAGO"; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public object IdItemRegistrado { get { return null; } }


        public Editar() 
        {
            _nombre = "";
            _codigo = "";
            _estatusCobranza = false;
            _estatusPago = false;
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemEditar = "";
        }


        public void Inicializa()
        {
            _nombre = "";
            _codigo = "";
            _estatusCobranza = false;
            _estatusPago = false;
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemEditar = "";
        }

        AgregarEditarFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.MediosCobroPago_GetFicha_ById(_idItemEditar);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _codigo= r01.Entidad.codigo;
            _nombre = r01.Entidad.descripcion;
            _estatusCobranza = r01.Entidad.isParaCobro;
            _estatusPago = r01.Entidad.isParaPago;

            return true;
        }


        public void Procesar()
        {
            _procesarIsOk = false;
            if (_nombre.Trim() == "") 
            {
                Helpers.Msg.Error("Campo [ NOMBRE ] No Puede Estar Vacio");
                return;
            }
            if (_codigo.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ CODIGO ] No Puede Estar Vacio");
                return;
            }
            var xmsg = "Guardar Ficha ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var fichaOOB = new OOB.LibSistema.MediosCobroPago.Editar.Ficha()
                {
                    auto = _idItemEditar,
                    codigo = _codigo,
                    descripcion = _nombre,
                    estatusCobro = _estatusCobranza ? "1" : "0",
                    estatusPago = _estatusPago ? "1" : "0",
                };
                var r01 = Sistema.MyData.MediosCobroPago_EditarFicha(fichaOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _procesarIsOk = true;
                Helpers.Msg.EditarOk();
            }
        }
        
        public void Abandonar()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true; ;
            }
        }
        public void setIdItemEditar(string _idEditar)
        {
            _idItemEditar = _idEditar;
        }


        public string GetNombre { get { return _nombre; } }
        public string GetCodigo { get { return _codigo; } }
        public bool GetEstatusCobranza { get { return _estatusCobranza; } }
        public bool GetEstatusPago { get { return _estatusPago; } }
        public void setNombre(string p)
        {
            _nombre = p;
        }
        public void setCodigo(string p)
        {
            _codigo = p;
        }
        public void setParaCobranza(bool p)
        {
            _estatusCobranza = p;
        }
        public void setParaPago(bool p)
        {
            _estatusPago = p;
        }

    }

}