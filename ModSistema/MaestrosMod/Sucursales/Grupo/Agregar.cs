using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Grupo
{
    
    public class Agregar: IAgregarEditar
    {


        private string _nombre;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private Helpers.Opcion.IOpcion _gPrecio;


        public string Titulo { get { return "Agregar: GRUPO"; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public BindingSource PrecioSource { get { return _gPrecio.Source; } }
        public string GetPrecioId { get { return _gPrecio.GetId; } }
        public string GetNombre { get { return _nombre; } }
        public data DataAgregar        {            get { throw new NotImplementedException(); }        }


        public Agregar() 
        {
            _gPrecio = new Helpers.Opcion.Gestion();
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
        }

        public void Inicializa()
        {
            _gPrecio.Inicializa();
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
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
        public void SetPrecio(string id)
        {
            _gPrecio.setFicha(id);
        }

        public void Procesar()
        {
            if (_nombre.Trim() == "") 
            {
                Helpers.Msg.Error("Campo [ NOMBRE ] No Puede Estar Vacio");
                return;
            }
            if (_gPrecio.Item ==null)
            {
                Helpers.Msg.Error("Campo [ PRECIO ] No Puede Estar Vacio");
                return;
            }

            _procesarIsOk = false;
            var xmsg = "Guardar Ficha ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) { }
        }
        
        public void Abandonar()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
                _abandonarIsOk = true; ;
        }

    }

}