using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod
{


    public class Maestro: IMaestro
    {


        private ITipoMaestro _gTipo;
        private ILista _gLista;


        public string Titulo { get { return _gTipo.GetTitulo; } }
        public int CntItems { get { return _gLista.CntItems; } }
        public BindingSource Source { get { return _gLista.Source; } }
        public data ItemActual { get { return _gLista.ItemActual; } }


        public Maestro(ILista lista) 
        {
            _gLista = lista;
        }


        public void Inicializa()
        {
            _gLista.Inicializa();
        }


        public void Inicia()
        {
            if (CargarData()) 
            {
                _gTipo.Inicia(this);
            }
        }

        private bool CargarData()
        {
            if (_gTipo.CargarData()) 
            {
                _gLista.setLista(_gTipo.Lista);
                return true;
            }
            return false;
        }


        public void setTipoMaestro(ITipoMaestro ctr)
        {
            _gTipo = ctr;
        }


        public bool AgregarIsOk { get { return _gTipo.AgregarIsOk; } }
        public void AgregarItem()
        {
            _gTipo.AgregarItem();
            if (_gTipo.AgregarIsOk) 
            {
                _gLista.Agregar(_gTipo.ItemAgregarEditar);
            }
        }

        public bool EditarIsOk { get { return _gTipo.EditarIsOk; } }
        public void EditarItem()
        {
            if (ItemActual == null)
            {
                return;
            }
            _gTipo.EditarItem(ItemActual);
            if (_gTipo.EditarIsOk)
            {
                _gLista.Actualizar(_gTipo.ItemAgregarEditar);
            }
        }

    }

}