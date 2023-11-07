using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador;

namespace TP_Integrador
{
    public class Localizacion
    {
        string[,] mapa = new string[13, 13];

        public void CrearMapaVacio()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    mapa[i, j] = "Vacio";
                }
            }

            // El cuartel ocupara siempre la posicion (0, 0) en esta primer parte del programa
            mapa[0, 0] = "Cuartel";

            // usaremos 3 localizaciones de momento, para llegar a la distancia maxima de cada Operador

            int localizacion1X = 4; // Aproximadamente 4000m / 100m = 40 - Mas o menos, puede modificarse porque todavia esta en fase de prueba y error
            int localizacion1Y = 4;
            mapa[localizacion1X, localizacion1Y] = "Localizacion1";

            int localizacion2X = 6; // Aproximadamente 6500m / 100m = 65 - Igual que arriba
            int localizacion2Y = 5;
            mapa[localizacion2X, localizacion2Y] = "Localizacion2";

            int localizacion3X = 12; // Aproximadamente 12250m / 100m = 122.5 - Distancia maxima en este caso
            int localizacion3Y = 12;
            mapa[localizacion3X, localizacion3Y] = "Localizacion3";
        }

        public void MostrarMapa()
        {
            for (int x = 0; x < mapa.GetLength(0); x++)
            {
                for (int y = 0; y < mapa.GetLength(1); y++)
                {
                    Console.WriteLine($"Posición: [{x},{y}] - Tipo de terreno: {mapa[x, y]}");
                }
            }
        }

        public string[,] ObtenerMapa()
        {
            return mapa; // Probando para poder acceder a la matriz desde otra clase
        }

        public void ActualizarPosicion(int x, int y, string nuevoValor)
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

//public string nombreLocalizacion { get; }
//public int coordenadaX { get; }
//public int coordenadaY { get; }
//public TipoLocalizacion tipoLocalizacion { get; }


//public Localizacion(string nombre, int coordX, int coordY, TipoLocalizacion tipo)
//{
//    nombreLocalizacion = nombre;
//    coordenadaX = coordX;
//    coordenadaY = coordY;
//    tipoLocalizacion = tipo;
//}