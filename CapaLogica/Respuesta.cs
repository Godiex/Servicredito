using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
namespace CapaLogica
{
    public class Respuesta
    {
        public string Mensaje { get; set; }
        public bool Error { get; set; }
    }
    public class RespuestaConsulta : Respuesta
    {
        public List<Credito> Creditos { get; set; }
    }
    public class RespuestaBusqueda : Respuesta
    {
        public Credito Credito { get; set; }
    }
}
