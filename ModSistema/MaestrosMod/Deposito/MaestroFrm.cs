using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Deposito
{

    public partial class MaestroFrm : Form
    {


        private IDeposito _controlador;


        public MaestroFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }

        public void setControlador(IDeposito ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void TSM_ARCHIVO_Salir_Click(object sender, EventArgs e)
        {
            Salir();
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
            c1.DataPropertyName = "descripcion";
            c1.HeaderText = "Nombre";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Codigo";
            c2.HeaderText = "Codigo";
            c2.Visible = true;
            c2.Width = 60;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          
            var c5 = new DataGridViewCheckBoxColumn();
            c5.DataPropertyName = "esActivo";
            c5.HeaderText = "Estatus";
            c5.Visible = true;
            c5.Width = 60;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c2);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c5);
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

        private void BT_ACTIVAR_INACTIVAR_Click(object sender, EventArgs e)
        {
            ActivarInactivar();
        }
        private void ActivarInactivar()
        {
            _controlador.ActivarInactivar();
            if (_controlador.ActivarInactivarIsOk)
            {
                ActualizarItems();
            }
            DGV.Refresh();
        }

        private void ActualizarItems()
        {
            L_ITEMS.Text = _controlador.CntItems.ToString("n0");
        }

    }

}