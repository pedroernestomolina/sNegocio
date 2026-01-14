using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ModSistema.MaestrosMod.MediosCobro.AgregarEditar.Domain.Models
{
    public class Monedas: LibUtilitis.Opcion.IData
    {
        public OOB.LibSistema.Moneda.Entidad.Ficha Ficha { get; set; }
        public string codigo { get; set; }
        public string desc { get; set; }
        public string id { get; set; }
    }
}