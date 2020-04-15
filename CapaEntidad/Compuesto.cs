using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public  class Compuesto : Interes
    {
        public Compuesto( double valorPrestado, int tiempo,double tasa) : base("Compuesto", valorPrestado, tiempo, tasa)
        {
        }

        public override void CalcularValorTotal()
        {
            ValorInteres = ValorPrestado * (1 + (Tasa* Tiempo));
        }
    }
}
