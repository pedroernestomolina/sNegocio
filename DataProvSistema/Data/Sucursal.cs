using DataProvSistema.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{
    public partial class DataProv: IData
    {
        public OOB.ResultadoLista<OOB.LibSistema.Sucursal.Entidad.Ficha> 
            Sucursal_GetLista(OOB.LibSistema.Sucursal.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.Sucursal.Entidad.Ficha>();
            var filtroDTO = new DtoLibSistema.Sucursal.Lista.Filtro()
            {
                autoGrupo = filtro.autoGrupo,
            };
            var r01 = MyData.Sucursal_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var lst = new List<OOB.LibSistema.Sucursal.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.Sucursal.Entidad.Ficha()
                        {
                            auto = s.auto,
                            codigo = s.codigo,
                            estatus = s.estatus,
                            estatusFactMayor = s.estatusFactMayor,
                            estatusVentaCredito = s.estatusVentaCredito,
                            nombre = s.nombre,
                            nombreDepositoPrincipal = s.nombreDeposito,
                            nombreGrupo = s.nombreGrupo,
                            estatusPosVentaSurtido=s.estatusPosVentaSurtido,
                            estatusPosVueltoDivisa=s.estatusPosVueltoDivisa,
                        };
                    }).ToList();
                }
            }
            rt.Lista = lst;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibSistema.Sucursal.Entidad.Ficha> 
            Sucursal_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Sucursal.Entidad.Ficha>();

            var r01 = MyData.Sucursal_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nombreDepositoAsignado = "";
            if (s.nombreDepositoAsignado != null) 
            {
                nombreDepositoAsignado = s.nombreDepositoAsignado;
            }
            var nr = new OOB.LibSistema.Sucursal.Entidad.Ficha()
            {
                auto = s.auto,
                autoDepositoPrincipal = s.autoDepositoPrincipal,
                autoGrupo = s.autoGrupo,
                codigo = s.codigo,
                estatus = s.estatus,
                estatusFactMayor = s.estatusFactMayor,
                estatusVentaCredito = s.estatusVentaCredito,
                nombre = s.nombre,
                nombreGrupo = s.nombreGrupo,
                nombreDepositoPrincipal = nombreDepositoAsignado,
                estatusPosVentaSurtido = s.estatusPosVentaSurtido,
                estatusPosVueltoDivisa = s.estatusPosVueltoDivisa,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoAuto 
            Sucursal_Agregar(OOB.LibSistema.Sucursal.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();
            var fichaDTO = new DtoLibSistema.Sucursal.Agregar.Ficha()
            {
                autoGrupo = ficha.autoGrupo,
                nombre = ficha.nombre,
                estatusFactMayor = ficha.estatusFactMayor,
                estatusVentaCredito = ficha.estatusVentaCredito,
                estatusPosVentaSurtido = ficha.estatusPosVentaSurtido,
                estatusPosVueltoDivisa = ficha.estatusPosVueltoDivisa,
            };
            var r01 = MyData.Sucursal_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            rt.Auto = r01.Auto;
            return rt;
        }
        public OOB.Resultado 
            Sucursal_Editar(OOB.LibSistema.Sucursal.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            var fichaDTO = new DtoLibSistema.Sucursal.Editar.Ficha()
            {
                auto = ficha.auto,
                autoGrupo = ficha.autoGrupo,
                nombre = ficha.nombre,
                estatusFactMayor = ficha.estatusFactMayor,
                estatusVentaCredito = ficha.estatusVentaCredito,
                estatusPosVentaSurtido=ficha.estatusPosVentaSurtido,
                estatusPosVueltoDivisa=ficha.estatusPosVueltoDivisa,
            };
            var r01 = MyData.Sucursal_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return rt;
        }
        public OOB.Resultado 
            Sucursal_AsignarDepositoPrincipal(OOB.LibSistema.Sucursal.AsignarDepositoPrincipal.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Sucursal.AsignarDepositoPrincipal.Ficha()
            {
                auto = ficha.auto,
                autoDepositoPrincipal=ficha.autoDepositoPrincipal,
            };
            var r01 = MyData.Sucursal_AsignarDepositoPrincipal(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado 
            Sucursal_QuitarDepositoPrincipal(string autoSuc)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Sucursal_QuitarDepositoPrincipal(autoSuc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado 
            Sucursal_Activar(string autoSuc)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Sucursal_Activar (autoSuc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado 
            Sucursal_Inactivar(string autoSuc)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Sucursal_Inactivar(autoSuc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
    }
}