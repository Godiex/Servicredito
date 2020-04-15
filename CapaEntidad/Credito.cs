using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Credito
    {
        public string Identificacion {get; set;}
        public Cliente Cliente { get; set; }
        public Interes Interes { get; set; }
        public double ValorTotal { get; set; } 

        public Credito(string identificacion, Cliente cliente, Interes interes)
        {
            Identificacion = identificacion;
            Cliente = cliente;
            Interes = interes;
        }

        public override string ToString()
        {
            return $"{Identificacion};{ValorTotal};{Cliente.ToString()};{Interes.ToString()}";
        }
    }
}
