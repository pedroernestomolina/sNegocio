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
        private vm.IAgregarEditar _controlador;
        //
        public AgregarEditarFrm()
        {
            InitializeComponent();
            InicializaCombos();
        }
        private void InicializaCombos()
        {
            CB_MONEDAS.DisplayMember = "desc";
            CB_MONEDAS.ValueMember = "id";
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
            CHB_APLICA_LOTE_REF.Checked = _controlador.GetAplicaLoteReferencia;
            CHB_APLICA_MODULO_COBRO_ANTICIPO.Checked = _controlador.GetAplicaModuloCobroAnticipo;
            CHB_APLICA_PARA_BONO_PAGO_DIVISA.Checked = _controlador.GetAplicaParaBonoPagoDivisa;
            CHB_APLICA_PARA_IGTF.Checked = _controlador.GetAplicaParaIGTF;
            CHB_APLICA_PARA_POS.Checked = _controlador.GetAplicaParaPOS;
            CHB_APLICA_RETORNO_CAMBIO_VUELTO.Checked = _controlador.GetAplicaRetornoCambioVuelto;
            CB_MONEDAS.DataSource = _controlador.GetMonedasSource;
            CB_MONEDAS.SelectedValue= _controlador.GetIdMoneda;
            _modoInicializa = false;
            TB_NOMBRE.Focus();
        }
        public void setControlador(vm.IAgregarEditar ctr)
        {
            _controlador = ctr;
        }
        private void AgregarEditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.IsOk )
            {
                e.Cancel = false;
            }
        }
        private void AgregarEditarFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        //
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
        private void CHB_APLICA_PARA_POS_Leave(object sender, EventArgs e)
        {
            _controlador.setAplicaParaPos(CHB_APLICA_PARA_POS.Checked);
        }
        private void CHB_APLICA_LOTE_REF_Leave(object sender, EventArgs e)
        {
            _controlador.setAplicaLoteRef(CHB_APLICA_LOTE_REF.Checked);
        }
        private void CHB_APLICA_PARA_BONO_PAGO_DIVISA_Leave(object sender, EventArgs e)
        {
            _controlador.setAplicaBonoPagoDivisa(CHB_APLICA_PARA_BONO_PAGO_DIVISA.Checked);
        }
        private void CHB_APLICA_PARA_IGTF_Leave(object sender, EventArgs e)
        {
            _controlador.setAplicaIGTF(CHB_APLICA_PARA_IGTF.Checked);
        }
        private void CHB_APLICA_RETORNO_CAMBIO_VUELTO_Leave(object sender, EventArgs e)
        {
            _controlador.setAplicaRetornoCambioVuelto(CHB_APLICA_RETORNO_CAMBIO_VUELTO.Checked);
        }
        private void CHB_APLICA_MODULO_COBRO_ANTICIPO_Leave(object sender, EventArgs e)
        {
            _controlador.setAplicaModuloCobroAnticipo(CHB_APLICA_MODULO_COBRO_ANTICIPO.Checked);
        }
        private void CB_MONEDAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.setMoneda(null);
            if (CB_MONEDAS.SelectedIndex != -1)
            {
                _controlador.setMoneda(CB_MONEDAS.SelectedItem);
            }
        }
        private void label11_Click(object sender, EventArgs e)
        {
            LimpiarMoneda();
        }
        //
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        //
        private void LimpiarMoneda()
        {
            CB_MONEDAS.SelectedValue = -1;
        }
        private void Abandonar()
        {
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOk)
            {
                salir();
            }
        }
        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOk)
            {
                salir();
            }
        }
        //
        private void salir()
        {
            this.Close();
        }
    }
}