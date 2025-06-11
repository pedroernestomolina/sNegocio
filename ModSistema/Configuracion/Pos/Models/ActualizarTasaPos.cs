using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Configuracion.Pos.Models
{
    public class ActualizarTasaPos
    {
        public enum formulaCalculoPrecioVenta { SinDefinir = -1, EnBaseAlPrecioDivisaSinBono = 1, EnBaseAlPrecioDivisaConBono };
        //
        private decimal _tasaPosActual;
        private decimal _tasaPosNueva;
        private List<Item> _itemsActualzar;
        private decimal _dsctoPermitir;
        private bool _aceptarDsctoPorPagoDivisa;
        private decimal _tasaDivisa;
        private decimal _porctDifEntreTasas;
        private formulaCalculoPrecioVenta _modoCalculoPrecio;
        //
        public decimal GetTasaPosNueva { get { return _tasaPosNueva; } }
        public decimal GetDesctoPermitir { get { return _dsctoPermitir; } }
        public bool GetAceptarDsctoPorPagoDivisa { get { return _aceptarDsctoPorPagoDivisa; } }
        public List<Item> ItemsActualizar { get { return _itemsActualzar; } }
        //
        public ActualizarTasaPos()
        {
            _modoCalculoPrecio = formulaCalculoPrecioVenta.SinDefinir;
            _tasaPosActual = 0m;
            _tasaPosNueva = 0m;
            _tasaDivisa = 0m;
            _dsctoPermitir = 0m;
            _porctDifEntreTasas = 0m;
            _aceptarDsctoPorPagoDivisa = false;
            _itemsActualzar = new List<Item>();
        }
        public void Inicializa()
        {
            _modoCalculoPrecio = formulaCalculoPrecioVenta.SinDefinir;
            _tasaPosActual = 0m;
            _tasaPosNueva = 0m;
            _tasaDivisa = 0m;
            _dsctoPermitir = 0m;
            _porctDifEntreTasas = 0m;
            _aceptarDsctoPorPagoDivisa = false;
            _itemsActualzar.Clear();
        }
        public void setTasaPosActual(decimal tasaPosActual)
        {
            _tasaPosActual = tasaPosActual;
        }
        public void setTasaPosNueva(decimal tasa)
        {
            _tasaPosNueva = tasa;
        }
        public void setDesctoPermitir(decimal dscto)
        {
            _dsctoPermitir = dscto;
        }
        public void setAceptarDsctoPorPagoDivisa(bool aceptar)
        {
            _aceptarDsctoPorPagoDivisa = aceptar;
        }
        public void setTasaDivisa(decimal tasa)
        {
            _tasaDivisa = tasa;
        }
        public void setPorctDifEntreTasas(decimal porct)
        {
            _porctDifEntreTasas = porct;
        }
        public void setAplicarFormulaCalculoPrecio(formulaCalculoPrecioVenta modo)
        {
            _modoCalculoPrecio = modo;
        }
        public void AgregarItemParaActualizar(Item it)
        {
            _itemsActualzar.Clear();
            it.setTasaPosActual(_tasaPosActual);
            it.setTasaPosNueva(_tasaPosNueva);
            it.setTasaDivisa(_tasaDivisa);
            it.setPorctDifEntreTasa(_porctDifEntreTasas);
            it.setModoCalculoPrecio(_modoCalculoPrecio);
            _itemsActualzar.Add(it);
        }
    }
}