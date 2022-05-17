using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.EtiquetaPrecio
{

    public partial class ActualizarFrm : Form
    {

        private IEtiquetaPrecio _controlador;


        public ActualizarFrm()
        {
            InitializeComponent();
        }


        private void ActualizarFrm_Load(object sender, EventArgs e)
        {
            TB_ET1.Text = _controlador.Etiqueta1;
            TB_ET2.Text = _controlador.Etiqueta2;
            TB_ET1.Focus();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void Abandonar()
        {
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOk) 
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void ActualizarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            };
        }


        private void TB_ET1_Leave(object sender, EventArgs e)
        {
            _controlador.setEtiqueta1(TB_ET1.Text.Trim().ToUpper());
        }
        private void TB_ET2_Leave(object sender, EventArgs e)
        {
            _controlador.setEtiqueta2(TB_ET2.Text.Trim().ToUpper());
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


    }

}