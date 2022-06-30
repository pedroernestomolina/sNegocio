﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Helpers.Lista
{


    public partial class ListaFrm : Form
    {

        private ILista _controlador;


        public ListaFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }


        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

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
            c1.DataPropertyName = "codigo";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 120;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "descripcion";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 280;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewCheckBoxColumn();
            c3.DataPropertyName = "esActivo";
            c3.HeaderText = "Estatus";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.Width = 60;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
        }

        public void setControlador(ILista ctr)
        {
            _controlador = ctr;
        }

        private void BuscarFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.SourceData;
            L_TITULO.Text = _controlador.Titulo;
            L_ITEMS.Text = "Items Encontrados: " + _controlador.CntItems.ToString();
            DGV.Refresh();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

    }

}