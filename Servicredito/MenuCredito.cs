using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using CapaEntidad;
namespace Servicredito
{
    public class MenuCredito
    {
        ServicioCredito servicioCredito = new ServicioCredito();
        Lectura lectura = new Lectura();
        public MenuCredito()
        {
            EjecutarMenuCredito();
        }
        public int PedirOpcion()
        {
            lectura.CrearTitulo("Menu Gestion credito");
            int opcion;
            Console.WriteLine("1- Para guardar  Credito");
            Console.WriteLine("2- Para Consultar Registros De credito");
            Console.WriteLine("3- Para Eliminar Un Credito");
            Console.WriteLine("4- Para Modificar Un Credito");
            Console.WriteLine("0- Para Salir");
            Console.WriteLine("");
            opcion = int.Parse(lectura.LeerNumerico("Digite La Opcion Deseada :"));
            return opcion;
        }

        public void EjecutarMenuCredito()
        {
            int opcion;
            do
            {
                opcion = PedirOpcion();
                switch (opcion)
                {
                    case 1: RegistrarCredito(); break;
                    case 2:MostrarRegistroSDeCreditos(); break;
                    case 3:Eliminar(); break;
                    case 4:ModificarCredito(); break;
                }
            } while (opcion != 0);
        }
        public void RegistrarCredito()
        {
            string opcion = "s";
            while (opcion.Equals("s"))
            {
                Credito credito = CrearCredito();
                Console.WriteLine(servicioCredito.Guardar(credito));
                Console.WriteLine("Valor a pagar del credito" + credito.ValorTotal);
                opcion = lectura.ValidarRespuesta("Desea seguir guardando ?  digite s/n");
            }
        }

        public Credito CrearCredito()
        {
            lectura.CrearTitulo("Formulario - Registrar Credito");
            string identificacion = lectura.LeerNumerico("Digite la identificacion del credito : ");
            Cliente cliente = CrearCliente();
            Interes interes = CrearInteres();
            Credito credito = new Credito(identificacion, cliente, interes);
            credito.ValorTotal = interes.ValorInteres;
            return credito;
        }
        public Cliente CrearCliente()
        {
            Console.WriteLine("Digite los datos del cliente  :");
            string nombre = lectura.LeerCadena("nombre : ");
            string cedula = lectura.LeerNumerico("Cedula : ");
            Cliente cliente = new Cliente(nombre, cedula);
            return cliente;
        }
        public Interes CrearInteres()
        {
            string tipo = ObtenerTipoDeInteres("digite tipo de interes -> s para simple y -> c para compuesto : ");
            double valorPrestado = Convert.ToDouble(lectura.LeerNumerico("Valor Prestado : "));
            int tiempo = Convert.ToInt32(lectura.LeerNumerico("digite el tiempo de pago (Años): "));
            double tasa = Convert.ToDouble(lectura.Leer("digite la tasa de interes en porcentaje (%) solo valores enteros  :"));
            InteresFactoria interesFactoria = new InteresFactoria();
            Interes interes = interesFactoria.CrearInteres(tipo, valorPrestado, tiempo, tasa);
            interes.CalcularValorTotal();
            return interes;
        }
        public string ObtenerTipoDeInteres(string texto)
        {
            string opcion = lectura.LeerCadena(texto).ToLower();
            while ((opcion != "s") && (opcion != "c"))
            {
                opcion = lectura.LeerCadena("Error solo puede Digitar -> (c) o Digite ->  (s)");
            }
            return opcion;
        }

        public void MostrarRegistroSDeCreditos ()
        {
            lectura.CrearTitulo("Formulario- Consulta Registro de credito");
            RespuestaConsulta respuestaConsulta = servicioCredito.Consultar();
            Console.WriteLine(respuestaConsulta.Mensaje);
            if (respuestaConsulta.Creditos != null)
            {
                foreach (Credito item in respuestaConsulta.Creditos)
                {
                    MostrarDatos(item);
                }
            }
            lectura.CrearPausa();
        }
        public void MostrarDatos(Credito credito)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Imformacion Del  Cliente");
            MostrarImformacionCliente(credito.Cliente);
            Console.WriteLine("");
            Console.WriteLine("Imformacion De La Liquidacion");
            Console.WriteLine("");
            Console.WriteLine("Identificacion de Credito : " + credito.Identificacion + "      Tipo de interes del credito: " +credito.Interes.Tipo + "     tasa de interes: " + credito.Interes.Tasa);
            Console.WriteLine("");
            Console.WriteLine("valor total a pagar : " +  credito.ValorTotal + "      periodo de tiempo (años): " +credito.Interes.Tiempo );
        }
        public void MostrarImformacionCliente(Cliente cliente)
        {
            Console.WriteLine("Datos del cliente :");
            Console.WriteLine("Nombre:"+cliente.nombre);
            Console.WriteLine("Cedula :"+cliente.cedula);
        }
        public void Eliminar()
        {
            string opcion = "s";
            while (opcion.Equals("s"))
            {
                lectura.CrearTitulo("Formulario - Eliminar Credito");
                RealizarEliminacion();
                opcion = lectura.ValidarRespuesta("Desea seguir eliminado ?  digite s/n");
            }
        }
        public void RealizarEliminacion()
        {
            string identificacion = lectura.LeerNumerico("Digite la identificacion de credito a eliminar");
            RespuestaBusqueda respuestaBusqueda = servicioCredito.Buscar(identificacion);
            MostrarDatos(respuestaBusqueda.Credito);
            Console.WriteLine(servicioCredito.Eliminar(identificacion));
        }
        public void RealizarModificacionCredito()
        {
            string opcion = "s";
            while (opcion.Equals("s"))
            {
                lectura.CrearTitulo("Formulario - Modificar Credito");
                ModificarCredito();
                opcion = lectura.ValidarRespuesta("Desea seguir modificando ?  digite s/n");
            }
        }
        public void ModificarCredito()
        {
            string identificacion = lectura.LeerNumerico("Digite el numero de Liquidacion a buscar");
            RespuestaBusqueda respuestaBusqueda = servicioCredito.Buscar(identificacion);
            if (respuestaBusqueda.Credito != null)
            {
                MostrarDatos(respuestaBusqueda.Credito);
                Credito credito = ObtenerCreditoModificado(respuestaBusqueda.Credito);
                Console.WriteLine(servicioCredito.Modificar(credito));
                lectura.CrearPausa();
            }

        }
        public Credito ObtenerCreditoModificado(Credito credito)
        {
            double valorPrestado = float.Parse(lectura.LeerNumerico("Digite El Nuevo Valor valor del credito a prestar : "));
            int tiempo = Convert.ToInt32(lectura.LeerNumerico("digite el nuevo tiempo de pago (Años): "));
            double tasa = Convert.ToDouble(lectura.Leer("digite la nueva tasa de interes en porcentaje (%) solo valores enteros  :"));
            string tipo = credito.Interes.Tipo;
            InteresFactoria interesFactoria = new InteresFactoria();
            Interes interes = interesFactoria.CrearInteres(tipo, valorPrestado, tiempo, tasa);
            interes.CalcularValorTotal();
            string identificaion = credito.Identificacion;
            Credito creditoAuxiliar = new Credito(identificaion, credito.Cliente, interes);
            credito.ValorTotal = interes.ValorInteres;
            return creditoAuxiliar;


        }
    }
}
