using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.TablaPrecio
{

    public partial class MaestroFrm : Form
    {

        private IMaestro _controlador;


        public MaestroFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }

        public void setControlador(IMaestro ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void TSM_ARCHIVO_Salir_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void Salir()
        {
            this.Close();
        }

        private void MaestroFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            L_TITULO.Text = _controlador.Titulo;
            L_ITEMS.Text = _controlador.CntItems.ToString("n0");
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 100;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Descripcion";
            c2.HeaderText = "Descripción";
            c2.Visible = true;
            c2.MinimumWidth = 100;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewCheckBoxColumn();
            c3.DataPropertyName = "EsActivo";
            c3.HeaderText = "Estatus";
            c3.Visible = true;
            c3.Width = 60;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
        }

        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarItem();
        }
        private void AgregarItem()
        {
            _controlador.AgregarItem();
            if (_controlador.AgregarIsOk)
            {
                ActualizarItems();
            }
        }

        private void ActualizarItems()
        {
            L_ITEMS.Text = _controlador.CntItems.ToString("n0");
        }

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarItem();
        }
        private void EditarItem()
        {
            _controlador.EditarItem();
            if (_controlador.EditarIsOk)
            {
                ActualizarItems();
            }
        }
     
    }

}