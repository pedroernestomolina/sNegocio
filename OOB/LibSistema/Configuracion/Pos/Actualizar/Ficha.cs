using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Configuracion.Pos.Actualizar
{
    public class Ficha
    {
        public string estacion { get; set; }
        public string usuario { get; set; }
        public decimal tasaManejoDivisaPos { get; set; }
        public bool permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa { get; set; }
        public decimal valorMaximoDescuentoPermitido { get; set; }
        public decimal porcAumentoPreciosDePrdNoAdmPorDivisa { get; set; }
        public List<OOB.LibSistema.AjustarTasaPos.AjustarData.Producto> productosAjustar { get; set; }
        public List<OOB.LibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio> historicoPreciosAgregar { get; set; }
        public int idMonLocal { get; set; }
        //
        public decimal FactorVariacion { get; set; }
        public string HabilitarBono { get; set; }
        public string MonedaCodigo { get; set; }
        public string MonedaSimbolo { get; set; }
        public decimal PorctAumentoPrdNoDivisa { get; set; }
        public decimal PorctBono { get; set; }
        public decimal PorctDiferenciaTasaSistemaTasaPos { get; set; }
        public decimal TasaDivisaSistema { get; set; }
        public string UsuarioCodigo { get; set; }
        public decimal ValorAnterior { get; set; }
        public Ficha()
        {
            estacion = "";
            usuario = "";
            tasaManejoDivisaPos = 0m;
            permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa = false;
            valorMaximoDescuentoPermitido = 0m;
            porcAumentoPreciosDePrdNoAdmPorDivisa = 0m;
            productosAjustar = null;
            historicoPreciosAgregar = null;
            idMonLocal = -1;
            //
            FactorVariacion = 0m;
            HabilitarBono = "";
            MonedaCodigo = "";
            MonedaSimbolo = "";
            PorctAumentoPrdNoDivisa = 0m;
            PorctBono = 0m;
            PorctDiferenciaTasaSistemaTasaPos = 0m;
            TasaDivisaSistema = 0m;
            UsuarioCodigo = "";
            ValorAnterior = 0m;
        }
    }
}