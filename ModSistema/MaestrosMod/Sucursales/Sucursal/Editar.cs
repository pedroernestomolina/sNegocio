using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Sucursal
{
    
    public class Editar: ISucursalAgregarEditar
    {


        private string _nombre;
        private bool _factMayor;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private string _idItemEditar;
        private Helpers.Opcion.IOpcion _gGrupo;


        public string Titulo { get { return "Editar: SUCURSAL"; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public BindingSource GrupoSource { get { return _gGrupo.Source; } }
        public string GetGrupoId { get { return _gGrupo.GetId; } }
        public string GetNombre { get { return _nombre; } }
        public bool GetFactMayor { get { return _factMayor; } }
        public object IdItemRegistrado { get { return null; } }


        public Editar() 
        {
            _gGrupo = new Helpers.Opcion.Gestion();
            _nombre = "";
            _factMayor = false;
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemEditar = "";
        }


        public void Inicializa()
        {
            _gGrupo.Inicializa();
            _nombre = "";
            _factMayor = false;
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
            var r01 = Sistema.MyData.SucursalGrupo_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var lst = new List<Helpers.ficha>();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                lst.Add(new Helpers.ficha(rg.auto, "", rg.nombre));
            }
            _gGrupo.setData(lst);

            var r02 = Sistema.MyData.Sucursal_GetFicha(_idItemEditar);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _nombre = r02.Entidad.nombre;
            _gGrupo.setFicha(r02.Entidad.autoGrupo);
            _factMayor = r02.Entidad.activarFactMayor;

            return true;
        }


        public void setNombre(string p)
        {
            _nombre = p;
        }
        public void SetGrupo(string id)
        {
            _gGrupo.setFicha(id);
        }
        public void setFactMayor(bool p)
        {
            _factMayor = p;
        }


        public void Procesar()
        {
            _procesarIsOk = false;
            if (_nombre.Trim() == "") 
            {
                Helpers.Msg.Error("Campo [ NOMBRE ] No Puede Estar Vacio");
                return;
            }
            if (_gGrupo.Item ==null)
            {
                Helpers.Msg.Error("Campo [ GRUPO ] No Puede Estar Vacio");
                return;
            }
            var xmsg = "Guardar Ficha ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var fichaOOB = new OOB.LibSistema.Sucursal.Editar.Ficha()
                {
                    auto = _idItemEditar,
                    autoGrupo = _gGrupo.Item.id,
                    nombre = _nombre,
                    estatusFactMayor = _factMayor ? "1" : "0",
                };
                var r01 = Sistema.MyData.Sucursal_Editar(fichaOOB);
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
            {
                _abandonarIsOk = true; ;
            }
        }

        public void setIdItemEditar(object p)
        {
            _idItemEditar = (string)p;
        }

    }

}