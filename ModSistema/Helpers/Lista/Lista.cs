using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Helpers.Lista
{

    public class Lista: ILista
    {

        private List<data> _lst;
        private BindingSource _bs;
        private string _titulo;


        public int CntItems { get { return _bs.Count; } }
        public BindingSource SourceData { get { return _bs; } }
        public string Titulo { get { return _titulo; } }


        public Lista() 
        {
            _lst = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _titulo = "";
        }


        public void Inicializa()
        {
            _titulo = "";
            _lst.Clear();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }

        ListaFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new ListaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setTitulo(string p)
        {
            _titulo = p;
        }
        public void setData(List<data> list)
        {
            _lst.Clear();
            foreach (var rg in list)
            {
                _lst.Add(rg);
            }
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }

    }

}