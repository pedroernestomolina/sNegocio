using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.Sucursal.AgregarEditar
{
    
    public class Editar: IEditar
    {

        private string _nombre;
        private bool _factMayor;
        private bool _ventaCredito;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private string _idItemEditar;
        private Helpers.Opcion.IOpcion _gGrupo;
        private bool _posVentaSurtido;
        private bool _posVueltoDivisa;


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
            _ventaCredito = false;
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemEditar = "";
            _posVentaSurtido = false;
            _posVueltoDivisa = false;
        }


        public void Inicializa()
        {
            _gGrupo.Inicializa();
            _nombre = "";
            _factMayor = false;
            _ventaCredito = false;
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemEditar = "";
            _posVentaSurtido = false;
            _posVueltoDivisa = false;
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
            _ventaCredito = r02.Entidad.activarVentaCredito;
            _posVentaSurtido = r02.Entidad.habilitarPosVentaSurtido;
            _posVueltoDivisa = r02.Entidad.habilitarPosVueltoDivisa;

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
                    estatusVentaCredito = _ventaCredito ? "1" : "0",
                    estatusPosVentaSurtido = _posVentaSurtido ? "1" : "0",
                    estatusPosVueltoDivisa = _posVueltoDivisa ? "1" : "0",
                };
                try
                {
                    var r01 = Sistema.MyData.Sucursal_Editar(fichaOOB);
                    _procesarIsOk = true;
                    Helpers.Msg.EditarOk();
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
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

        public void setIdItemEditar(string _idEditar)
        {
            _idItemEditar = _idEditar;
        }


        public bool GetFactCredito { get { return _ventaCredito; } }
        public bool GetPosVentaSurtido { get { return _posVentaSurtido; } }
        public bool GetPosVueltoDivisa { get { return _posVueltoDivisa; } }
        public void setVentaCredito(bool p)
        {
            _ventaCredito = p;
        }
        public void setPosVueltoDivisa(bool p)
        {
            _posVueltoDivisa = p;
        }
        public void setPosVentaSurtido(bool p)
        {
            _posVentaSurtido = p;
        }

    }

}