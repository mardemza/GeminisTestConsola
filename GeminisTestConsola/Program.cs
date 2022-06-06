using System;
using System.Collections.Generic;
using System.Dynamic;
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

            #region Ejercicio 3
            Console.WriteLine("Ej.3:");
            Console.WriteLine("");

            // -- Init Vagones

            var capacidad = 141;
            var longitud = (decimal)15.4;
            var alto = (decimal)3;
            var ancho = capacidad / (longitud * alto);
            var tren1ConVagones = new List<VagonModel>();

            // -- Vagon 1
            var vagon1 = new VagonModel
            {
                Longitud = longitud,
                Alto = alto,
                Ancho = ancho
            };

            // -- Vagon 2
            var vagon2 = new VagonModel
            {
                Longitud = longitud,
                Alto = alto,
                Ancho = ancho
            };

            // -- Vagon 3
            var vagon3 = new VagonModel
            {
                Longitud = longitud,
                Alto = alto,
                Ancho = ancho
            };

            tren1ConVagones.Add(vagon1);
            tren1ConVagones.Add(vagon2);
            tren1ConVagones.Add(vagon3);


            // -- Cargar las cajas separadas por una "x" los tamaños y las cajas separadas por ";"
            // -- Ejemplo: 3x3x2;2x3x2;4x3x3;2x2x4 n...

            // -- Ingreso las cajas
            var cajas = CargarCajas();

            // -- Valido que no supere la capacidad
            if (ValidarCapacidadTotalDeCajas(cajas, tren1ConVagones))
                Console.WriteLine("Las cajas ingresadas superan la capacidad de los vagones");

            Console.WriteLine("");
            Console.WriteLine("Result:");
            Console.WriteLine("");
            Console.WriteLine($"--------------------------------------------------");

            // -- Distribuyo las cajas
            DistribuirCajasEnVagones(cajas, tren1ConVagones);

            // -- Imprimo el estado de los vagones
            ImprimirTrenConVagones(tren1ConVagones);

            #endregion
        }

        private static void ImprimirTrenConVagones(List<VagonModel> tren1ConVagones)
        {            
            var indiceVagon = 1;
            foreach (var vagon in tren1ConVagones)
            {
                Console.WriteLine($"");
                Console.WriteLine($"- Vagon: {indiceVagon}");
                Console.WriteLine($"-- Alto: {vagon.Alto} mts");
                Console.WriteLine($"-- Ancho: {decimal.Round(vagon.Ancho,2)} mts");
                Console.WriteLine($"-- Longitud: {vagon.Longitud} mts");
                Console.WriteLine($"-- Capacidad: {decimal.Round(vagon.Capacidad,2)} m3");
                Console.WriteLine($"-- Capacidad Ocupada: {decimal.Round(vagon.CapacidadOcupada,2)} m3");
                Console.WriteLine($"-- Cantidad de cajas: {vagon.Cajas.Count}");
                Console.WriteLine($"");
                var indiceCaja = 1;
                foreach (var caja in vagon.Cajas)
                {
                    Console.WriteLine($"--- Caja: {indiceCaja}");
                    Console.WriteLine($"---- Alto: {caja.Alto} mts");
                    Console.WriteLine($"---- Ancho: {decimal.Round(caja.Ancho,2)} mts");
                    Console.WriteLine($"---- Longitud: {caja.Longitud} mts");
                    Console.WriteLine($"---- Capacidad: {decimal.Round(caja.Capacidad,2)} m3");
                    indiceCaja++;
                    Console.WriteLine($"");
                }
                Console.WriteLine($"--------------------------------------------------");
                indiceVagon++;
            }
            Console.WriteLine($"");
        }

        private static void DistribuirCajasEnVagones(List<TamanioModel> cajas, List<VagonModel> tren1)
        {
            // -- Recupero la primer caja con capacidad más chica
            var cajaAdd = cajas.First();

            // -- Recupero el vagon con capacidad ocupada más grande y le agrego la caja con menos capacidad.
            tren1.OrderBy(x => x.CapacidadOcupada).First().Cajas.Add(cajaAdd);

            // -- Remuevo la caja agregada
            cajas.Remove(cajaAdd);

            // -- Consulto si existen cajas y llamo al metodo recursivamente. 
            if (cajas.Any())
            {
                DistribuirCajasEnVagones(cajas, tren1);
            }
        }

        private static bool ValidarCapacidadTotalDeCajas(List<TamanioModel> cajas, List<VagonModel> tren)
        {
            var capacidadTotalDeTrenes = tren.Sum(tren => tren.Capacidad);
            var capacidadTotalCajasIngresas = cajas.Sum(caja => caja.Capacidad);

            Console.WriteLine(""); 

            foreach (var caja in cajas)
            {
                Console.WriteLine($"Caja: {caja.Alto}x{caja.Ancho}x{caja.Longitud}, Capacidad: {caja.Capacidad}");
            }

            return (capacidadTotalCajasIngresas > capacidadTotalDeTrenes);
        }

        private static List<TamanioModel> CargarCajas()
        {
            Console.WriteLine("");
            Console.WriteLine("Por favor ingrese las cajas separadas por una 'x' y ';'.");
            Console.WriteLine("Ejemplo: 3x3x2;2x3x2;3x2x4;4x3x3;2x2x4 n...");
            Console.WriteLine("Donde la representación de los datos es {alto}x{ancho}x{longitud}");
            Console.WriteLine("");

            var cajas = new List<TamanioModel>();
            var lineas = Console.ReadLine().Split(";").Where(x => !string.IsNullOrEmpty(x)).ToList();

            try
            {
                foreach (var linea in lineas)
                {
                    var lineaCajas = linea.ToLower().Split("x");

                    if (!lineaCajas.Any() || lineaCajas.Length != 3) throw new Exception("Error");

                    var alto = decimal.Parse(lineaCajas[0]);
                    var ancho = decimal.Parse(lineaCajas[1]);
                    var longitud = decimal.Parse(lineaCajas[2]);

                    if (alto < 0 || ancho < 0 || longitud < 0) throw new Exception("Error");

                    var caja = new TamanioModel
                    {
                        Alto = alto,
                        Ancho = ancho,
                        Longitud = longitud
                    };

                    cajas.Add(caja);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error al leer los datos");
                return CargarCajas();
            }

            return cajas;
        }

        public class TamanioModel
        {
            public decimal Alto { get; set; } = 0;
            public decimal Ancho { get; set; } = 0;
            public decimal Longitud { get; set; } = 0;
            public decimal Capacidad
            {
                get
                {
                    return Alto * Ancho * Longitud;
                }
            }
        }

        public class VagonModel : TamanioModel
        {
            public List<TamanioModel> Cajas { get; set; } = new List<TamanioModel>();

            public decimal CapacidadOcupada
            {
                get
                {
                    return Cajas.Sum(x => x.Capacidad);
                }
            }
        }
    }
}
