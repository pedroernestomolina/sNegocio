using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Grupo.AgregarEditar
{

    public partial class AgregarEditarFrm : Form
    {
        
        private IGrupoAgregarEditar _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
            IncializaCombos();
        }

        private void IncializaCombos()
        {
            CB_PRECIO.DisplayMember="desc";
            CB_PRECIO.ValueMember = "id";
        }


        private bool _modoInicializa;
        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            L_TITULO.Text = _controlador.Titulo;
            _modoInicializa = true;
            CB_PRECIO.DataSource = _controlador.PrecioSource;
            CB_PRECIO.SelectedValue = _controlador.GetPrecioId;
            TB_NOMBRE.Text = _controlador.GetNombre;
            _modoInicializa = false;
            TB_NOMBRE.Focus();
        }
        
        public void setControlador(IGrupoAgregarEditar ctr)
        {
            _controlador=ctr;
        }


        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.setNombre(TB_NOMBRE.Text);
        }
        private void CB_PRECIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;

            _controlador.SetPrecio("");
            if (CB_PRECIO.SelectedIndex!=-1) 
            {
                _controlador.SetPrecio(CB_PRECIO.SelectedValue.ToString());
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