using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicredito
{
    public  class Lectura
    {
        public string ValidarRespuesta(string texto)
        {
            string opcion = LeerCadena(texto).ToLower();
            while ((opcion != "s") && (opcion != "n"))
            {
                opcion = Leer("Error, Digite -> (s) o Digite ->  (n)");
            }
            return opcion;
        }
        public string LeerNumerico(string valor)
        {
            string numero = ValidarEntradaNumerica(valor);
            return numero;
        }
        public string LeerCadena(string valor)
        {
            string cadena = ValidarEntradaCadena(valor);
            return cadena;
        }
        public string Leer(string valor)
        {
            Console.WriteLine(valor);
            return Console.ReadLine();
        }
        public bool EsCadenaAlfabetica(string opcion)
        {
            char[] cadena = opcion.ToCharArray();
            for (int i = 0; i < cadena.Length; i++)
            {
                if ((!Char.IsLetter(cadena[i])) && (cadena[i] != ' '))
                {
                    return false;
                }
            }
            return true;
        }
        public string ValidarEntradaCadena(string valor)
        {
            string opcion = Leer(valor);
            while (!EsCadenaAlfabetica(opcion))
            {
                opcion = Leer("Error de formato, digite solo letras");
            }
            return opcion;
        }
        public string ValidarEntradaNumerica(string valor)
        {
            string opcion = Leer(valor);
            while (!EsNumerico(opcion))
            {
                opcion = Leer("Error de formato, digite solo numeros :");
            }
            return opcion;
        }
        public bool EsNumerico(string valor)
        {
            int resultado;
            return int.TryParse(valor, out resultado);
        }
        public void CrearTitulo(string titulo)
        {
            Console.Clear();
            Console.WriteLine("************* SERVICREDITO*************");
            Console.WriteLine("**************************************************");
            Console.WriteLine(titulo);
        }
        public void CrearPausa()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite Enter Para Continuar");
            Console.ReadKey();
        }
    }
}
