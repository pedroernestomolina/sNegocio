using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema
{
    public class Enumerados
    {
        public enum modoConfSistema { SinDefinir = -1, Basico = 1, Sucursal = 2, Administrativo = 3 } ;
        public enum modoCalculoDiferenciaEntreTasas { SinDefinir = -1, BCV = 1, PARALELO } ;
    }
}