using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Deposito.AgregarEditar
{
    
    public class Agregar: IAgregar
    {


        private string _nombre;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private string _idItemRegistrado;
        private Helpers.Opcion.IOpcion _gSucursal;


        public string Titulo { get { return "Agregar: DEPOSITO"; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public BindingSource SucursalSource { get { return _gSucursal.Source; } }
        public string GetSucursalId { get { return _gSucursal.GetId; } }
        public string GetNombre { get { return _nombre; } }
        string IAgregar.IdItemRegistrado{ get { return _idItemRegistrado;} }


        public Agregar() 
        {
            _gSucursal= new Helpers.Opcion.Gestion();
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemRegistrado = "";
        }


        public void Inicializa()
        {
            _gSucursal.Inicializa();
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemRegistrado = "";
        }

        AgregarEditarFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var filtroOOB = new OOB.LibSistema.Sucursal.Lista.Filtro();
            var r01 = Sistema.MyData.Sucursal_GetLista(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var lst = new List<Helpers.ficha>();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                lst.Add(new Helpers.ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gSucursal.setData(lst);

            return true;
        }


        public void setNombre(string p)
        {
            _nombre = p;
        }
        public void setSucursal(string id)
        {
            _gSucursal.setFicha(id);
        }

        
        public void Procesar()
        {
            _procesarIsOk = false;
            _idItemRegistrado = "";
            if (_nombre.Trim() == "") 
            {
                Helpers.Msg.Error("Campo [ NOMBRE ] No Puede Estar Vacio");
                return;
            }
            if (_gSucursal.Item ==null)
            {
                Helpers.Msg.Error("Campo [ SUCURSAL ] No Puede Estar Vacio");
                return;
            }
            var xmsg = "Guardar Ficha ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var fichaOOB = new OOB.LibSistema.Deposito.Agregar.Ficha()
                {
                    autoSucurusal = _gSucursal.Item.id,
                    codigoSucursal = _gSucursal.Item.codigo,
                    nombre = _nombre,
                };
                var r01 = Sistema.MyData.Deposito_Agregar(fichaOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _procesarIsOk = true;
                _idItemRegistrado = r01.Auto;
                Helpers.Msg.AgregarOk();
            }
        }
        
        public void Abandonar()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true; 
            }
        }

    }

}