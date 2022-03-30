using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.TablaPrecio
{
    

    public class Agregar: ITablaPrecioAgregarEditar
    {

        private string _nombre;
        private int _idItemRegistrado;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;


        public string Titulo { get { return "Agregar: PRECIO"; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public string GetNombre { get { return _nombre; } }
        public object IdItemRegistrado { get { return _idItemRegistrado; } }


        public Agregar()
        {
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemRegistrado = -1;
        }

        public void Inicializa()
        {
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemRegistrado = -1;
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
            return true;
        }


        public void setNombre(string p)
        {
            _nombre = p;
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            _idItemRegistrado = -1;

            if (_nombre.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ NOMBRE ] No Puede Estar Vacio");
                return;
            }
            var xmsg = "Guardar Ficha ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var fichaOOB = new OOB.LibSistema.TablaPrecio.Agregar.Ficha()
                {
                    descripcion = _nombre,
                };
                var r01 = Sistema.MyData.TablaPrecio_Agregar(fichaOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _idItemRegistrado = r01.Id;
                _procesarIsOk = true;
                Helpers.Msg.AgregarOk();
            }
        }

        public void Abandonar()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }

        public void setIdItemEditar(object p)
        {
        }

    }

}