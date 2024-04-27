using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Circulo : FormaGeometrica
    {
        public Circulo(decimal alto)
        {
            Alto = alto;
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * Alto;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (Alto / 2) * (Alto / 2);
        }
    }
}
