using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        public TrianguloEquilatero(decimal lado)
        {
            Alto = lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Alto * 3;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * Alto * Alto;
        }
    }
}
