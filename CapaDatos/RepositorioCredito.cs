using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CapaEntidad;
namespace CapaDatos
{
    public class RepositorioCredito
    {
        private List<Credito> creditos = new List<Credito>();
        private string ruta = @"Creditos.txt";
        private FileStream flujoDelFichero;
        public void Guardar(Credito credito)
        {
            flujoDelFichero = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(flujoDelFichero);
            escritor.WriteLine(credito.ToString());
            escritor.Close();
            flujoDelFichero.Close();
        }
        public List<Credito> Consultar()
        {
            creditos.Clear();
            flujoDelFichero = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(flujoDelFichero);
            string linea = string.Empty;
            while ((linea = lector.ReadLine()) != null)
            {
                Credito credito = MapearCredito(linea);
                creditos.Add(credito);
            }
            lector.Close();
            flujoDelFichero.Close();
            return creditos;
        }
        public Credito MapearCredito(string linea)
        {
            Credito credito;
            string[] datos = linea.Split(';');
            string identificacion = datos[0];
            double valorTotal = Convert.ToDouble(datos[1]);
            Cliente cliente = MapearCliente(linea);
            Interes interes = MapearInteres(linea);
            credito = new Credito(identificacion,cliente,interes);
            credito.ValorTotal = valorTotal;
            return credito;
        }
        public Cliente MapearCliente(string linea)
        {
            string[] datos = linea.Split(';');
            string nombre = datos[2];
            string cedula = datos[3];
            Cliente cliente = new Cliente(nombre,cedula);
            return cliente;
        }
        public Interes MapearInteres(string linea)
        {
            Interes interes;
            string[] datos = linea.Split(';');
            string tipo = datos[4];
            int tiempo = Convert.ToInt32(datos[5]);
            double tasa= Convert.ToDouble(datos[6])*100;
            double valorPrestado= Convert.ToDouble(datos[7]);
            if (EsCompuesto(datos[4]))
            {
                 interes = new Compuesto(valorPrestado,tiempo, tasa);
            }
            else
            {
                 interes = new Simple(valorPrestado, tiempo, tasa);
            }
            interes.CalcularValorTotal();
            return interes;
        }
        public bool EsCompuesto(string dato)
        {
            if (dato.Equals("Compuesto"))
            {
                return true;
            }
            return false;
        }
        public void Eliminar(string identificacion)
        {
            creditos = Consultar();
            flujoDelFichero = new FileStream(ruta, FileMode.Create);
            flujoDelFichero.Close();
            foreach (Credito item in creditos)
            {
                if (item.Identificacion != identificacion)
                {
                    Guardar(item);
                }
            }
        }
        public void Modificar(Credito credito)
        {
            creditos = Consultar();
            flujoDelFichero = new FileStream(ruta, FileMode.Create);
            flujoDelFichero.Close();
            foreach (Credito item in creditos)
            {
                if (item.Identificacion != credito.Identificacion )
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(credito);
                }
            }
        }
        public Credito Buscar(string numeroDeLiquidacion)
        {
            creditos = Consultar();
            foreach (Credito item in creditos)
            {
                if (item.Identificacion.Equals(numeroDeLiquidacion))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
