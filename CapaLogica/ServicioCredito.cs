using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
namespace CapaLogica
{
    public class ServicioCredito
    {
        RepositorioCredito repositorioCredito = new RepositorioCredito();

        public string Guardar(Credito credito)
        {
            try
            {
                RespuestaBusqueda respuestaBusqueda = Buscar(credito.Identificacion);
                string respuesta = IntentarGuardar(respuestaBusqueda, credito);
                return respuesta;
            }
            catch (Exception e)
            {
                return $"Error al guardar los datos:  { e.Message }";
            }
        }
        public string IntentarGuardar(RespuestaBusqueda respuesta, Credito credito)
        {
            if (respuesta.Credito == null)
            {
                repositorioCredito.Guardar(credito);
                return $"Datos del credito Guardados con exito";
            }
            return " error la identificaion del credito ya se encuentra registrado";
        }

        public RespuestaConsulta Consultar()
        {
            RespuestaConsulta respuestaConsulta = new RespuestaConsulta();
            respuestaConsulta.Error = false;
            try
            {
                respuestaConsulta = ObtenerRespuestaConsulta(respuestaConsulta);
                return respuestaConsulta;
            }
            catch (Exception e)
            {
                respuestaConsulta = ObtenerRespuestaConsulta(respuestaConsulta, e);
                return respuestaConsulta;
            }
        }
        public RespuestaConsulta ObtenerRespuestaConsulta(RespuestaConsulta respuestaConsulta)
        {
            respuestaConsulta.Creditos = repositorioCredito.Consultar();
            if (respuestaConsulta.Creditos.Count > 0)
            {
                respuestaConsulta.Mensaje = "registro encontrado con exito";
            }
            else
            {
                respuestaConsulta.Mensaje = "no hay creditos registradas";
            }
            return respuestaConsulta;
        }
        public RespuestaConsulta ObtenerRespuestaConsulta(RespuestaConsulta respuestaConsulta, Exception e)
        {

            respuestaConsulta.Error = true;
            respuestaConsulta.Mensaje = $"error al consultar la lista de Liquidaciones {e.Message} ";
            respuestaConsulta.Creditos = null;
            return respuestaConsulta;
        }
        public string Eliminar(string numeroDeLiquidacion)
        {
            try
            {
                RespuestaBusqueda respuestaBusqueda = Buscar(numeroDeLiquidacion);
                string respuesta = IntentarEliminar(respuestaBusqueda, numeroDeLiquidacion);
                return respuesta;
            }
            catch (Exception e)
            {
                return $"error  {e.Message}";
            }
        }
        public string IntentarEliminar(RespuestaBusqueda respuestaBusqueda, string numeroDeLiquidacion)
        {
            if (respuestaBusqueda.Credito != null)
            {
                repositorioCredito.Eliminar(numeroDeLiquidacion);
                return $"credito eliminado con exito";
            }
            return respuestaBusqueda.Mensaje;
        }
        public string Modificar(Credito credito)
        {
            try
            {
                RespuestaBusqueda respuestaBusqueda = Buscar(credito.Identificacion);
                string respuesta = IntentarModificar(respuestaBusqueda, respuestaBusqueda);
                return respuesta;
            }
            catch (Exception e)
            {
                return $"error {e.Message}";
            }
        }
        public string IntentarModificar(RespuestaBusqueda respuestaBusqueda, RespuestaBusqueda liquidacionCuotaModeradora)
        {
            if (respuestaBusqueda.Credito != null)
            {
                repositorioCredito.Modificar(respuestaBusqueda.Credito);
                return $"credito Modificado con exito";
            }
            return respuestaBusqueda.Mensaje;
        }

        public RespuestaBusqueda Buscar(string numeroDeLiquidacion)
        {
            RespuestaBusqueda respuestaBusqueda = new RespuestaBusqueda();
            respuestaBusqueda.Error = false;
            try
            {
                respuestaBusqueda = ObtenerRespuestaBusqueda(respuestaBusqueda, numeroDeLiquidacion);
                return respuestaBusqueda;
            }
            catch (Exception e)
            {
                respuestaBusqueda = ObtenerRespuestaBusqueda(respuestaBusqueda, e);
                return respuestaBusqueda;
            }
        }
        public RespuestaBusqueda ObtenerRespuestaBusqueda(RespuestaBusqueda respuestaBusqueda, string numeroDeLiquidacion)
        {
            respuestaBusqueda.Credito = repositorioCredito.Buscar(numeroDeLiquidacion);
            if (respuestaBusqueda.Credito != null)
            {
                respuestaBusqueda.Mensaje = "Datos del credito encontrados con exito";
            }
            else
            {
                respuestaBusqueda.Mensaje = "Los datos del numero de credito no se encuentra registrado";
            }
            return respuestaBusqueda;
        }
        public RespuestaBusqueda ObtenerRespuestaBusqueda(RespuestaBusqueda respuestaBusqueda, Exception e)
        {
            respuestaBusqueda.Error = true;
            respuestaBusqueda.Mensaje = $"error : {e.Message}";
            respuestaBusqueda.Credito = null;
            return respuestaBusqueda;
        }
    }
}
