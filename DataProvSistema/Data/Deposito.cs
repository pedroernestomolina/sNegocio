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

        public OOB.ResultadoLista<OOB.LibSistema.Deposito.Entidad.Ficha> 
            Deposito_GetLista(OOB.LibSistema.Deposito.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.Deposito.Entidad.Ficha>();

            var filtroDTO = new DtoLibSistema.Deposito.Lista.Filtro();
            var r01 = MyData.Deposito_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var lst = new List<OOB.LibSistema.Deposito.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.Deposito.Entidad.Ficha()
                        {
                            auto = s.auto,
                            codigo = s.codigo,
                            nombre = s.nombre,
                            estatus = s.estatus,
                            nombreSucursal = s.nombreSucursal,
                        };
                    }).ToList();
                }
            }
            rt.Lista = lst;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibSistema.Deposito.Entidad.Ficha> 
            Deposito_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Deposito.Entidad.Ficha>();

            var r01 = MyData.Deposito_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Deposito.Entidad.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
                estatus = s.estatus,
                autoSucursal = s.autoSucursal,
                codigoSucursal = s.codigoSucursal,
                nombreSucursal = s.nombreSucursal,
            };
            rt.Entidad= nr;

            return rt;
        }
        public OOB.ResultadoAuto 
            Deposito_Agregar(OOB.LibSistema.Deposito.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibSistema.Deposito.Agregar.Ficha()
            {
                autoSucursal = ficha.autoSucurusal,
                codigoSucursal = ficha.codigoSucursal,
                nombre = ficha.nombre,
            };
            var r01 = MyData.Deposito_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Auto = r01.Auto;

            return rt;
        }
        public OOB.Resultado 
            Deposito_Editar(OOB.LibSistema.Deposito.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Deposito.Editar.Ficha()
            {
                auto = ficha.auto,
                nombre = ficha.nombre,
                autoSucursal = ficha.autoSucurusal,
                codigoSucursal = ficha.codigoSucursal,
            };
            var r01 = MyData.Deposito_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado
            Deposito_Activar(string idDep)
        {
            var rt = new OOB.Resultado();
            
            var r01 = MyData.Deposito_Activar(idDep);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado 
            Deposito_Inactivar(string idDep)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Deposito_Inactivar(idDep);
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