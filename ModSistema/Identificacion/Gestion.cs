﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Identificacion
{
    
    public class Gestion
    {

        public string CodigoUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public bool IsUsuarioOk { get; set; }


        public void Inicia()
        {
            IsUsuarioOk = false;
            CodigoUsuario = "";
            ClaveUsuario = "";

            var frm = new Identificacion.IdentificacionFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public bool VerificarUsuario()
        {
            var rt = false;

            var ficha = new OOB.LibSistema.Usuario.Buscar.Ficha()
            {
                Clave = ClaveUsuario,
                Codigo = CodigoUsuario,
            };
            var r01 = Sistema.MyData.Usuario_Cargar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData.Permiso_ToolSistema(r01.Entidad.autoGrupo);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            if (r02.Entidad.IsHabilitado)
            {
                var fichaSesion = new OOB.LibSistema.Usuario.ActualizarSesion.Ficha()
                {
                     autoUsu=r01.Entidad.auto,
                };
                var r03 = Sistema.MyData.Usuario_ActualizarSesion(fichaSesion);
                if (r03.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r03.Mensaje);
                    return false;
                }

                rt = true;
                Sistema.UsuarioP = r01.Entidad;
                IsUsuarioOk = true;
            }
            else
            {
                Helpers.Msg.Error("PERMISO DENEGADO");
            }

            return rt;
        }

    }

}