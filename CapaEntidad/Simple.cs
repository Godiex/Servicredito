using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Simple : Interes
    {
        public Simple(double valorPrestado, int tiempo,double tasa) : base("Simple", valorPrestado, tiempo, tasa)
        {
        }
        public override void CalcularValorTotal()
        {
            ValorInteres = ValorPrestado * Math.Pow((1+Tasa), Tiempo);
        }
    }
}
