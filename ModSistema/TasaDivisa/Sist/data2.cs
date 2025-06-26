using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.TasaDivisa.Sist
{
    
    public class data2
    {

        private OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha it;
        private decimal valorDivisa;
        private bool _actualizarCostoPrecioProductosEnBaseMonedaActual;

        public string AutoPrd { get { return it.autoPrd; } }
        public decimal CostoDivisa 
        {
            get 
            {
                var rt = 0.0m;
                if (_actualizarCostoPrecioProductosEnBaseMonedaActual)
                {
                    rt = it.costoMoneda / valorDivisa;
                }
                else
                {
                    rt = it.costoDivisa;
                }
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            } 
        }
        public decimal CostoDivisaUnd { get { return CostoDivisa / it.contenido; } } 
        public decimal CostoMonedaActual
        {
            get
            {
                var rt = 0.0m;
                if (_actualizarCostoPrecioProductosEnBaseMonedaActual)
                {
                    rt = it.costoMoneda;
                }
                else
                {
                    rt = it.costoDivisa * valorDivisa;
                }
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        public decimal CostoMonedaActualUnd { get { return CostoMonedaActual / it.contenido; } }
        public decimal Precio_1 { get { return CalculoPrecioNetoMonActual(it.precioNetoMoneda_1, it.precioFullDivisa_1); } }
        public decimal Precio_2 { get { return CalculoPrecioNetoMonActual(it.precioNetoMoneda_2, it.precioFullDivisa_2); } }
        public decimal Precio_3 { get { return CalculoPrecioNetoMonActual(it.precioNetoMoneda_3, it.precioFullDivisa_3); } }
        public decimal Precio_4 { get { return CalculoPrecioNetoMonActual(it.precioNetoMoneda_4, it.precioFullDivisa_4); } }
        public decimal Precio_5 { get { return CalculoPrecioNetoMonActual(it.precioNetoMoneda_5, it.precioFullDivisa_5); } }
        public decimal PrecioMay_1 { get { return CalculoPrecioNetoMonActual(it.precioNetoMonedaMay_1, it.precioFullDivisaMay_1); } }
        public decimal PrecioMay_2 { get { return CalculoPrecioNetoMonActual(it.precioNetoMonedaMay_2, it.precioFullDivisaMay_2); } }
        public decimal PrecioMay_3 { get { return CalculoPrecioNetoMonActual(it.precioNetoMonedaMay_3, it.precioFullDivisaMay_3); } }
        public decimal PrecioMay_4 { get { return CalculoPrecioNetoMonActual(it.precioNetoMonedaMay_4, it.precioFullDivisaMay_4); } }
        public decimal PrecioDsp_1 { get { return CalculoPrecioNetoMonActual(it.precioNetoMonedaDsp_1, it.precioFullDivisaDsp_1); } }
        public decimal PrecioDsp_2 { get { return CalculoPrecioNetoMonActual(it.precioNetoMonedaDsp_2, it.precioFullDivisaDsp_2); } }
        public decimal PrecioDsp_3 { get { return CalculoPrecioNetoMonActual(it.precioNetoMonedaDsp_3, it.precioFullDivisaDsp_3); } }
        public decimal PrecioDsp_4 { get { return CalculoPrecioNetoMonActual(it.precioNetoMonedaDsp_4, it.precioFullDivisaDsp_4); } }

        private decimal CalculoPrecioNetoMonActual(decimal netMonAct, decimal fullDivisa)
        {
            var rt = 0m;
            if (_actualizarCostoPrecioProductosEnBaseMonedaActual) 
            {
                rt = netMonAct;
            }
            else
            {
                rt = calculaNeto(fullDivisa, it.tasaIva) * valorDivisa;
            }
            return rt;
        }

        private decimal CalculaFull(decimal monto)
        {
            var rt =0.0m;
            rt = monto / ((it.tasaIva / 100) + 1);
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }

        public decimal precioFullMoneda_EnDivisa(int id)
        {
            var rt = 0.0m;
            var pn = 0.0m;
            if (_actualizarCostoPrecioProductosEnBaseMonedaActual)
            {
                switch (id)
                {
                    case 1:
                        pn = it.precioNetoMoneda_1; break;
                    case 2:
                        pn = it.precioNetoMoneda_2; break;
                    case 3:
                        pn = it.precioNetoMoneda_3; break;
                    case 4:
                        pn = it.precioNetoMoneda_4; break;
                    case 5:
                        pn = it.precioNetoMoneda_5; break;
                    case 6: //MAYOR 1
                        pn = it.precioNetoMonedaMay_1; break;
                    case 7: //MAYOR 2
                        pn = it.precioNetoMonedaMay_2; break;
                    case 8: //MAYOR 3
                        pn = it.precioNetoMonedaMay_3; break;
                    case 9: //MAYOR 4
                        pn = it.precioNetoMonedaMay_4; break;
                    case 10:
                        pn = it.precioNetoMonedaDsp_1; break;
                    case 11:
                        pn = it.precioNetoMonedaDsp_2; break;
                    case 12:
                        pn = it.precioNetoMonedaDsp_3; break;
                    case 13:
                        pn = it.precioNetoMonedaDsp_4; break;
                }
                rt = CalculaFull(pn) / valorDivisa;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            else 
            {
                switch (id)
                {
                    case 1:
                        pn = it.precioFullDivisa_1; break;
                    case 2:
                        pn = it.precioFullDivisa_2; break;
                    case 3:
                        pn = it.precioFullDivisa_3; break;
                    case 4:
                        pn = it.precioFullDivisa_4; break;
                    case 5:
                        pn = it.precioFullDivisa_5; break;
                    case 6: //MAYOR 1
                        pn = it.precioFullDivisaMay_1; break;
                    case 7: //MAYOR 2
                        pn = it.precioFullDivisaMay_2; break;
                    case 8: //MAYOR 3
                        pn = it.precioFullDivisaMay_3; break;
                    case 9: //MAYOR 4
                        pn = it.precioFullDivisaMay_4; break;
                    case 10:
                        pn = it.precioFullDivisaDsp_1; break;
                    case 11:
                        pn = it.precioFullDivisaDsp_2; break;
                    case 12:
                        pn = it.precioFullDivisaDsp_3; break;
                    case 13:
                        pn = it.precioFullDivisaDsp_4; break;
                }
                rt = pn;
            }
            return rt;
        }



        private decimal calculaNeto(decimal monto, decimal tasa)
        {
            var rt = monto;
            if (tasa > 0) 
            {
                rt = monto / (1m + (tasa / 100m));

            }
            return rt;
        }


        public data2(OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha it, decimal montoDivisa)
        {
            this.it = it;
            this.valorDivisa = montoDivisa;
        }
        public void setActualizarCostoPrecioProductosEnBaseMonedaActual(bool modo)
        {
            _actualizarCostoPrecioProductosEnBaseMonedaActual = modo;
        }
    }

}