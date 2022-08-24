using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Configuracion.Pos
{

    public partial class CnfPosFrm : Form
    {

        private ICnfPos _controlador;


        public CnfPosFrm()
        {
            InitializeComponent();
            Inicializa();
        }

        private void Inicializa()
        {
        }

        public void setControlador(ICnfPos ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void Abandonar()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK) 
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
            if (_controlador.ProcesarIsOK)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void CnfModuloFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK || _controlador.ProcesarIsOK)
            {
                e.Cancel = false;
            }
        }

        bool _modoInicializar;
        private void CnfModuloFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            TB_MAXIMO_DSCTO.Text = _controlador.GetDsctoMaximoPermitido.ToString();
            CHB_VALIDAR_DSCTO_PAGO_DIVISA.Checked = _controlador.GetPermisoDsctoPagoDivisa;
            _modoInicializar = false;
        }

        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_MAXIMO_DSCTO_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var dscto = decimal.Parse(TB_MAXIMO_DSCTO.Text);
            _controlador.setMaximoDscto(dscto);
        }
        private void CHB_VALIDAR_DSCTO_PAGO_DIVISA_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setHabilitarDsctoPagoDivisa(CHB_VALIDAR_DSCTO_PAGO_DIVISA.Checked);
        }

    }

}