using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod
{
    

    public interface IAgregarEditar: IGestion
    {

        bool IsOk { get; }
        string Titulo { get; }


        void Procesar();
        bool ProcesarIsOk { get; }

        void Abandonar();
        bool AbandonarIsOk { get; }


        object IdItemRegistrado { get; }
        void setIdItemEditar(object p);

    }

}