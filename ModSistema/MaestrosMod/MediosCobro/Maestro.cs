using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.MaestrosMod.MediosCobro
{
    public class Maestro : IMedioCobro
    {
        private MediosCobro.AgregarEditar.vm.IAgregar _gAgregar;
        private MediosCobro.AgregarEditar.vm.IEditar _gEditar;
        private IMedioCobroLista _gLista;
        //
        public string Titulo { get { return "Maestro: MEDIOS DE COBRO"; } }
        public BindingSource Source { get { return _gLista.Source; } }
        public int CntItems { get { return _gLista.CntItems; } }
        //
        public Maestro(IMedioCobroLista lista,  
            MediosCobro.AgregarEditar.vm.IAgregarEditar agregar, 
            MediosCobro.AgregarEditar.vm.IAgregarEditar editar)
        {
            _gLista = lista;
            //_gAgregar = agregar;
            //_gEditar = editar;
            _gAgregar = new AgregarEditar.vm.AgregarNew();
            _gEditar = new  AgregarEditar.vm.EditarNew();
        }


        public void Inicializa()
        {
            _gLista.Inicializa();
            _gAgregar.Inicializa();
            _gEditar.Inicializa();
        }
        MaestroFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new MaestroFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public bool CargarData()
        {
            var filtroOOB = new OOB.LibSistema.MediosCobroPago.Lista.Filtro();
            var r01 = Sistema.MyData.MediosCobroPago_GetLista(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var _lst = new List<data>();
            foreach (var rg in r01.Lista.OrderBy(o=>o.descripcion).ToList())
            {
                var nr = new data()
                {
                    auto = rg.auto.ToString(),
                    codigo = rg.codigo,
                    descripcion = rg.descripcion,
                    isParaCobro = rg.estatusCobro,
                    isParaPago= rg.estatusPago,
                };
                _lst.Add(nr);
            }
            _gLista.setLista(_lst);

            return true;
        }


        public bool AgregarIsOk { get { return _gAgregar.IsOk; } }
        public void AgregarItem()
        {
            _gAgregar.Inicializa();

            var r00 = Sistema.MyData.Permiso_MedioPagoCobro_Agregar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gAgregar.Inicia();
                if (_gAgregar.IsOk)
                {
                    var rg = _gAgregar.GetItemRegistrado;
                    _gLista.Agregar(new data()
                    {
                        auto = rg.auto.ToString(),
                        codigo = rg.codigo,
                        descripcion = rg.descripcion,
                        isParaCobro = rg.estatusCobro,
                        isParaPago = rg.estatusPago,
                    });
                }
            }
        }

        public bool EditarIsOk { get { return _gEditar.IsOk; } }
        public void EditarItem()
        {
            if (_gLista.ItemActual != null) 
            {
                EditarItem(_gLista.ItemActual);
            }
        }
        public void EditarItem(data item)
        {
            _gEditar.Inicializa();

            var r00 = Sistema.MyData.Permiso_MedioPagoCobro_Editar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var _idEditar = item.auto;
                _gEditar.setIdItemEditar(_idEditar);
                _gEditar.Inicia();
                if (_gEditar.IsOk)
                {
                     var rg= _gEditar.GetItemRegistrado;
                     _gLista.Actualizar(new data()
                     {
                         auto = rg.auto.ToString(),
                         codigo = rg.codigo,
                         descripcion = rg.descripcion,
                         isParaCobro = rg.estatusCobro,
                         isParaPago = rg.estatusPago,
                     });
                }
            }
        }
    }
}