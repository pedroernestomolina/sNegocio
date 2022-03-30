using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Helpers.Lista
{


    public interface ILista: IGestion
    {

        BindingSource SourceData { get; }
        int CntItems { get; }
        string Titulo { get; }
        void setTitulo(string p);
        void setData(List<data> list);

    }

}