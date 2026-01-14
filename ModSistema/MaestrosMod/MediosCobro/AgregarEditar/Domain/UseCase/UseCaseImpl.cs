using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.MaestrosMod.MediosCobro.AgregarEditar.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public OOB.LibSistema.MediosCobroPago.Entidad.Ficha
            AgregarMedioPago(OOB.LibSistema.MediosCobroPago.Agregar.Ficha ficha)
        {
            try
            {
                var rst1 = Sistema.MyData.MediosCobroPago_AgregarFicha(ficha);
                if (rst1.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst1.Mensaje);
                }
                var rst2 = Sistema.MyData.MediosCobroPago_GetFicha_ById(rst1.Auto);
                if (rst2.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst2.Mensaje);
                }
                return rst2.Entidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public OOB.LibSistema.MediosCobroPago.Entidad.Ficha
            CargarMedioPago(string id)
        {
            try
            {
                var rst = Sistema.MyData.MediosCobroPago_GetFicha_ById(id);
                if (rst.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                return rst.Entidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public OOB.LibSistema.MediosCobroPago.Entidad.Ficha
            EditarMedioPago(OOB.LibSistema.MediosCobroPago.Editar.Ficha ficha)
        {
            try
            {
                var rst1 = Sistema.MyData.MediosCobroPago_EditarFicha(ficha); 
                if (rst1.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst1.Mensaje);
                }
                var rst2 = Sistema.MyData.MediosCobroPago_GetFicha_ById(ficha.auto);
                if (rst2.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst2.Mensaje);
                }
                return rst2.Entidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public  List<OOB.LibSistema.Moneda.Entidad.Ficha>
            CargarMonedas()
        {
            try
            {
                var filtroOOB = new OOB.LibSistema.Moneda.Filtro();
                var rst = Sistema.MyData.Moneda_GetLista(filtroOOB);
                if (rst.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rst.Mensaje);
                }
                return rst.Lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}