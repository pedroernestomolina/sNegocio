using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros.SerieFiscal
{
    public partial class AgregarEditarFrm : Form
    {
        private AgregarEditar _controlador;
        //
        public AgregarEditarFrm()
        {
            InitializeComponent();
        }
        public void setContolador(AgregarEditar ctr)
        {
            _controlador = ctr;
        }
        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            L_TITULO.Text = _controlador.TituloFicha;
            TB_SERIE.Text = _controlador.GetSerie;
            TB_CONTROL.Text = _controlador.GetControl;
            TB_CORRELATIVO.Text = _controlador.GetCorrelativo.ToString();
            CHB_FACTURA.Checked = _controlador.Get_AplicaFactura;
            CHB_DEBITO.Checked = _controlador.Get_AplicaNtDebito;
            CHB_CREDITO.Checked = _controlador.Get_AplicaNtCredito;
            CHB_NOTA_ENT.Checked = _controlador.Get_AplicaNtEntrega;
            CHB_APLICAR_LIBRO_VENTA.Checked = _controlador.Get_AplicaLibroVenta;
        }
        private void AgregarEditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_controlador.SalirIsOk || _controlador.AbandonarIsOk) { }
            else
                e.Cancel = true;
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TB_SERIE_Leave(object sender, EventArgs e)
        {
            _controlador.setSerie(TB_SERIE.Text.Trim().ToUpper());
        }
        private void TB_CONTROL_Leave(object sender, EventArgs e)
        {
            _controlador.setControl(TB_CONTROL.Text.Trim().ToUpper());
        }
        private void TB_CORRELATIVO_Leave(object sender, EventArgs e)
        {
            _controlador.setCorrelativo(int.Parse(TB_CORRELATIVO.Text));
        }
        private void CHB_FACTURA_Leave(object sender, EventArgs e)
        {
            sw_Factura();
        }
        private void CHB_DEBITO_Leave(object sender, EventArgs e)
        {
            sw_NtDebito();
        }
        private void CHB_CREDITO_Leave(object sender, EventArgs e)
        {
            sw_NtCredito();
        }
        private void CHB_NOTA_ENT_Leave(object sender, EventArgs e)
        {
            sw_NtEntrega();
        }
        private void CHB_APLICAR_LIBRO_VENTA_Leave(object sender, EventArgs e)
        {
            sw_LibroVenta();
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        //
        private void sw_Factura()
        {
            _controlador.sw_Factura();
        }
        private void sw_NtDebito()
        {
            _controlador.sw_NtDebito();
        }
        private void sw_NtCredito()
        {
            _controlador.sw_NtCredito();
        }
        private void sw_NtEntrega()
        {
            _controlador.sw_NtEntrega();
        }
        private void sw_LibroVenta()
        {
            _controlador.sw_LibroVenta();
        }
        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.SalirIsOk)
                this.Close();
        }
        private void Salir()
        {
            _controlador.Salir();
        }
        public void Cerrar()
        {
            this.Close();
        }
    }
}