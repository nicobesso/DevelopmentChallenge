using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Classes.Formas;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            var resumen = FormaGeometricaService.Imprimir(new List<IFormaGeometrica>(), "es-AR");

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", resumen);
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            var resumen = FormaGeometricaService.Imprimir(new List<IFormaGeometrica>(), "en-US");

            Assert.AreEqual("<h1>Empty list of shapes!</h1>", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5)
            };

            var resumen = FormaGeometricaService.Imprimir(formas, "es-AR");

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perímetro 20 <br/>TOTAL:<br/> 1 formas Perímetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormaGeometricaService.Imprimir(formas, "en-US");

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/> 3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormaGeometricaService.Imprimir(formas, "en-US");

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/> 7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormaGeometricaService.Imprimir(formas, "es-AR");

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perímetro 28 <br/>2 Círculos | Area 13,01 | Perímetro 18,06 <br/>3 Triángulos | Area 49,64 | Perímetro 51,6 <br/>TOTAL:<br/> 7 formas Perímetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapecioEnItaliano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Trapecio(4.2m,2,4),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new Trapecio(4.2m,1,2)
            };

            var resumen = FormaGeometricaService.Imprimir(formas, "it-IT");

            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>1 Quadrati | Zona 25 | Perimetro 20 <br/>2 Circolari | Zona 13,01 | Perimetro 18,06 <br/>2 Triangoli | Zona 42 | Perimetro 39 <br/>2 Trapezoidali | Zona 18,9 | Perimetro 37,8 <br/>TOTALE:<br/> 7 forme Perimetro 114,86 Zona 98,91",
                resumen);
        }

        [TestCase]
        public void TestResumenListaSoloTrapecioEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Trapecio(4.2m,1,2),
                new Trapecio(5.2m,3,4),
                new Trapecio(3.2m,2,5),
                new Trapecio(4.2m,2,4)
            };

            var resumen = FormaGeometricaService.Imprimir(formas, "es-AR");

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>4 Trapecios | Area 48,3 | Perímetro 96,6 <br/>TOTAL:<br/> 4 formas Perímetro 96,6 Area 48,3",
                resumen);
        }
    }
}
