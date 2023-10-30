using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.src.PanelPrincipal.ModoAdm
{

    public partial class Principal : Form
    {

        private Gestion _controlador;
        private Timer timer;


        public Principal()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var s = DateTime.Now;
            L_FECHA.Text = s.ToLongDateString();
            L_HORA.Text = s.ToLongTimeString();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void TSM_ARCHIVO_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void Salir()
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
            L_HOST.Text = _controlador.Host;
            L_USUARIO.Text = _controlador.Usuario;
            L_FECHA.Text = "";
            L_HORA.Text = "";
        }

        private void TSM_MAESTROS_UsuarioGrupo_Click(object sender, EventArgs e)
        {
            UsuarioGrupos();
        }
        private void UsuarioGrupos()
        {
            _controlador.MaestroUsuariosGrupo();
        }

        private void TSM_MAESTROS_Usuario_Click(object sender, EventArgs e)
        {
            Usuarios();
        }
        private void Usuarios()
        {
            _controlador.MaestroUsuarios();
        }

        private void Menu_Ajuste_TasaDivisa_Click(object sender, EventArgs e)
        {
            TasaDivisa();
        }
        private void TasaDivisa()
        {
            _controlador.ActualizarTasaDivisa();
        }

        private void TSM_MAESTRO_SERIES_FISCAL_Click(object sender, EventArgs e)
        {
            SeriesFiscal();
        }
        private void SeriesFiscal()
        {
            _controlador.SeriesFiscal();
        }

        private void TSM_AJUSTE_Datos_Negocio_Click(object sender, EventArgs e)
        {
            DatosDelNegocio();
        }
        private void DatosDelNegocio()
        {
            _controlador.DatosDelNegocio();
        }

        private void TSM_CONF_MODULO_Click(object sender, EventArgs e)
        {
            ConfiguracionModulo();
        }
        private void ConfiguracionModulo()
        {
            _controlador.ConfiguracionModulo();
        }

        private void TSM_MAESTRO_Sucursal_AsignarDeposito_Click(object sender, EventArgs e)
        {
            AsignarDeposito();
        }
        private void AsignarDeposito()
        {
            _controlador.AsignarDeposito();
        }


        private void Menu_Ajuste_TasaRecepciónDivisa_POS_Click(object sender, EventArgs e)
        {
            ConfiguracionPos();
        }
        private void ConfiguracionPos()
        {
            _controlador.TasaRecepcionDivisaPos();
        }

        private void TSM_MAESTRO_VENDEDOR_Click(object sender, EventArgs e)
        {
            Vendedor();
        }
        private void Vendedor()
        {
            _controlador.Vendedor();
        }

        private void TSM_MAESTRO_COBRADOR_Click(object sender, EventArgs e)
        {
            Cobrador();
        }
        private void Cobrador()
        {
            _controlador.Cobrador();
        }

        private void TSM_MAESTRO_MEDIOS_COBRO_Click(object sender, EventArgs e)
        {
            MediosCobro();
        }
        private void MediosCobro()
        {
            _controlador.MediosCobro();
        }
    }
}