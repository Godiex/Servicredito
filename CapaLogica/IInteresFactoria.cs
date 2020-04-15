using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
namespace CapaLogica
{
    interface IInteresFactoria
    {
        Interes CrearInteres(string tipo, double valorPrestado, int tiempo, double tasa);
    }
}
