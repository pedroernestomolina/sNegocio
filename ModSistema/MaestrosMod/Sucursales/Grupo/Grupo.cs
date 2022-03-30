using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.Grupo
{
    
    public class Grupo: ITipoMaestro
    {

        private List<data> _lst;
        private IAgregarEditar _gAgregar;
        private IAgregarEditar _gEditar;


        public string GetTitulo { get { return "Maestro: SUCURUSAL - GRUPOS"; } }
        public IEnumerable<data> Lista { get { return _lst; } }


        public Grupo(IAgregarEditar agregar, IAgregarEditar editar) 
        {
            _gAgregar = agregar;
            _gEditar = editar;
            _lst = new List<data>();
        }


        public bool CargarData()
        {
            _lst.Clear();
            var r01 = Sistema.MyData.SucursalGrupo_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            foreach (var rg in r01.Lista) 
            {
                var nr = new data()
                {
                    auto = rg.auto,
                    codigo = "",
                    descripcion = rg.nombre,
                    esActivo = true,
                    precioManeja = rg.precioDescripcion,
                };
                _lst.Add(nr);
            }

            return true;
        }

        MaestroFrm frm;
        public void Inicia(IMaestro ctr)
        {
            if (frm == null) 
            {
                frm = new MaestroFrm();
                frm.setControlador(ctr);
            }
            frm.ShowDialog();
        }


        public data ItemAgregarEditar { get { return null; } }
        public bool AgregarIsOk { get { return _gAgregar.IsOk; } }
        public void AgregarItem()
        {
            _gAgregar.Inicializa();
            _gAgregar.Inicia();
        }

        public void Inicializa()
        {
        }


        public bool EditarIsOk
        {
            get { throw new NotImplementedException(); }
        }

        public void EditarItem(data ItemActual)
        {
        }
        
    }

}