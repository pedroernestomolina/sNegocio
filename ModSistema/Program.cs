using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var r01 = Helpers.Utilitis.CargarXml();
            if (r01.Result != OOB.Enumerados.EnumResult.isError)
            {
                if (Sistema._Usuario=="")
                {
                    Sistema.MyData = new DataProvSistema.Data.DataProv(Sistema._Instancia, Sistema._BaseDatos);
                }
                else
                {
                    Sistema.MyData = new DataProvSistema.Data.DataProv(Sistema._Instancia, Sistema._BaseDatos, Sistema._Usuario);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    src.IFabrica fabrica;
                    var r02 = Sistema.MyData.Empresa_Datos();
                    Sistema.Negocio = r02.Entidad;
                    var r03 = Sistema.MyData.Configuracion_ModuloSistema_Modo();
                    switch (r03.Entidad)
                    {
                        case DataProvSistema.Enumerados.modoConfSistema.Basico:
                            fabrica = new src.FabModoBasico();
                            break;
                        case DataProvSistema.Enumerados.modoConfSistema.Sucursal:
                            fabrica = new src.FabModoSucursal();
                            break;
                        case DataProvSistema.Enumerados.modoConfSistema.Administrativo:
                            fabrica = new src.FabModoAdm();
                            break;
                        default:
                            throw new Exception("NO SE HA DEFINIDO UN MODO DE CONFIGURACION PARA SISTEMA");
                    }
                    var _gestionId = new Identificacion.Gestion();
                    _gestionId.Inicia();
                    if (_gestionId.IsUsuarioOk)
                    {
                        var _gestion = new Gestion(fabrica);
                        _gestion.Inicia();
                    }
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                    Application.Exit();
                }

                //var r02 = Sistema.MyData.Empresa_Datos();
                //if (r02.Result == OOB.Enumerados.EnumResult.isError)
                //{
                //    Helpers.Msg.Error(r02.Mensaje);
                //    Application.Exit();
                //}
                //else
                //{
                //    Sistema.Negocio = r02.Entidad;

                //    var _gestionId = new Identificacion.Gestion();
                //    _gestionId.Inicia();
                //    if (_gestionId.IsUsuarioOk)
                //    {
                //        var _gestion = new Gestion();
                //        _gestion.Inicia();
                //    }
                //}
            }
            else
            {
                Helpers.Msg.Error(r01.Mensaje);
                Application.Exit();
            }
        }
    }

}