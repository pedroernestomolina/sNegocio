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

        public OOB.ResultadoLista<OOB.LibSistema.MediosCobroPago.Entidad.Ficha> 
            MediosCobroPago_GetLista(OOB.LibSistema.MediosCobroPago.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.MediosCobroPago.Entidad.Ficha>();

            var filtroDTO = new DtoLibSistema.MediosCobroPago.Lista.Filtro()
            {
            };
            var r01 = MyData.MediosCobroPago_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var lst = new List<OOB.LibSistema.MediosCobroPago.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.MediosCobroPago.Entidad.Ficha()
                        {
                            auto = s.auto,
                            codigo = s.codigo,
                            descripcion = s.descripcion,
                            estatusCobro = s.estatusCobro,
                            estatusPago = s.estatusPago,
                        };
                    }).ToList();
                }
            }
            rt.Lista = lst;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibSistema.MediosCobroPago.Entidad.Ficha> 
            MediosCobroPago_GetFicha_ById(string id)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.MediosCobroPago.Entidad.Ficha>();

            var r01 = MyData.MediosCobroPago_GetFicha_ById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s = r01.Entidad;
            var nr = new OOB.LibSistema.MediosCobroPago.Entidad.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                descripcion = s.descripcion,
                estatusCobro = s.estatusCobro,
                estatusPago = s.estatusPago,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoAuto 
            MediosCobroPago_AgregarFicha(OOB.LibSistema.MediosCobroPago.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibSistema.MediosCobroPago.Agregar.Ficha()
            {
                codigo = ficha.codigo,
                descripcion = ficha.descripcion,
                estatusCobro = ficha.estatusCobro,
                estatusPago = ficha.estatusPago,
            };
            var r01 = MyData.MediosCobroPago_AgregarFicha(fichaDTO);
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
            MediosCobroPago_EditarFicha(OOB.LibSistema.MediosCobroPago.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.MediosCobroPago.Editar.Ficha()
            {
                auto = ficha.auto,
                codigo = ficha.codigo,
                descripcion = ficha.descripcion,
                estatusCobro = ficha.estatusCobro,
                estatusPago = ficha.estatusPago,
            };
            var r01 = MyData.MediosCobroPago_EditarFicha(fichaDTO);
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