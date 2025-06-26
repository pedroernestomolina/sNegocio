using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Configuracion.Pos.UseCase
{
    public class ProcesarCambio
    {
        public void Execute(Models.ActualizarTasaPos modelo)
        {
            var _lst = modelo.ItemsActualizar.Select(s =>
            {
                var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.Producto()
                {
                    codigoPrd = s.codigoPrd,
                    dsp1New = Math.Round(s.dsp1New,2, MidpointRounding.AwayFromZero) ,
                    dsp2New = Math.Round(s.dsp2New,2, MidpointRounding.AwayFromZero) ,
                    dsp3New = Math.Round(s.dsp3New,2, MidpointRounding.AwayFromZero) ,
                    dsp4New = Math.Round(s.dsp4New,2, MidpointRounding.AwayFromZero) ,
                    idPrd = s.idPrd,
                    may1New = Math.Round(s.may1New,2, MidpointRounding.AwayFromZero) ,
                    may2New = Math.Round(s.may2New,2, MidpointRounding.AwayFromZero) ,
                    may3New = Math.Round(s.may3New,2, MidpointRounding.AwayFromZero) ,
                    may4New = Math.Round(s.may4New,2, MidpointRounding.AwayFromZero) ,
                    nombrePrd = s.nombrePrd,
                    p1New = Math.Round(s.p1New,2, MidpointRounding.AwayFromZero) ,
                    p2New = Math.Round(s.p2New,2, MidpointRounding.AwayFromZero) ,
                    p3New = Math.Round(s.p3New,2, MidpointRounding.AwayFromZero) ,
                    p4New = Math.Round(s.p4New, 2, MidpointRounding.AwayFromZero),
                };
                return rt;
            }).ToList();
            var _motivo = "ACTUALIZACION TASA POS";
            var _lst2 = new List<OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio>();
            foreach (var s in modelo.ItemsActualizar)
            {
                if (s.p1New > 0)
                {
                    var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio(
                        s.idPrd,
                        s.nombrePrd,
                        (int)s.contEmp1,
                        s.descEmp1,
                        "1",
                        _motivo,
                        s.p1New);
                    _lst2.Add(rt);
                }
                if (s.p2New > 0)
                {
                    var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio(
                        s.idPrd,
                        s.nombrePrd,
                        (int)s.contEmp1,
                        s.descEmp1,
                        "2",
                        _motivo,
                        s.p2New);
                    _lst2.Add(rt);
                }
                if (s.p3New > 0)
                {
                    var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio(
                        s.idPrd,
                        s.nombrePrd,
                        (int)s.contEmp1,
                        s.descEmp1,
                        "3",
                        _motivo,
                        s.p3New);
                    _lst2.Add(rt);
                }
                if (s.p4New > 0)
                {
                    var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio(
                        s.idPrd,
                        s.nombrePrd,
                        (int)s.contEmp1,
                        s.descEmp1,
                        "4",
                        _motivo,
                        s.p4New);
                    _lst2.Add(rt);
                }
                //
                if (s.may1New > 0)
                {
                    var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio(
                        s.idPrd,
                        s.nombrePrd,
                        (int)s.contEmp2,
                        s.descEmp2,
                        "MY1",
                        _motivo,
                        s.may1New);
                    _lst2.Add(rt);
                }
                if (s.may2New > 0)
                {
                    var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio(
                        s.idPrd,
                        s.nombrePrd,
                        (int)s.contEmp2,
                        s.descEmp2,
                        "MY2",
                        _motivo,
                        s.may2New);
                    _lst2.Add(rt);
                }
                if (s.may3New > 0)
                {
                    var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio(
                        s.idPrd,
                        s.nombrePrd,
                        (int)s.contEmp2,
                        s.descEmp2,
                        "MY3",
                        _motivo,
                        s.may3New);
                    _lst2.Add(rt);
                }
                if (s.may4New > 0)
                {
                    var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio(
                        s.idPrd,
                        s.nombrePrd,
                        (int)s.contEmp2,
                        s.descEmp2,
                        "MY4",
                        _motivo,
                        s.may4New);
                    _lst2.Add(rt);
                }
                //
                if (s.dsp1New > 0)
                {
                    var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio(
                        s.idPrd,
                        s.nombrePrd,
                        (int)s.contEmp3,
                        s.descEmp3,
                        "DS1",
                        _motivo,
                        s.dsp1New);
                    _lst2.Add(rt);
                }
                if (s.dsp2New > 0)
                {
                    var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio(
                        s.idPrd,
                        s.nombrePrd,
                        (int)s.contEmp3,
                        s.descEmp3,
                        "DS2",
                        _motivo,
                        s.dsp2New);
                    _lst2.Add(rt);
                }
                if (s.dsp3New > 0)
                {
                    var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio(
                        s.idPrd,
                        s.nombrePrd,
                        (int)s.contEmp3,
                        s.descEmp3,
                        "DS3",
                        _motivo,
                        s.dsp3New);
                    _lst2.Add(rt);
                }
                if (s.dsp4New > 0)
                {
                    var rt = new OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio(
                        s.idPrd,
                        s.nombrePrd,
                        (int)s.contEmp3,
                        s.descEmp2,
                        "DS4",
                        _motivo,
                        s.dsp4New);
                    _lst2.Add(rt);
                }
            }
            var fichaOOB = new OOB.LibSistema.Configuracion.Pos.Actualizar.Ficha()
            {
                estacion = Sistema.EstacionEquipo,
                usuario = Sistema.UsuarioP.nombre,
                tasaManejoDivisaPos = modelo.GetTasaPosNueva,
                permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa = modelo.GetAceptarDsctoPorPagoDivisa,
                valorMaximoDescuentoPermitido = modelo.GetDesctoPermitir,
                porcAumentoPreciosDePrdNoAdmPorDivisa = modelo.GetPorcAumentoPreciosPrdNoAdmDivisa,
                productosAjustar = _lst,
                historicoPreciosAgregar = _lst2,
            };
            var r01 = Sistema.MyData.Configuracion_Pos_Actualizar(fichaOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
        }
    }
}