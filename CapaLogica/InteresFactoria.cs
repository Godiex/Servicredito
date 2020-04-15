using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaLogica
{
    public class InteresFactoria : IInteresFactoria
    {
        public Interes CrearInteres(string tipo, double valorPrestado, int tiempo,double tasa)
        {
            Interes interes;
            if (tipo.Equals("c"))
            {
                interes  = new Compuesto(valorPrestado, tiempo,tasa);
                interes.CalcularValorTotal();
            }
            else
            {
                interes = new Simple(valorPrestado, tiempo, tasa);
                interes.CalcularValorTotal();
            }
            return interes;

        }
    }
}
