using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        public string nombre { get; set; }
        public string cedula { get; set; }

        public Cliente(string nombre, string cedula)
        {
            this.nombre = nombre;
            this.cedula = cedula;
        }

        public override string ToString()
        {
            return $"{nombre};{cedula}";
        }
    }
}
