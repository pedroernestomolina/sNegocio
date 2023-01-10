using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Sucursal.AgregarEditar
{

    public partial class AgregarEditarFrm : Form
    {


        private ISucursalAgregarEditar _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
            InicializaCombo();
        }


        private void InicializaCombo()
        {
            CB_GRUPO.DisplayMember = "desc";
            CB_GRUPO.ValueMember = "id";
        }

        private bool _modoInicializa;
        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            CB_GRUPO.DataSource = _controlador.GrupoSource;
            L_TITULO.Text = _controlador.Titulo;
            TB_NOMBRE.Text = _controlador.GetNombre;
            CHK_MAYOR.Checked = _controlador.GetFactMayor;
            CHK_VENTA_CREDITO.Checked = _controlador.GetFactCredito;
            CHK_POS_VENTA_SURTIDO.Checked = _controlador.GetPosVentaSurtido;
            CHK_POS_VUELTO_DIVISA.Checked = _controlador.GetPosVueltoDivisa;
            CB_GRUPO.SelectedValue = _controlador.GetGrupoId;
            _modoInicializa = false;
            TB_NOMBRE.Focus();
        }
        private void AgregarEditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOk || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }


        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.setNombre(TB_NOMBRE.Text);
        }
        private void CHK_MAYOR_Leave(object sender, EventArgs e)
        {
            _controlador.setFactMayor(CHK_MAYOR.Checked);
        }
        private void CHK_VENTA_CREDITO_Leave(object sender, EventArgs e)
        {
            _controlador.setVentaCredito(CHK_VENTA_CREDITO.Checked);
        }
        private void CHK_POS_VUELTO_DIVISA_Leave(object sender, EventArgs e)
        {
            _controlador.setPosVueltoDivisa(CHK_POS_VUELTO_DIVISA.Checked);
        }
        private void CHK_POS_VENTA_SURTIDO_Leave(object sender, EventArgs e)
        {
            _controlador.setPosVentaSurtido(CHK_POS_VENTA_SURTIDO.Checked);
        }


        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            _controlador.SetGrupo("");
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.SetGrupo(CB_GRUPO.SelectedValue.ToString());
            }
        }


        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        public void setControlador(ISucursalAgregarEditar ctr)
        {
            _controlador = ctr;
        }


        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }


        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
        }
        private void Abandonar()
        {
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOk)
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