using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.Sucursales.AsignarDeposito.AgregarEditar
{
    
    public class Editar: IEditar
    {


        private string _sucursal;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private string _idItemEditar;
        private Helpers.Opcion.IOpcion _gDeposito;


        public string Titulo { get { return "ASIGNAR DEPOSITO"; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public BindingSource DepositoSource { get { return _gDeposito.Source; } }
        public string GetDepositoId { get { return _gDeposito.GetId; } }
        public string GetSucursal { get { return _sucursal; } }
        public object IdItemRegistrado { get { return null; } }


        public Editar() 
        {
            _gDeposito= new Helpers.Opcion.Gestion();
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemEditar = "";
            _sucursal = "";
        }


        public void Inicializa()
        {
            _gDeposito.Inicializa();
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemEditar = "";
            _sucursal = "";
        }

        AsignarFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new AsignarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }

        }

        private bool CargarData()
        {
            var filtroOOB = new OOB.LibSistema.Deposito.Lista.Filtro();
            var r01 = Sistema.MyData.Deposito_GetLista(filtroOOB);
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
            _gDeposito.setData(lst);

            var r02 = Sistema.MyData.Sucursal_GetFicha(_idItemEditar);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _gDeposito.setFicha(r02.Entidad.autoDepositoPrincipal);
            _sucursal = r02.Entidad.nombre;

            return true;
        }

        public void SetDeposito(string id)
        {
            _gDeposito.setFicha(id);
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            if (_gDeposito.Item ==null)
            {
                Helpers.Msg.Error("Campo [ DEPOSITO ] No Puede Estar Vacio");
                return;
            }
            var xmsg = "Guardar Ficha ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var fichaOOB = new OOB.LibSistema.Sucursal.AsignarDepositoPrincipal.Ficha()
                {
                    auto = _idItemEditar,
                    autoDepositoPrincipal = _gDeposito.Item.id,
                };
                var r01 = Sistema.MyData.Sucursal_AsignarDepositoPrincipal(fichaOOB);
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

        public void setIdItemEditar(string p)
        {
            _idItemEditar = p;
        }

    }

}