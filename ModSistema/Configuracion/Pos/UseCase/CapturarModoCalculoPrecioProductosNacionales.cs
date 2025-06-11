using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Configuracion.Pos.UseCase
{
    public class CapturarModoCalculoPrecioProductosNacionales
    {
        public Enumerados.ModoCalculoPrecioProductosNacionales
            Execute() 
        {
            var r01 = Sistema.MyData.Configuracion_ModoCalculoPrecioProductosNacionales();
            var r = (int)r01.Entidad;
            return (Enumerados.ModoCalculoPrecioProductosNacionales)r;
        }
    }
}