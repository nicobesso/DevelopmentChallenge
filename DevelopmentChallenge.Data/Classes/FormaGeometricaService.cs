using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public static class FormaGeometricaService
    {
        public static string Imprimir(List<IFormaGeometrica> formas, string culture)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var sb = new StringBuilder();

            // si no hay formas, se devuelve sólo el encabezado.
            if (formas.Count == 0) return Resources.Settings.ListaVacia;

            CargarEncabezado(ref sb, formas);

            CargarCuerpo(ref sb, formas);

            CargarPie(ref sb, formas);

            return sb.ToString();
        }

        private static void CargarLinea(ref StringBuilder sb, string tipo, int cantidad, decimal area, decimal perimetro)
        {
            var text = Resources.Settings.LineaCuerpo;

            var type = Resources.Settings.ResourceManager.GetObject(tipo).ToString();
            var types = type.Split('|');
            var strType = (cantidad == 1) ? types[0] : types[1];

            var linea = string.Format(text, cantidad, strType, area.ToString("#.##"), perimetro.ToString("#.##"));

            sb.Append(linea);
        }

        private static void CargarEncabezado(ref StringBuilder sb, List<IFormaGeometrica> formas)
        {
            var text = Resources.Settings.Cabecera;

            var linea = string.Format(text);

            sb.Append(linea);
        }

        private static void CargarCuerpo(ref StringBuilder sb, List<IFormaGeometrica> formas)
        {
            var cantidad = 0;
            var area = 0m;
            var perimetro = 0m;

            // obtengo los distintos tipos de formas.
            var tipos = new List<string>();

            foreach (var forma in formas)
            {
                Type type = forma.GetType();
                string typeName = type.Name;
                if (!tipos.Contains(typeName)) tipos.Add(typeName);
            }

            // recorro los distintos tipos de formas para calcular el cuerpo de cada uno.
            foreach (var tipo in tipos)
            {
                var formasPorTipo = formas.FindAll(x => x.GetType().Name == tipo);

                cantidad = formasPorTipo.Count;
                area = formasPorTipo.Sum(x => x.CalcularArea());
                perimetro = formasPorTipo.Sum(x => x.CalcularPerimetro());

                CargarLinea(ref sb, tipo, cantidad, area, perimetro);
            }
        }

        private static void CargarPie(ref StringBuilder sb, List<IFormaGeometrica> formas)
        {
            var totalPie = Resources.Settings.TotalPie;
            var totalFormas = Resources.Settings.TotalFormas;
            var totalPerimetro = Resources.Settings.PerimetroTotal;
            var totalArea = Resources.Settings.AreaTotal;

            // calculo los totales de todas las formas
            var lnTotalPie = totalPie;
            var lnTotalFormas = string.Format(totalFormas, formas.Count);
            var lnTotalPerimetro = string.Format(totalPerimetro, formas.Sum(x => x.CalcularPerimetro()).ToString("#.##"));
            var lnTotalArea = string.Format(totalArea, formas.Sum(x => x.CalcularArea()).ToString("#.##"));

            sb.Append(lnTotalPie);
            sb.Append(lnTotalFormas);
            sb.Append(lnTotalPerimetro);
            sb.Append(lnTotalArea);
        }
    }
}
