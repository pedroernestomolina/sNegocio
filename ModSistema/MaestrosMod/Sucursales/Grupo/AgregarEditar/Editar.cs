using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Grupo.AgregarEditar
{
    
    public class Editar: IEditar
    {


        private string _nombre;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private string _idItemEditar;
        private Helpers.Opcion.IOpcion _gPrecio;


        public string Titulo { get { return "Editar: GRUPO"; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public BindingSource PrecioSource { get { return _gPrecio.Source; } }
        public string GetPrecioId { get { return _gPrecio.GetId; } }
        public string GetNombre { get { return _nombre; } }
        public object IdItemRegistrado { get { return null; } }


        public Editar() 
        {
            _gPrecio = new Helpers.Opcion.Gestion();
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemEditar = "";
        }


        public void Inicializa()
        {
            _gPrecio.Inicializa();
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemEditar = "";
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
            var r01 = Sistema.MyData.TablaPrecio_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var lst = new List<Helpers.ficha>();
            foreach (var rg in r01.Lista.OrderBy(o => o.descripcion).ToList())
            {
                lst.Add(new Helpers.ficha(rg.id.ToString(), rg.codigo, rg.descripcion));
            }
            _gPrecio.setData(lst);

            var r02 = Sistema.MyData.SucursalGrupo_GetFicha(_idItemEditar);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _nombre = r02.Entidad.nombre;
            _gPrecio.setFicha(r02.Entidad.idPrecio.ToString());

            return true;
        }


        public void setNombre(string p)
        {
            _nombre = p;
        }
        public void SetPrecio(string id)
        {
            _gPrecio.setFicha(id);
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            if (_nombre.Trim() == "") 
            {
                Helpers.Msg.Error("Campo [ NOMBRE ] No Puede Estar Vacio");
                return;
            }
            if (_gPrecio.Item ==null)
            {
                Helpers.Msg.Error("Campo [ PRECIO ] No Puede Estar Vacio");
                return;
            }
            var xmsg = "Guardar Ficha ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var fichaOOB = new OOB.LibSistema.SucursalGrupo.Editar.Ficha()
                {
                    auto = _idItemEditar,
                    idPrecio = int.Parse(_gPrecio.Item.id),
                    nombre = _nombre,
                };
                var r01 = Sistema.MyData.SucursalGrupo_Editar(fichaOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _procesarIsOk = true;
                Helpers.Msg.EditarOk();
            }
        }
        
        public void Abandonar()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
                _abandonarIsOk = true; ;
        }

        public void setIdItemEditar(string _idEditar)
        {
            _idItemEditar = _idEditar;
        }

    }

}