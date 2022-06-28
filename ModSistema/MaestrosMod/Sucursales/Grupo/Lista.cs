﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Grupo
{
    
    public class Lista: IGrupoLista
    {

        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;


        public int CntItems { get { return _bs.Count; } }
        public BindingSource Source { get { return _bs; } }
        public data ItemActual { get { return (data)_bs.Current; } }


        public Lista()
        {
            _lst = new List<data>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _lst.Clear();
            _bs.CurrencyManager.Refresh();
        }
        public void setLista(IEnumerable<data> lst)
        {
            _bl.Clear();
            if (lst != null)
            {
                foreach (var it in lst.OrderBy(o => o.descripcion).ToList())
                {
                    _bl.Add(it);
                }
            }
            _bs.CurrencyManager.Refresh();
        }

        public void Agregar(data dat)
        {
            _bl.Add(dat);
            var l = _bl.ToList();
            setLista(l);
            var ind = _bl.IndexOf(_bl.FirstOrDefault(f => f.auto == dat.auto));
            _bs.Position = ind;
        }
        public void Actualizar(data data)
        {
            var it = _bl.FirstOrDefault(f => f.auto == data.auto);
            if (it != null)
            {
                _bl.Remove(it);
            }
            Agregar(data);
        }
        public void EliminarItemActual()
        {
            var it = ItemActual;
            _bl.Remove(it);
            _bs.CurrencyManager.Refresh();
        }

    }

}