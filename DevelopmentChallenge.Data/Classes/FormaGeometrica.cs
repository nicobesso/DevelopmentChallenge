namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica : IFormaGeometrica
    {
        public decimal Ancho;
        public decimal Alto;

        public abstract decimal CalcularPerimetro();

        public abstract decimal CalcularArea();
    }
}
