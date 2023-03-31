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
        public OOB.ResultadoLista<OOB.LibSistema.AjustarTasaDivisa.ModoAdm.CapturarData> 
            AjustarTasaDivisa_ModoAdm_CapturarData()
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.AjustarTasaDivisa.ModoAdm.CapturarData>();
            var r01 = MyData.AjustarTasaDivisa_ModoAdm_CapturarData();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<OOB.LibSistema.AjustarTasaDivisa.ModoAdm.CapturarData>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibSistema.AjustarTasaDivisa.ModoAdm.CapturarData()
                        {
                            autoPrd = s.autoPrd,
                            codigoPrd = s.codigoPrd,
                            contEmpCompra = s.contEmpCompra,
                            contEmpVta = s.contEmpVta,
                            costoDivisaEmpCompra = s.costoDivisaEmpCompra,
                            costoMonLocalEmpCompra = s.costoMonLocalEmpCompra,
                            descPrd = s.descPrd,
                            estatusDivisa = s.estatusDivisa,
                            idPrecioVta = s.idPrecioVta,
                            pFullDivisaEmpVta = s.pFullDivisaEmpVta,
                            pNetoMonLocalEmpVta = s.pNetoMonLocalEmpVta,
                            tasaIva = s.tasaIva,
                            descEmpVta = s.descEmpVta,
                            tipoEmpVta = s.tipoEmpVta,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = _lst;
            return rt;
        }
        public OOB.ResultadoEntidad<int> 
            AjustarTasaDivisa_ModoAdm_Ajustar(OOB.LibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.Ficha ficha)
        {
            var rt = new OOB.ResultadoEntidad<int>();
            var fichaDTO = new DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.Ficha()
            {
                estacion = ficha.estacion,
                nota = ficha.nota,
                usuCodigo = ficha.usuCodigo,
                usuNombre = ficha.usuNombre,
                TasaDivisaNueva = ficha.TasaDivisaNueva,
            };
            if (ficha.noAdmDivisa != null)
            {
                fichaDTO.noAdmDivisa = new DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.NoAdmDivisa()
                {
                    prd = ficha.noAdmDivisa.prd.Select(s =>
                    {
                        var nr = new DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.PrdNoAdmDivisa()
                        {
                            autoprd = s.autoprd,
                            costoDivisa = s.costoDivisa,
                            descPrd = s.descPrd,
                        };
                        return nr;
                    }).ToList().Distinct().ToList(),
                    precio = ficha.noAdmDivisa.precio.Select(s =>
                    {
                        var nr = new DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.PrecioNoAdmDivisa()
                        {
                            descPrd= s.descPrd,
                            idPrecioVta = s.idPrecioVta,
                            pDivisaFull = s.pDivisaFull,
                        };
                        return nr;
                    }).ToList(),
                };
            }
            if (ficha.siAdmDivisa != null)
            {
                fichaDTO.siAdmDivisa = new DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.SiAdmDivisa()
                {
                    prd = ficha.siAdmDivisa.prd.Select(s =>
                    {
                        var nr = new DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.PrdSiAdmDivisa()
                        {
                            autoprd = s.autoprd,
                            descPrd = s.descPrd,
                            costo = s.costo,
                            costoImp = s.costoImp,
                            costoImpUnd = s.costoImpUnd,
                            costoProv = s.costoProv,
                            costoProvUnd = s.costoProvUnd,
                            costoUnd = s.costoUnd,
                            costoVario = s.costoVario,
                            costoVarioUnd = s.costoVarioUnd,
                        };
                        return nr;
                    }).ToList().Distinct().ToList(),
                    precio = ficha.siAdmDivisa.precio.Select(s =>
                    {
                        var nr = new DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.PrecioSiAdmDivisa()
                        {
                            descPrd = s.descPrd,
                            idPrecioVta = s.idPrecioVta,
                            pnetoMonLocal = s.pnetoMonLocal,
                        };
                        return nr;
                    }).ToList(),
                    historia = ficha.siAdmDivisa.historia.Select(s =>
                    {
                        var nr = new DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.Historia()
                        {
                            autoPrd = s.autoPrd,
                            empCont = s.empCont,
                            empDesc = s.empDesc,
                            fullDivisa = s.fullDivisa,
                            netoMonLocal = s.netoMonLocal,
                            prdCodigo = s.prdCodigo,
                            prdDesc = s.prdDesc,
                            tipoEmpaqueVenta = s.tipoEmpaqueVenta,
                            tipoPrecioVenta = s.tipoPrecioVenta,
                        };
                        return nr;
                    }).ToList(),
                };
            }
            var r01 = MyData.AjustarTasaDivisa_ModoAdm_Ajustar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            rt.Entidad=r01.Entidad;
            return rt;
        }
    }
}