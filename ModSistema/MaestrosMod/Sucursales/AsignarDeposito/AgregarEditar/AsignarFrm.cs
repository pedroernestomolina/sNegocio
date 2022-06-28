using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.AsignarDeposito.AgregarEditar
{

    public partial class AsignarFrm : Form
    {

        private IAsignarDepositoEditar _controlador;


        public AsignarFrm()
        {
            InitializeComponent();
            InicializarCombos();
        }


        public void setControlador(IAsignarDepositoEditar ctr)
        {
            _controlador = ctr;
        }

        private void InicializarCombos()
        {
            CB_DEPOSITO.DisplayMember = "desc";
            CB_DEPOSITO.ValueMember = "id";
        }

        bool _modoInicializa;
        private void AsignarFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            CB_DEPOSITO.DataSource = _controlador.DepositoSource;
            CB_DEPOSITO.SelectedValue = _controlador.GetDepositoId;
            L_TITULO.Text = _controlador.Titulo;
            L_SUCURSAL.Text = _controlador.GetSucursal;
            _modoInicializa = false;
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;

            _controlador.SetDeposito("");
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.SetDeposito(CB_DEPOSITO.SelectedValue.ToString());
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
        private void AsignarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOk || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }

    }

}