using DataProvSistema.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{

    public partial class DataProv : IData
    {

        public OOB.ResultadoLista<OOB.LibSistema.SucursalGrupo.Entidad.Ficha>
            SucursalGrupo_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.SucursalGrupo.Entidad.Ficha>();

            var r01 = MyData.SucursalGrupo_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.LibSistema.SucursalGrupo.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.SucursalGrupo.Entidad.Ficha()
                        {
                            auto = s.auto,
                            nombre = s.nombre,
                            estatus = s.estatus,
                            refPrecio = s.refPrecio,
                        };
                    }).ToList();
                }
            }
            rt.Lista = lst;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibSistema.SucursalGrupo.Entidad.Ficha>
            SucursalGrupo_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.SucursalGrupo.Entidad.Ficha>();

            var r01 = MyData.SucursalGrupo_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s = r01.Entidad;
            var ent = new OOB.LibSistema.SucursalGrupo.Entidad.Ficha()
            {
                auto = s.auto,
                nombre = s.nombre,
                estatus = s.estatus,
                refPrecio = s.refPrecio,
                idPrecio = s.idPrecio,
            };
            rt.Entidad = ent;

            return rt;
        }
        public OOB.ResultadoAuto
            SucursalGrupo_Agregar(OOB.LibSistema.SucursalGrupo.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibSistema.GrupoSucursal.Agregar.Ficha()
            {
                nombre = ficha.nombre,
                idPrecio = ficha.idPrecio,
            };
            var r01 = MyData.SucursalGrupo_Agregar(fichaDTO);
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
            SucursalGrupo_Editar(OOB.LibSistema.SucursalGrupo.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.GrupoSucursal.Editar.Ficha()
            {
                auto = ficha.auto,
                idPrecio = ficha.idPrecio,
                nombre = ficha.nombre,
            };
            var r01 = MyData.SucursalGrupo_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado
            SucursalGrupo_Eliminar(string id)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.SucursalGrupo_Eliminar(id);
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