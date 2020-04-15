using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public abstract class Interes
    {
        public double ValorPrestado { get; set; }
        public double ValorInteres { get; set; }
        public int Tiempo { get; set; }
        public double Tasa { get; set; }
        public string Tipo { get; set; }
        public Interes(string tipo, double valorPrestado, int tiempo, double tasa)
        {
            Tasa = tasa/100;
            Tipo = tipo;
            ValorPrestado = valorPrestado;
            Tiempo = tiempo;
        }
        public abstract void CalcularValorTotal();

        public override string ToString()
        {
            return $"{Tipo};{Tiempo};{Tasa};{ValorPrestado};{ValorInteres}";
        }
    }
}
