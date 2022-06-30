using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema
{

    public class Gestion
    {


        private UsuarioGrupo.Gestion _gestionUsuarioGrupo;
        private Usuario.Gestion _gestionUsuario;
        private Servicio.Gestion _gestionServicio;
        private TasaDivisa.Gestion _gestionTasaDivisa;
        private Maestros.Gestion _gestionMaestro;
        private ReconversionMonetaria.Gestion _gestionRecMon;
        private DatosNegocio.Editar.Gestion _gestionDatosNegocio;
        private IGestion _gConfModulo;
        //
        private Helpers.Lista.ILista _gLista;
        //
        private MaestrosMod.ILista _gMaestroLista;
        private MaestrosMod.IMaestro _gMaestro;
        //
        private MaestrosMod.Sucursales.Grupo.IGrupo _gGrupoSuc;
        private MaestrosMod.Sucursales.Grupo.IGrupoLista _gGrupoSucLista;
        private MaestrosMod.Sucursales.Grupo.AgregarEditar.IAgregar _gAgregarGrupoSuc;
        private MaestrosMod.Sucursales.Grupo.AgregarEditar.IEditar _gEditarGrupoSuc;
        //
        private MaestrosMod.ITipoMaestro _gTablaPrecioSuc;
        private MaestrosMod.Sucursales.TablaPrecio.ITablaPrecioAgregarEditar _gAgregarTablaPrecioSuc;
        private MaestrosMod.Sucursales.TablaPrecio.ITablaPrecioAgregarEditar _gEditarTablaPrecioSuc;
        //
        private MaestrosMod.Sucursales.Sucursal.ISucursal _gSucursal;
        private MaestrosMod.Sucursales.Sucursal.ISucursalLista _gSucursalLista;
        private MaestrosMod.Sucursales.Sucursal.AgregarEditar.IAgregar _gSucursalAgregar;
        private MaestrosMod.Sucursales.Sucursal.AgregarEditar.IEditar _gSucursalEditar;
        //
        private MaestrosMod.Sucursales.AsignarDeposito.IAsignarDeposito _gAsignarDep;
        private MaestrosMod.Sucursales.AsignarDeposito.IAsignarDepositoLista _gAsignarDepLista;
        private MaestrosMod.Sucursales.AsignarDeposito.AgregarEditar.IEditar _gAsignarDepEditar;
        //
        private MaestrosMod.Deposito.IDeposito _gDeposito;
        private MaestrosMod.Deposito.IDepositoLista _gDepositoLista;
        private MaestrosMod.Deposito.AgregarEditar.IAgregar _gAgregarDep;
        private MaestrosMod.Deposito.AgregarEditar.IEditar _gEditarDep;
        //
        private MaestrosMod.MediosCobro.AgregarEditar.IAgregar _gMedioAgregar;
        private MaestrosMod.MediosCobro.AgregarEditar.IEditar _gMedioEditar;
        private MaestrosMod.MediosCobro.IMedioCobroLista _gMedioLista;
        private MaestrosMod.MediosCobro.IMedioCobro _gMedio;
        //
        private EtiquetaPrecio.IEtiquetaPrecio _gEtiquetaPrecio;


        public string Host 
        {
            get 
            {
                return Sistema.Host; 
            }
        }

        public string Version 
        {
            get 
            {
                return "Ver. 2 - " + Application.ProductVersion; 
            }
        }

        public string Usuario
        {
            get
            {
                var rt = "";
                rt = Sistema.UsuarioP.codigo +
                    Environment.NewLine + Sistema.UsuarioP.nombre +
                    Environment.NewLine + Sistema.UsuarioP.grupo;
                return rt;
            }
        }


        public Gestion()
        {
            _gestionUsuarioGrupo = new UsuarioGrupo.Gestion();
            _gestionUsuario = new Usuario.Gestion();
            _gestionServicio = new Servicio.Gestion();
            _gestionTasaDivisa = new TasaDivisa.Gestion();
            _gestionMaestro = new Maestros.Gestion();
            _gestionRecMon = new ReconversionMonetaria.Gestion();
            _gestionDatosNegocio = new DatosNegocio.Editar.Gestion();
            //
            _gConfModulo = new Configuracion.Modulo.Gestion();
            //
            _gLista = new Helpers.Lista.Lista();
            //
            _gMaestroLista = new MaestrosMod.Lista();
            _gMaestro = new MaestrosMod.Maestro(_gMaestroLista);
            //
            _gGrupoSucLista = new MaestrosMod.Sucursales.Grupo.Lista(); 
            _gAgregarGrupoSuc = new MaestrosMod.Sucursales.Grupo.AgregarEditar.Agregar();
            _gEditarGrupoSuc = new MaestrosMod.Sucursales.Grupo.AgregarEditar.Editar();
            _gGrupoSuc = new MaestrosMod.Sucursales.Grupo.Maestro(_gGrupoSucLista, _gAgregarGrupoSuc, _gEditarGrupoSuc, new Helpers.Lista.Lista());
            //
            _gAgregarTablaPrecioSuc = new MaestrosMod.Sucursales.TablaPrecio.Agregar();
            _gEditarTablaPrecioSuc = new MaestrosMod.Sucursales.TablaPrecio.Editar();
            _gTablaPrecioSuc = new MaestrosMod.Sucursales.TablaPrecio.Maestro
                (_gAgregarTablaPrecioSuc, 
                _gEditarTablaPrecioSuc);
            //
            _gSucursalLista = new MaestrosMod.Sucursales.Sucursal.Lista();
            _gSucursalAgregar = new MaestrosMod.Sucursales.Sucursal.AgregarEditar.Agregar();
            _gSucursalEditar = new MaestrosMod.Sucursales.Sucursal.AgregarEditar.Editar();
            _gSucursal = new MaestrosMod.Sucursales.Sucursal.Maestro(_gSucursalLista, _gSucursalAgregar, _gSucursalEditar, new Helpers.Lista.Lista());
            //
            _gAsignarDepLista = new MaestrosMod.Sucursales.AsignarDeposito.Lista();
            _gAsignarDepEditar = new MaestrosMod.Sucursales.AsignarDeposito.AgregarEditar.Editar();
            _gAsignarDep = new MaestrosMod.Sucursales.AsignarDeposito.Maestro(_gAsignarDepLista, _gAsignarDepEditar);
            //
            _gDepositoLista= new MaestrosMod.Deposito.Lista();
            _gAgregarDep= new MaestrosMod.Deposito.AgregarEditar.Agregar ();
            _gEditarDep = new MaestrosMod.Deposito.AgregarEditar.Editar ();
            _gDeposito = new MaestrosMod.Deposito.Maestro(_gDepositoLista, _gAgregarDep, _gEditarDep);
            //
            _gMedioLista = new MaestrosMod.MediosCobro.Lista();
            _gMedioAgregar = new MaestrosMod.MediosCobro.AgregarEditar.Agregar();
            _gMedioEditar = new MaestrosMod.MediosCobro.AgregarEditar.Editar();
            _gMedio = new MaestrosMod.MediosCobro.Maestro(_gMedioLista, _gMedioAgregar, _gMedioEditar);
            //
            _gEtiquetaPrecio = new EtiquetaPrecio.Gestion();
        }


        public void Inicia() 
        {
            var frm = new Form1();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void MaestroUsuariosGrupo()
        {
            var r00 = Sistema.MyData.Permiso_ControlUsuarioGrupo(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionUsuarioGrupo.Inicializa();
                _gestionUsuarioGrupo.Inicia();
            }
        }

        public void MaestroUsuarios()
        {
            var r00 = Sistema.MyData.Permiso_ControlUsuario(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionUsuario.Inicializa();
                _gestionUsuario.Inicia();
            }
        }

        public void InicializarBD()
        {
            var r00 = Sistema.MyData.Permiso_InicializarBD(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionServicio.IniciaBD();
            }
        }

        public void InicializarBD_Sucursal()
        {
            var r00 = Sistema.MyData.Permiso_InicializarBD_Sucursal(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionServicio.IniciaBD_Sucursal();
            }
        }

        public void TasaRecepcionDivisaPos()
        {
            var r00 = Sistema.MyData.Permiso_AjustarTasaDivisaRecepcionPos(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var gestion = new TasaDivisa.Pos.Gestion();
                _gestionTasaDivisa.setGestion(gestion);
                _gestionTasaDivisa.Inicia();
            }
        }

        public void TasaDivisa()
        {
            var r00 = Sistema.MyData.Permiso_AjustarTasaDivisa(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var gestion = new TasaDivisa.Sist.Gestion();
                _gestionTasaDivisa.setGestion(gestion);
                _gestionTasaDivisa.Inicia();
            }
        }

        public void Vendedor()
        {
            var r00 = Sistema.MyData.Permiso_ControlVendedor(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var _gestionVend = new Maestros.Vendedor.Gestion();
                _gestionMaestro.setGestion(_gestionVend);
                _gestionMaestro.Inicializa();
                _gestionMaestro.Inicia();
            }
       }

        public void Cobrador()
        {
            var r00 = Sistema.MyData.Permiso_ControlCobrador(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var _gestionCob = new Maestros.Cobrador.Gestion();
                _gestionMaestro.setGestion(_gestionCob);
                _gestionMaestro.Inicializa();
                _gestionMaestro.Inicia();
            }
        }

        public void SeriesFiscal()
        {
            var r00 = Sistema.MyData.Permiso_ControlSerieFiscal(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var _gestionSF= new Maestros.SerieFiscal.Gestion();
                _gestionMaestro.setGestion(_gestionSF);
                _gestionMaestro.Inicializa();
                _gestionMaestro.Inicia();
            }
        }

        public void ReconversionMonetaria()
        {
            var r01 = Sistema.MyData.ReconversionMonetaria_GetCount();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var cnt=r01.Entidad;
            if ( cnt>= 1) 
            {
                Helpers.Msg.Error("PROCESO DE RECONVERSION MONETARIA YA REALIZADO"+Environment.NewLine+"VERIFIQUE POR FAVOR...");
                return;
            }

            _gestionRecMon.Inicializa();
            _gestionRecMon.setFactorReconversion(1000000);
            _gestionRecMon.Inicia();
        }

        public void DatosDelNegocio()
        {
            var r00 = Sistema.MyData.Permiso_ControlSerieFiscal(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionDatosNegocio.Inicializa();
                _gestionDatosNegocio.Inicia();
            }
        }

        public void ConfiguracionModulo()
        {
            var r00 = Sistema.MyData.Permiso_ConfiguracionSistema(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gConfModulo.Inicializa();
                _gConfModulo.Inicia();
            }
        }

        public void TablaPreciosSuc()
        {
            var r00 = Sistema.MyData.Permiso_ControlSucursal_TablaPrecio(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gTablaPrecioSuc.Inicializa();

                _gMaestro.Inicializa();
                _gMaestro.setTipoMaestro(_gTablaPrecioSuc);
                _gMaestro.Inicia();
            }
        }


        public void EtiquetarPrecios()
        {
            var r00 = Sistema.MyData.Permiso_EtiquetaParaPrecios(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gEtiquetaPrecio.Inicializa();
                _gEtiquetaPrecio.Inicia();
            }
        }

        public void MediosCobro()
        {
            var r00 = Sistema.MyData.Permiso_MedioPagoCobro(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gMedio.Inicializa();
                _gMedio.Inicia();
            }
        }

        public void MaestroDepositos()
        {
            var r00 = Sistema.MyData.Permiso_ControlDeposito(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gDeposito.Inicializa();
                _gDeposito.Inicia();
            }
        }

        public void MaestroSucursalGrupo()
        {
            var r00 = Sistema.MyData.Permiso_ControlSucursalGrupo(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gGrupoSuc.Inicializa();
                _gGrupoSuc.Inicia();
            }
        }

        public void MaestroSucursales()
        {
            var r00 = Sistema.MyData.Permiso_ControlSucursal(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gSucursal.Inicializa();
                _gSucursal.Inicia();
            }
        }

        public void AsignarDeposito()
        {
            var r00 = Sistema.MyData.Permiso_AsignarDepositoSucursal(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gAsignarDep.Inicializa();
                _gAsignarDep.Inicia();
            }
        }

    }

}