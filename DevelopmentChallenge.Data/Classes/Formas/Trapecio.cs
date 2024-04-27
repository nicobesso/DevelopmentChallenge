namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Trapecio : FormaGeometrica
    {
        decimal _base1;
        decimal _base2;

        public Trapecio(decimal alto, decimal base1, decimal base2)
        {
            _base1 = base1;
            _base2 = base2;
            Alto = alto;
        }

        public override decimal CalcularPerimetro()
        {

            return (_base1 + _base2) * Alto;
        }

        public override decimal CalcularArea()
        {
            return (_base1 + _base2) * Alto / 2;
        }
    }
}
