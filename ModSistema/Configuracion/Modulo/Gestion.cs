using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Configuracion.Modulo
{
    
    public class Gestion: IGestion
    {

        private bool _abandonarFichaIsOk;
        private bool _procesarFichaIsOk;
        private data _data;
        private Filtros.IOpcion _opcVisDoc;
        private Filtros.IOpcion _opcCalculoDifTasa;
        private Filtros.IOpcion _opcCalculoPrecioPrdNac;


        public BindingSource SourcePrdInactivo { get { return _opcVisDoc.Source; } }
        public string PrdInactivoID { get { return _opcVisDoc.GetId; } }
        public bool AbandonarFichaIsOk { get { return _abandonarFichaIsOk; } }
        public bool ProcesarFichaIsOk { get { return _procesarFichaIsOk; } }
        public string ClaveMaxima { get { return _data.ClaveMaxima; } }
        public string ClaveMedia { get { return _data.ClaveMedia; } }
        public string ClaveMinima { get { return _data.ClaveMinima; } }
        public decimal CntDocVisualizar { get { return _data.CntDocVisualizar; } }


        public Gestion() 
        {
            _opcVisDoc = new Filtros.Opcion.Gestion();
            _opcCalculoDifTasa = new Filtros.Opcion.Gestion();
            _opcCalculoPrecioPrdNac = new Filtros.Opcion.Gestion();
            _data = new data();
            limpiar();
        }


        public void Inicializa()
        {
            limpiar();
        }

        CnfModuloFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new CnfModuloFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Configuracion_Modulo_Capturar();
                var r02 = Sistema.MyData.Configuracion_ModoCalculoPrecioProductosNacionales();

                var lst = new List<Filtros.ficha>();
                lst.Add(new Filtros.ficha("1", "", "SI"));
                lst.Add(new Filtros.ficha("2", "", "NO"));
                _opcVisDoc.setData(lst);

                setClaveMaxima(r01.Entidad.claveNivMaximo);
                setClaveMedia(r01.Entidad.claveNivMedio);
                setClaveMinima(r01.Entidad.claveNivMinimo);
                setCntDocVisualizar(r01.Entidad.cantDocVisualizar);
                if (r01.Entidad.visualizarPrdInactivos)
                    setPrdInactivo("1");
                else
                    setPrdInactivo("2");

                var lst_2 = new List<Filtros.ficha>();
                lst_2.Add(new Filtros.ficha("1", "", "EN BASE A BCV"));
                lst_2.Add(new Filtros.ficha("2", "", "EN BASE A PARALELO"));
                _opcCalculoDifTasa.setData(lst_2);
                if (r01.Entidad.modoCalculoDifEntreTasa == OOB.LibSistema.Configuracion.Modulo.Capturar.Ficha.enumModoCalculoDifEntreTasa.BCV)
                    _opcCalculoDifTasa.setFicha("1");
                else
                    _opcCalculoDifTasa.setFicha("2");

                var lst_3 = new List<Filtros.ficha>();
                lst_3.Add(new Filtros.ficha("1", "", "EN BASE A PRECIO DIVISA SIN BONO"));
                lst_3.Add(new Filtros.ficha("2", "", "EN BASE A PRECIO DIVISA CON BONO"));
                lst_3.Add(new Filtros.ficha("3", "", "NINGUNA OPCION"));
                _opcCalculoPrecioPrdNac.setData(lst_3);
                if (r02.Entidad == DataProvSistema.Infra.MisEnumerados.ModoCalculoPrecioProductosNacionales.EnBasePrecioDivisaSinBono)
                    _opcCalculoPrecioPrdNac.setFicha("1");
                else if (r02.Entidad == DataProvSistema.Infra.MisEnumerados.ModoCalculoPrecioProductosNacionales.EnBasePrecioDivisaConBono)
                    _opcCalculoPrecioPrdNac.setFicha("2");
                else 
                    _opcCalculoPrecioPrdNac.setFicha("3");

                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        public void AbandonarFicha()
        {
            _abandonarFichaIsOk = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarFichaIsOk = true;
            }
        }

        public void ProcesarFicha()
        {
            var _calculoPrecioPrdNac = "";
            if (_opcCalculoPrecioPrdNac.GetId == "1")
                _calculoPrecioPrdNac = "EN BASE AL PRECIO EN DIVISA SIN BONO";
            else if (_opcCalculoPrecioPrdNac.GetId == "2")
                _calculoPrecioPrdNac = "EN BASE AL PRECIO EN DIVISA CON BONO";
            else
                _calculoPrecioPrdNac = "NINGUNA";

            _procesarFichaIsOk = false;
            var xmsg = "Procesar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var fichaOOB = new OOB.LibSistema.Configuracion.Modulo.Actualizar.Ficha()
                {
                    claveNivMaximo = _data.ClaveMaxima,
                    claveNivMedio = _data.ClaveMedia,
                    claveNivMinimo = _data.ClaveMinima,
                    cantDocVisualizar = (int)_data.CntDocVisualizar,
                    visualizarPrdInactivos = _opcVisDoc.GetId == "1" ? "Si" : "No",
                    modoCalculoDifTasa = _opcCalculoDifTasa.GetId =="1" ?"BCV" : "PARALELO",
                    modoCalculoPrecioPrdNac= _calculoPrecioPrdNac,
                };
                var rt1 = Sistema.MyData.Configuracion_Modulo_Actualizar(fichaOOB);
                if (rt1.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(rt1.Mensaje);
                    return;
                }
                Helpers.Msg.EditarOk();
                _procesarFichaIsOk = true;
            }
        }


        private void limpiar()
        {
            _abandonarFichaIsOk = false;
            _procesarFichaIsOk = false;
            _data.Limpiar();
        }


        public void setClaveMaxima(string p)
        {
            _data.setClaveMaxima(p);
        }
        public void setClaveMedia(string p)
        {
            _data.setClaveMedia(p);
        }
        public void setClaveMinima(string p)
        {
            _data.setClaveMinima(p);
        }
        public void setCntDocVisualizar(decimal p)
        {
            _data.setCntDocVisualizar(p);
        }
        public void setPrdInactivo(string id)
        {
            _opcVisDoc.setFicha(id);
        }


        public BindingSource GetCalculoDifTasa_Source { get { return _opcCalculoDifTasa.Source; } }
        public string GetCalculoDifTasa_Id { get { return _opcCalculoDifTasa.GetId; } }
        public void setCalculoDifTasa(string id)
        {
            _opcCalculoDifTasa.setFicha(id);
        }


        public object SourceCalculoPrecioPrdNac { get { return _opcCalculoPrecioPrdNac.Source; } }
        public object GetId_CalculoPrecioPrdNac { get {return _opcCalculoPrecioPrdNac.GetId ;} }
        public void setCalculoPrecioPrdNac(string id)
        {
            _opcCalculoPrecioPrdNac.setFicha(id);
        }
    }
}