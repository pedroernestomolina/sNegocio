using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.MediosCobro.AgregarEditar
{

    public partial class AgregarEditarFrm : Form
    {

        private IMedioCobroAgregarEditar _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
            InicializaCombos();
        }


        private void InicializaCombos()
        {
        }


        bool _modoInicializa;
        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            L_TITULO.Text = _controlador.Titulo;
            TB_NOMBRE.Text = _controlador.GetNombre;
            TB_CODIGO.Text = _controlador.GetCodigo;
            CHB_COBRANZA.Checked = _controlador.GetEstatusCobranza;
            CHB_PAGO.Checked = _controlador.GetEstatusPago;
            _modoInicializa = false;
            TB_NOMBRE.Focus();
        }


        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.setNombre(TB_NOMBRE.Text.Trim());
        }
        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            _controlador.setCodigo(TB_CODIGO.Text.Trim());
        }
        private void CHB_COBRANZA_Leave(object sender, EventArgs e)
        {
            _controlador.setParaCobranza(CHB_COBRANZA.Checked);
        }
        private void CHB_PAGO_Leave(object sender, EventArgs e)
        {
            _controlador.setParaPago(CHB_PAGO.Checked);
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
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

        private void AgregarEditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOk || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }

        public void setControlador(IMedioCobroAgregarEditar ctr)
        {
            _controlador = ctr;
        }

    }

}