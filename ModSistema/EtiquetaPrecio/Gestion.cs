using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.EtiquetaPrecio
{
    
    public class Gestion: IEtiquetaPrecio
    {

        private string _etq1;
        private string _etq2;
        private string _etq3;
        private bool _abandonarIsOk;
        private bool _procesarIsOk;


        public string Etiqueta1 { get { return _etq1; } }
        public string Etiqueta2 { get { return _etq2; } }
        public string Etiqueta3 { get { return _etq3; } }


        public Gestion()
        {
            _etq1 = "";
            _etq2 = "";
            _etq3 = "";
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }


        public void Inicializa()
        {
            _etq1 = "";
            _etq2 = "";
            _etq3 = "";
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }

        ActualizarFrm frm ;
        public void Inicia() 
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new ActualizarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.PrecioEtiqueta_GetFicha();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var s = r01.Entidad;
            _etq1 = s.descripcion_1;
            _etq2 = s.descripcion_2;
            _etq3 = s.descripcion_3;
            
            return rt;
        }


        public void setEtiqueta1(string p)
        {
            _etq1 = p;
        }
        public void setEtiqueta2(string p)
        {
            _etq2 = p;
        }

        public void setEtiqueta3(string p)
        {
            _etq3 = p;
        }


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void Abandonar()
        {
            _abandonarIsOk= false;
            var msg = MessageBox.Show("Abandonar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }

        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void Procesar()
        {
            _procesarIsOk = false;
            //if (_etq1 == "")
            //{
            //    Helpers.Msg.Alerta("ETIQUETA PRECIO 1, NO PUEDE ESTAR VACIO");
            //    return;
            //}
            //if (_etq2 == "")
            //{
            //    Helpers.Msg.Alerta("ETIQUETA PRECIO 2, NO PUEDE ESTAR VACIO");
            //    return;
            //}
            //if (_etq3 == "")
            //{
            //    Helpers.Msg.Alerta("ETIQUETA PRECIO 3, NO PUEDE ESTAR VACIO");
            //    return;
            //}

            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var ficha = new OOB.LibSistema.PrecioEtiqueta.Actualizar.Ficha()
                {
                    descripcion_1 = _etq1,
                    descripcion_2 = _etq2,
                    descripcion_3 = "",
                };
                var r01 = Sistema.MyData.PrecioEtiqueta_Actualizar(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _procesarIsOk = true;
            }
        }

    }

}