using System;
using System.Linq;
using System.Text;

namespace GeminisTestConsola
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region Ejercicio 1  
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Ej.1:");

            var n = 5;
            Console.WriteLine($"Input:{n}");
            Console.WriteLine("");

            Console.WriteLine("Result:");
            Console.WriteLine("");

            for (int i = 0; i < n; i++)
            {
                // -- Reviso si par o impar para determinar con que letra debe comenzar
                var beginX = (i % 2) == 0;
                var line = new StringBuilder();

                for (int j = 0; j < n; j++)
                {
                    // -- Detecto que caracte char deberia ingresar
                    var chartToAdd = beginX && j == 0 ? "X" : line.ToString().EndsWith("_") ? "X" : "_";

                    // -- Agrego caracter 
                    line.Append(chartToAdd);
                }

                // -- Imprimo linea
                Console.WriteLine(line.ToString());
            }
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");
            #endregion

            #region Ejercicio 2
            Console.WriteLine("Ej.2:");

            int[] myArray = new int[] { 1, 2, -1, 1, 0, 1, 2, -1, -1, -2 };
            Console.WriteLine($"Input: [{string.Join(", ", myArray)}]");

            Console.WriteLine("");

            var c = 4;
            var derecha = 0;
            var abajo = 0;

            for (int i = 0; i <= myArray.Length - 1; i += 2)
            {
                // -- Evaluar derecha
                var irDerecha = myArray[i] + derecha;
                if (irDerecha <= c - 1 && irDerecha >= 0)
                {
                    derecha = irDerecha;
                }
                else if (irDerecha < 0)
                {
                    derecha = 0;
                }
                else if (irDerecha > c - 1)
                {
                    derecha = c - 1;
                }

                // -- Evaluar abajo
                var irAbajo = myArray[i + 1] + abajo;
                if (irAbajo <= c - 1 && irAbajo >= 0)
                {
                    abajo = irAbajo;
                }
                else if (irAbajo < 0)
                {
                    abajo = 0;
                }
                else if (irAbajo > c - 1)
                {
                    abajo = c - 1;
                }
            }

            Console.WriteLine("Result:");
            Console.WriteLine("");

            for (int a = 0; a < c; a++)
            {
                var line = new StringBuilder();
                for (int d = 0; d < c; d++)
                {
                    var chartToAdd = (d == derecha && a == abajo) ? "X" : "0";
                    line.Append(chartToAdd);

                }
                Console.WriteLine(line.ToString());
            }

            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");
            #endregion
        }
    }
}
