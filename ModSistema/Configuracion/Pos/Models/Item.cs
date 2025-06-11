using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Configuracion.Pos.Models
{
    public class Item
    {
        private decimal _tasaPosActual;
        private decimal _tasaPosNueva;
        private decimal _porctDifTasa_Div_Pos;
        private decimal _tasaDivisa;
        private Enumerados.ModoCalculoPrecioProductosNacionales _modoCalculoPrecio;
        //
        public string idPrd { get; set; }
        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public decimal contEmp1 { get; set; }
        public decimal contEmp2 { get; set; }
        public decimal contEmp3 { get; set; }
        public string descEmp1 { get; set; }
        public string descEmp2 { get; set; }
        public string descEmp3 { get; set; }
        public decimal p1 { get; set; }
        public decimal p2 { get; set; }
        public decimal p3 { get; set; }
        public decimal p4 { get; set; }
        public decimal may1 { get; set; }
        public decimal may2 { get; set; }
        public decimal may3 { get; set; }
        public decimal may4 { get; set; }
        public decimal dsp1 { get; set; }
        public decimal dsp2 { get; set; }
        public decimal dsp3 { get; set; }
        public decimal dsp4 { get; set; }
        //
        public decimal p1New { get { return calcula(p1); } }
        public decimal p2New { get { return calcula(p2); } }
        public decimal p3New { get { return calcula(p3); } }
        public decimal p4New { get { return calcula(p4); } }
        public decimal may1New { get { return calcula(may1); } }
        public decimal may2New { get { return calcula(may2); } }
        public decimal may3New { get { return calcula(may3); } }
        public decimal may4New { get { return calcula(may4); } }
        public decimal dsp1New { get { return calcula(dsp1); } }
        public decimal dsp2New { get { return calcula(dsp2); } }
        public decimal dsp3New { get { return calcula(dsp3); } }
        public decimal dsp4New { get { return calcula(dsp4); } }
        //
        public Item()
        {
        }
        //
        public void setTasaPosActual(decimal tasa)
        {
            _tasaPosActual = tasa;
        }
        public void setTasaPosNueva(decimal tasa)
        {
            _tasaPosNueva = tasa;
        }
        public void setTasaDivisa(decimal tasa)
        {
            _tasaDivisa = tasa;
        }
        public void setPorctDifEntreTasa(decimal porct)
        {
            _porctDifTasa_Div_Pos = porct;
        }
        public void setModoCalculoPrecio(Enumerados.ModoCalculoPrecioProductosNacionales modo)
        {
            _modoCalculoPrecio = modo;
        }
        //
        decimal calcula(decimal monto) 
        {
            var rt = 0m;
            switch (_modoCalculoPrecio) 
            {
                case Enumerados.ModoCalculoPrecioProductosNacionales.EnBaseAlPrecioDivisaConBono:
                    {
                        rt= formula_1(monto);
                        break;
                    }
                case Enumerados.ModoCalculoPrecioProductosNacionales.EnBaseAlPrecioDivisaSinBono:
                    {
                        rt= formula_2(monto);
                        break;
                    }
                default:
                    {
                        rt = monto;
                        break;
                    }
            }
            return rt;
        }
        private decimal formula_1(decimal monto)
        {
            //CON EL BONO APLICADO
            //LO QUE SE QUIERE ES ACTUALIZAR EL PRECIO DE VENTA EN Bs, 
            //PERO MANTENIENDO EL MISMO PRECIO INFLADO EN DIVISA
            var tasaPosActual = _tasaPosActual;
            var tasaPosNueva = _tasaPosNueva;
            var rt = 0m;
            if (tasaPosActual > 0)
            {
                rt = Math.Round((monto / _tasaPosActual), 2, MidpointRounding.AwayFromZero);
                rt = rt * tasaPosNueva;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            return rt;
        }
        private decimal formula_2(decimal monto)
        {
            //SIN EL BONO APLICADO
            //LO QUE SE QUIERE ES HALLAR EL PRECIO DE VENTA REAL SI SE PAGARA EN DIVISA 
            //PARA LUEGO AJUSTARLO A LA NUEVA TASA EN DIVISA PARA COSEGUIR EL PRECIO EN Bs INFLADO
            var porctDifTasaDivPos = _porctDifTasa_Div_Pos;
            var tasaPOS= _tasaPosActual;
            var tasaDivisa = _tasaDivisa;
            porctDifTasaDivPos = (porctDifTasaDivPos / 100) + 1;
            var tasaVigente = porctDifTasaDivPos * tasaPOS;
            tasaVigente = Math.Round(tasaVigente, 3, MidpointRounding.AwayFromZero);
            //
            var precioDivisa = (monto / tasaVigente);
            precioDivisa = Math.Round(precioDivisa, 2, MidpointRounding.AwayFromZero);
            //
            var rt = 0m;
            if (precioDivisa > 0)
            {
                rt = precioDivisa * tasaDivisa;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            return rt;
        }
    }
}