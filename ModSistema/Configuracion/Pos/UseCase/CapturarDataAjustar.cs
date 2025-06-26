using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Configuracion.Pos.UseCase
{
    public class CapturarDataAjustar
    {
        public void Execute(Models.ActualizarTasaPos modelo)
        {
            var r0 = Sistema.MyData.AjustarTasaPos_CapturarData();
            modelo.LimpiarItems();
            foreach (var it in r0.Entidad.items)
            {
                var item = new Models.Item()
                {
                    idPrd = it.idPrd,
                    codigoPrd = it.codigoPrd,
                    nombrePrd = it.nombrePrd,
                    contEmp1 = it.contEmp1,
                    contEmp2 = it.contEmp2,
                    contEmp3 = it.contEmp3,
                    descEmp1 = it.descEmp1,
                    descEmp2 = it.descEmp2,
                    descEmp3 = it.descEmp3,
                    p1 = it.p1,
                    p2 = it.p2,
                    p3 = it.p3,
                    p4 = it.p4,
                    may1 = it.may1,
                    may2 = it.may2,
                    may3 = it.may3,
                    may4 = it.may4,
                    dsp1 = it.dsp1,
                    dsp2 = it.dsp2,
                    dsp3 = it.dsp3,
                    dsp4 = it.dsp4,
                };
                modelo.AgregarItemParaActualizar(item);
            }
        }
    }
}