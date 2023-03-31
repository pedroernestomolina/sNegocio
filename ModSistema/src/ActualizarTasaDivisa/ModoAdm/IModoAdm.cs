using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.src.ActualizarTasaDivisa.ModoAdm
{
    public interface IModoAdm: ITasa
    {
        string Get_TituloFuncion { get; }
        decimal Get_TasaDivisaValorActual { get; }
        decimal Get_TasaDivisaValorNuevo { get; }
        void setTasaDivisa(decimal monto);
    }
}