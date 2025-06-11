using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.AjustarTasaPos.AjustarData
{
    public class HistoricoPrecio
    {
        public string idPrd { get; set; }
        public string nombrePrd { get; set; }
        public string motivoCambio { get; set; }
        public string identificadorPrecio { get; set; }
        public decimal precioNuevo { get; set; }
        public int contEmpq { get; set; }
        public string descEmpq { get; set; }
        public HistoricoPrecio(string id, string nombre, int contEmp, string descEmp, string idPrecio, string motivo, decimal pNuevo)
        {
            idPrd = id;
            nombrePrd = nombre;
            contEmpq = contEmp;
            descEmpq = descEmp;
            identificadorPrecio = idPrecio;
            motivoCambio = motivo;
            precioNuevo = Math.Round(pNuevo,2, MidpointRounding.AwayFromZero);
        }
    }
}
