using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.TasaDivisa
{
    
    public class Gestion
    {
        private IGestion miGestion;
        private ModSistema.src.IFabrica _fabrica;
        private Func<bool> _rg1;
        private Func<bool> _rg2;


        public string TituloFuncion { get { return miGestion.TituloFuncion; } }
        public decimal ValorActual { get { return miGestion.ValorActual; } }
        public decimal ValorNuevo { set { miGestion.ValorNuevo= value; } }
        public bool ActualizacionIsOk { get; set; }


        public Gestion()
        {
        }


        public void setGestion(IGestion gestion) 
        {
            miGestion = gestion;
        }


        TasaDivisaFrm frm;
        public void Inicia() 
        {
            ActualizacionIsOk = false;
            if (miGestion.CargarData())
            {
                if (frm == null)
                {
                    frm = new TasaDivisaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void Procesar()
        {
            ActualizacionIsOk = miGestion.Procesar(_rg1, _rg2);
        }


        public void InyectarReglaNegocio_ActualizarCostoProductos_NoAdmDivisa(Func<bool> func)
        {
            _rg1 = func;
        }
        public void InyectarReglaNegocio_ActualizarCostoPrecio_EnBaseMonedaActual(Func<bool> func)
        {
            _rg2 = func;
        }
    }
}