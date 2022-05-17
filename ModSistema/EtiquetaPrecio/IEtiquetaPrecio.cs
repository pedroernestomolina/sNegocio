using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.EtiquetaPrecio
{
    
    public interface IEtiquetaPrecio: IGestion
    {

        string Etiqueta1 { get; }
        string Etiqueta2 { get; }
        string Etiqueta3 { get; }

        void setEtiqueta1(string p);
        void setEtiqueta2(string p);
        void setEtiqueta3(string p);

        void Abandonar();
        bool AbandonarIsOk { get; }

        void Procesar();
        bool ProcesarIsOk { get; }

    }

}
