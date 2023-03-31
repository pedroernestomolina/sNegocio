using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.src.ActualizarTasaDivisa.ModoAdm
{
    public partial class Frm : Form
    {
        private IModoAdm _controlador;


        public Frm()
        {
            InitializeComponent();
        }


        private void Frm_Load(object sender, EventArgs e)
        {
            L_TASA.Text = _controlador.Get_TituloFuncion;
            TB_TASA.Text = _controlador.Get_TasaDivisaValorActual.ToString("n2", CultureInfo.CurrentCulture);
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK || _controlador.ProcesarIsOK)
            {
                e.Cancel = false;
            }
        }


        public void setControlador(IModoAdm ctr)
        {
            _controlador = ctr;
        }


        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TB_TASA_Leave(object sender, EventArgs e)
        {
            _controlador.setTasaDivisa(decimal.Parse(TB_TASA.Text));
            TB_TASA.Text = _controlador.Get_TasaDivisaValorNuevo.ToString("n2", CultureInfo.CurrentCulture);
        }


        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK)
            {
                Salir();
            }
        }
        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
    }
}