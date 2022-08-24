using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.TasaDivisa.Porcentaje
{
    

    public class dataHndPrecio
    {

        public string autoProducto { get; set; }
        public int idPrecio { get; set; }
        public decimal neto_1 { get; set; }
        public decimal neto_2 { get; set; }
        public decimal neto_3 { get; set; }
        public decimal fullDivisa_1 { get; set; }
        public decimal fullDivisa_2 { get; set; }
        public decimal fullDivisa_3 { get; set; }
        public bool esAdmDivisa { get; set; }


        public dataHndPrecio() 
        {
            autoProducto = "";
            idPrecio = -1;
            neto_1 = 0.0m;
            neto_2 = 0.0m;
            neto_3 = 0.0m;
            fullDivisa_1 = 0.0m;
            fullDivisa_2 = 0.0m;
            fullDivisa_3 = 0.0m;
            esAdmDivisa = false;
        }

        public decimal CalculaNeto(decimal monto, decimal tasaDivisa, decimal tasaIva)
        {
            var result = 0.0m;

            var rt = monto;
            rt *= tasaDivisa;
            if (rt > 0.0m)
            {
                if (tasaIva > 0.0m) 
                {
                    rt /= (1+(tasaIva/100));
                }
            }
            result = rt;

            return result;
        }

        public decimal CalculaFull(decimal monto, decimal tasa)
        {
            var result = 0.0m;

            var rt = monto;
            if (tasa> 0.0m)
            {
                rt += (monto * tasa / 100);
            }
            result = rt;

            return result;
        }

    }

}