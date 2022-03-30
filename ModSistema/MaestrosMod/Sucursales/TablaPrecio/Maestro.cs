using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.Sucursales.TablaPrecio
{
    
    public class Maestro: ITipoMaestro
    {

        private List<data> _lst;
        private IAgregarEditar _gAgregar;
        private IAgregarEditar _gEditar;


        public string GetTitulo { get { return "Maestro: TABLA PRECIOS"; } }
        public IEnumerable<data> Lista { get { return _lst; } }


        public Maestro(IAgregarEditar agregar, IAgregarEditar editar)
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


        public bool AgregarIsOk { get { return _gAgregar.IsOk; } }
        public data ItemAgregar { get { return _gAgregar.DataAgregar; } }
        public void AgregarItem()
        {
            _gAgregar.Inicializa();
            _gAgregar.Inicia();
        }

    }

}