using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.TablaPrecio
{
    

    public class Editar: ITablaPrecioAgregarEditar
    {

        private int _idItemEditar;
        private string _nombre;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;


        public string Titulo { get { return "Editar: PRECIO"; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public string GetNombre { get { return _nombre; } }
        public object IdItemRegistrado { get { return null; } }


        public Editar()
        {
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemEditar = -1;
        }


        public void Inicializa()
        {
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemEditar = -1;
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
            var r01 = Sistema.MyData.TablaPrecio_GetById(_idItemEditar);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var rg = r01.Entidad;
            _nombre = rg.descripcion;
            return true;
        }


        public void setNombre(string p)
        {
            _nombre = p;
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            if (_nombre.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ NOMBRE ] No Puede Estar Vacio");
                return;
            }
            var xmsg = "Guardar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var fichaOOB = new OOB.LibSistema.TablaPrecio.Editar.Ficha()
                {
                    id = _idItemEditar,
                    descripcion = _nombre,
                };
                var r01 = Sistema.MyData.TablaPrecio_Editar(fichaOOB);
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
                _abandonarIsOk = true;
            }
        }

        public void setIdItemEditar(int id)
        {
            _idItemEditar = id;
        }

    }

}