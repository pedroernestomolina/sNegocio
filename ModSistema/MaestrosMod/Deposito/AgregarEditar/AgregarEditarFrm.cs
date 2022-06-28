using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Deposito.AgregarEditar
{

    public partial class AgregarEditarFrm : Form
    {

        private IDepositoAgregarEditar _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
            InicializaCombos();
        }


        private void InicializaCombos()
        {
            CB_SUCURSAL.DisplayMember = "desc";
            CB_SUCURSAL.ValueMember = "id";
        }


        bool _modoInicializa;
        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            L_TITULO.Text = _controlador.Titulo;
            CB_SUCURSAL.DataSource = _controlador.SucursalSource;
            CB_SUCURSAL.SelectedValue = _controlador.GetSucursalId;
            TB_NOMBRE.Text = _controlador.GetNombre;
            _modoInicializa = false;
            TB_NOMBRE.Focus();
        }


        public void setControlador(IDepositoAgregarEditar ctr)
        {
            _controlador = ctr;
        }

        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.setNombre(TB_NOMBRE.Text.Trim());
        }
        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;

            _controlador.setSucursal("");
            if (CB_SUCURSAL.SelectedIndex !=-1)
            {
                _controlador.setSucursal(CB_SUCURSAL.SelectedValue.ToString());
            }
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
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

    }

}