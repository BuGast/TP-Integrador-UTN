using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador.clases
{
    internal class GeneradorDeMapa
    {
        public enum Ubicaciones
        {

            Cuartel,
            TerrenoVacio,
            Localizacion1,
            Localizacion2,
            Localizacion3
        }

        public Dictionary<Ubicaciones, (int x, int y)> coordenadasUbicaciones = new Dictionary<Ubicaciones, (int x, int y)>
        {
            { Ubicaciones.Cuartel, (0, 0) },
            { Ubicaciones.Localizacion1, (40, 40) },
            { Ubicaciones.Localizacion2, (65, 50) },
            { Ubicaciones.Localizacion3, (122, 120) }
            // Se pueden añadir mas coordenadas eventualmente
        };

        public (int x, int y) ObtenerCoordenadasDeUbicacion(Ubicaciones listaUbicaciones)
        {
            if (coordenadasUbicaciones.ContainsKey(listaUbicaciones))
            {
                return coordenadasUbicaciones[listaUbicaciones];
            }
            return (-1, -1);
        }


        string[,] mapa = new string[130, 130];

        public void CrearMapaVacio()
        {
            for (int x = 0; x < mapa.GetLength(0); x++)
            {
                for (int y = 0; y < mapa.GetLength(1); y++)
                {
                    mapa[x, y] = Ubicaciones.TerrenoVacio.ToString(); // Establecer inicialmente todo como TerrenoVacio
                }
            }
        }

        internal void MostrarMapa() // Metodo para mostrar todas las posiciones generadas y lo que posee
        {
            for (int x = 0; x < mapa.GetLength(0); x++)
            {
                for (int y = 0; y < mapa.GetLength(1); y++)
                {
                    Console.WriteLine($"Posición: [{x},{y}] - Tipo de terreno: {mapa[x, y]}");
                }
            }
        }

        public int CalcularDistancia(int x1, int y1, int x2, int y2)
        {
            int distanciaX = Math.Abs(x2 - x1); // Diferencia en unidades en el eje X
            int distanciaY = Math.Abs(y2 - y1); // Diferencia en unidades en el eje Y

            int distanciaTotal = (distanciaX + distanciaY) * 100; // Cada unidad representa 100 metros

            return distanciaTotal; // Devuelve la distancia en metros
        }

        public string[,] ObtenerMapa()
        {
            return mapa; // Probando para poder acceder a la matriz desde otra clase
        }

        public void ActualizarPosicion(int x, int y, string nuevoValor) // Metodo para Actualizar una posicion en especifico, podria ser de utilidad para el TP2
        {
            if (x >= 0 && x < mapa.GetLength(0) && y >= 0 && y < mapa.GetLength(1))
            {
                mapa[x, y] = nuevoValor; // Actualizamos el valor de la posicion seleccionada con el nuevo valor establecido
            }
            else
            {
                Console.WriteLine("Coordenadas fuera del mapa. No se pudo actualizar la posición.");
            }
        }

        public string BuscarEnMapa() // Método para buscar una posición específica en el mapa.
        {
            int x = 0; // Inicialización de la coordenada x.
            int y = 0; // Inicialización de la coordenada y.

            bool coordenadasValidas = false; // Variable booleana para comprobar la validez de las coordenadas.

            while (!coordenadasValidas) // Bucle para solicitar las coordenadas hasta que sean válidas.
            {
                bool xValido = false; // Variable booleana para comprobar si x es válido.
                bool yValido = false; // Variable booleana para comprobar si y es válido.

                while (!xValido) // Bucle para solicitar una coordenada x válida.
                {
                    Console.WriteLine("Ingrese la posición 'x':");
                    string inputX = Console.ReadLine();

                    if (int.TryParse(inputX, out int resultadoX)) // Verifica si el valor ingresado para x es un número entero.
                    {
                        x = resultadoX; // Asigna el valor de x si la variable es válido.
                        xValido = true; // Indica que la coordenada x si la variable es válida.
                    }
                    else
                    {
                        Console.WriteLine("Valor ingresado no válido. Intente de nuevo.");
                    }
                }

                while (!yValido) // Bucle para solicitar una coordenada y válidarla.
                {
                    Console.WriteLine("Ingrese la posición 'y':");
                    string inputY = Console.ReadLine();

                    if (int.TryParse(inputY, out int resultadoY)) // Verifica si el valor ingresado para y es un número entero.
                    {
                        y = resultadoY; // Asigna el valor de y si es válido.
                        yValido = true; // Indica que la coordenada y es válida.
                    }
                    else
                    {
                        Console.WriteLine("Valor ingresado no válido. Intente de nuevo.");
                    }
                }

                if (x >= 0 && x < mapa.GetLength(0) && y >= 0 && y < mapa.GetLength(1)) // Verifica si las coordenadas están dentro del rango del mapa.
                {
                    coordenadasValidas = true; // Indica que las coordenadas ingresadas son válidas.
                }
                else
                {
                    Console.WriteLine("Coordenadas fuera del mapa. Intente de nuevo."); // Mensaje si las coordenadas están fuera del mapa.
                }
            }

            return $"Posición: {mapa[x, y]}"; // Devuelve el tipo de terreno en la posición ingresada.
        }
    }
}
