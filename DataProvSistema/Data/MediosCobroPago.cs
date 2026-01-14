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
            //
            try
            {
                var filtroDTO = new DtoLibSistema.MediosCobroPago.Lista.Filtro()
                {
                };
                var r01 = MyData.MediosCobroPago_GetLista(filtroDTO);
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Lista == null) 
                {
                    throw new Exception("DATA [ LISTA MEDIOS ] NO CARGADA");
                }
                var lst = new List<OOB.LibSistema.MediosCobroPago.Entidad.Ficha>();
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.MediosCobroPago.Entidad.Ficha()
                        {
                            auto = s.auto,
                            codigo = s.codigo,
                            descripcion = s.descripcion,
                            estatusCobro = s.estatusCobro.Trim().ToUpper() == "1",
                            estatusPago = s.estatusPago.Trim().ToUpper() == "1",
                        };
                    }).ToList();
                }
                rt.Lista = lst;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibSistema.MediosCobroPago.Entidad.Ficha> 
            MediosCobroPago_GetFicha_ById(string id)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.MediosCobroPago.Entidad.Ficha>();
            //
            try
            {
                var r01 = MyData.MediosCobroPago_GetFicha_ById(id);
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Entidad == null) 
                {
                    throw new Exception("DATA [ ENTIDAD MEDIO ] NO CARGADA");
                }
                var s = r01.Entidad;
                var nr = new OOB.LibSistema.MediosCobroPago.Entidad.Ficha()
                {
                    auto = s.auto,
                    codigo = s.codigo,
                    descripcion = s.descripcion,
                    estatusCobro = s.estatusCobro.Trim().ToUpper() == "1",
                    estatusPago = s.estatusPago.Trim().ToUpper() == "1",
                    aplicaParaIGTF = s.aplicaParaEl_IGTF.Trim().ToUpper() == "1",
                    aplicaParaModuloCobroAnticipo = s.aplicaParaEl_ModuloCobroAnticipo.Trim().ToUpper() == "1",
                    aplicaParaPOS = s.aplicaParaEl_POS.Trim().ToUpper() == "1",
                    aplicaParaRetornoCambioVuelto = s.aplicaParaEl_RetornoCambioVuelto.Trim().ToUpper() == "1",
                    aplicaParaSolicitarLoteReferencia = s.aplicaParaEl_SolicitarLoteReferencia.Trim().ToUpper() == "1",
                    aplicaParaBonoPagoEnDivisa = s.aplicaParaEl_BonoPagoEnDivisa.Trim().ToUpper() == "1",
                    idMoneda= s.idMoneda,
                };
                rt.Entidad = nr;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.ResultadoAuto 
            MediosCobroPago_AgregarFicha(OOB.LibSistema.MediosCobroPago.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();
            //
            try
            {
                var fichaDTO = new DtoLibSistema.MediosCobroPago.Agregar.Ficha()
                {
                    codigo = ficha.codigo,
                    descripcion = ficha.descripcion,
                    estatusCobro = ficha.estatusCobro,
                    estatusPago = ficha.estatusPago,
                    aplicaParaEl_BonoPagoEnDivisa = ficha.aplicaBonoPagoDivisa,
                    aplicaParaEl_IGTF = ficha.aplicaIGTF,
                    aplicaParaEl_POS = ficha.aplicaParaPos,
                    aplicaParaEl_SolicitarLoteReferencia = ficha.aplicaLoteRef,
                    aplicaParaEl_ModuloCobroAnticipo = ficha.aplicaModuloCobroAnticipo,
                    aplicaParaEl_RetornoCambioVuelto = ficha.aplicaRetornoCambioVuelto,
                    idMoneda = ficha.idMoneda,
                };
                var r01 = MyData.MediosCobroPago_AgregarFicha(fichaDTO);
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                rt.Auto = r01.Auto;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.Resultado 
            MediosCobroPago_EditarFicha(OOB.LibSistema.MediosCobroPago.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            //
            try
            {
                var fichaDTO = new DtoLibSistema.MediosCobroPago.Editar.Ficha()
                {
                    auto = ficha.auto,
                    codigo = ficha.codigo,
                    descripcion = ficha.descripcion,
                    estatusCobro = ficha.estatusCobro,
                    estatusPago = ficha.estatusPago,
                    aplicaParaEl_BonoPagoEnDivisa = ficha.aplicaBonoPagoDivisa,
                    aplicaParaEl_IGTF = ficha.aplicaIGTF,
                    aplicaParaEl_POS = ficha.aplicaParaPos,
                    aplicaParaEl_SolicitarLoteReferencia = ficha.aplicaLoteRef,
                    aplicaParaEl_ModuloCobroAnticipo = ficha.aplicaModuloCobroAnticipo,
                    aplicaParaEl_RetornoCambioVuelto = ficha.aplicaRetornoCambioVuelto,
                    idMoneda = ficha.idMoneda,
                };
                var r01 = MyData.MediosCobroPago_EditarFicha(fichaDTO);
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
    }
}