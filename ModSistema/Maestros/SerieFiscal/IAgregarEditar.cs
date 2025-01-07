using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros.SerieFiscal
{
    public interface IAgregarEditar
    {
        string TituloFicha { get; }
        string GetSerie { get; }
        string GetControl { get; }
        int GetCorrelativo { get; }
        bool GetAplicaFactura { get; }
        bool GetAplicaNtDebito { get; }
        bool GetAplicaNtCredito { get; }
        bool GetAplicaNtEntrega { get; }
        bool GetAplicaLibroVenta { get; }
        bool SalirIsOk { get; }
        bool AbandonarIsOk { get; }
        bool ProcesarIsOk { get; }
        string AutoFichaNueva { get; }
        //
        void Inicializa();
        void setSerie(string p);
        void setCorrelativo(int p);
        void setControl(string p);
        void Procesar();
        void Salir();
        bool CargarData();
        void setFichaEditar(string p);
        void sw_Factura();
        void sw_NtDebito();
        void sw_NtCredito();
        void sw_NtEntrega();
        void sw_LibroVenta();
    }
}