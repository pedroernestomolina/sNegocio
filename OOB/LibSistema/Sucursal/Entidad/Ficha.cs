using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Sucursal.Entidad
{
    

    public class Ficha
    {

        public string auto { get; set; }
        public string autoGrupo { get; set; }
        public string autoDepositoPrincipal { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string estatus { get; set; }
        public string estatusFactMayor { get; set; }
        public string estatusVentaCredito { get; set; }
        public string nombreGrupo { get; set; }
        public string nombreDepositoPrincipal { get; set; }
        public bool esActivo { get { return estatus == "1" ? true : false; } }
        public bool activarFactMayor { get { return estatusFactMayor == "1" ? true : false; } }
        public bool activarVentaCredito { get { return estatusVentaCredito == "1" ? true : false; } }


        public Ficha() 
        {
            auto = "";
            autoGrupo = "";
            autoDepositoPrincipal = "";
            codigo = "";
            nombre = "";
            estatus = "";
            estatusFactMayor = "";
            estatusVentaCredito= "";
            nombreGrupo = "";
            nombreDepositoPrincipal = "";
        }

    }

}