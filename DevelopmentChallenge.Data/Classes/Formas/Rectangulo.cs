namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Rectangulo : FormaGeometrica
    {
        public Rectangulo(decimal alto, decimal ancho)
        {
            Ancho = ancho;
            Alto = alto;
        }

        public override decimal CalcularPerimetro()
        {
            return (2 * Ancho) + (2 * Alto);
        }

        public override decimal CalcularArea()
        {
            return Ancho * Alto;
        }
    }
}
