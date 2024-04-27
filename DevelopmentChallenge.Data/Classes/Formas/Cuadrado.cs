namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Cuadrado : FormaGeometrica
    {
        public Cuadrado(int lado)
        {
            Ancho = lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Ancho * 4;
        }

        public override decimal CalcularArea()
        {
            return Ancho * Ancho;
        }
    }
}
