using System;
using System.Text;

namespace GeminisTestConsola
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region Ejercio 1            
            Console.WriteLine("Ej.1:");

            var n = 15;
            Console.WriteLine($"Input:{n}");

            for (int i = 0; i < n; i++)
            {
                var beginX = (i % 2) == 0;
                var line = new StringBuilder();

                for (int j = 0; j < n; j++)
                {
                    var chartToAdd = beginX && j == 0 ? "X" : line.ToString().EndsWith("_") ? "X" : "_";
                    line.Append(chartToAdd);
                }
                Console.WriteLine(line.ToString());
            }
            #endregion
        }
    }
}
