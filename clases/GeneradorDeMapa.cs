// GUSTAVO MARTIN CANTARELLA

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TP_Integrador.clases.GeneradorDeMapa;


namespace TP_Integrador.clases
{
    public class GeneradorDeMapa
    {
        private GeneradorDeLocalizaciones generadorLocalizaciones = new GeneradorDeLocalizaciones();

        TipoLocalizaciones.TipoLocalizacion[,] mapa = new TipoLocalizaciones.TipoLocalizacion[100, 100]; // Matriz Hardcodeada segun el tp integrador 2 (20,20 para probar funcionalidad)

        public void CrearMapaVacio()
        {
            for (int x = 0; x < mapa.GetLength(0); x++)
            {
                for (int y = 0; y < mapa.GetLength(1); y++)
                {
                    TipoLocalizaciones.TipoLocalizacion localizacion = generadorLocalizaciones.LocalizacionAleatoria();
                    mapa[x, y] = localizacion;
                }
            }

            /* Posicion de cuarteles a distancias equilibradas segun el tamaño de la matriz a generar.
             * 
             * La generacion aleatoria de las posiciones con limites de generacion eran demasiado locas, le di un poco de logica al ponerlas en posiciones
             * "Fijas", aunque no tanto ya que dependen del tamaño de la matriz a generar [100,100] segun el tp 2, de manera que estuvieran a distancias,
             * mas o menos con algun sentido la una con la otra.
             * 
             * Misma Funcion para Los sitios de reciclaje.
            */
            PosicionarCuartelEnMatriz(1, 1);
            PosicionarCuartelEnMatriz(mapa.GetLength(0) / 2, mapa.GetLength(1) / 2);
            PosicionarCuartelEnMatriz(mapa.GetLength(0) - 9, mapa.GetLength(1) - 9);

            PosicionarReciclajeEnMatriz(2, 2);
            PosicionarReciclajeEnMatriz(mapa.GetLength(0) / 9, mapa.GetLength(1) / 9);
            PosicionarReciclajeEnMatriz(mapa.GetLength(0) / 6, mapa.GetLength(1) / 6); 
            PosicionarReciclajeEnMatriz(mapa.GetLength(0) / 2, mapa.GetLength(1) / 2);
            PosicionarReciclajeEnMatriz(mapa.GetLength(0) - 10, mapa.GetLength(1) - 10);


        }

        private void PosicionarCuartelEnMatriz(int x, int y)
        {
            if (x >= 0 && x < mapa.GetLength(0) && y >= 0 && y < mapa.GetLength(1))
            {
                mapa[x, y] = TipoLocalizaciones.TipoLocalizacion.Cuartel;
            }
        }

        private void PosicionarReciclajeEnMatriz(int x, int y)
        {
            if (x >= 0 && x < mapa.GetLength(0) && y >= 0 && y < mapa.GetLength(1))
            {
                mapa[x, y] = TipoLocalizaciones.TipoLocalizacion.SitioReciclaje;
            }
        }        

        internal void MostrarMapa() // Metodo para mostrar todas las posiciones generadas y lo que posee cada una
        {
            for (int x = 0; x < mapa.GetLength(0); x++)
            {
                for (int y = 0; y < mapa.GetLength(1); y++)
                {
                    Console.WriteLine($"Posición: [ {x},{y} ] - Tipo de terreno: {mapa[x, y]}");
                }
            }
        }

        public int CalcularDistancia(int x1, int y1, int x2, int y2)  // Metodo creado para calcular distancias de un punto a otro.
        {
            int distanciaX = Math.Abs(x2 - x1); // Diferencia en unidades en el eje X
            int distanciaY = Math.Abs(y2 - y1); // Diferencia en unidades en el eje Y

            int distanciaTotal = (distanciaX + distanciaY) * 100; // Cada unidad representa 100 metros

            return distanciaTotal; // Devuelve la distancia en metros
        }

        public TipoLocalizaciones.TipoLocalizacion[,] ObtenerMapa()
        {
            return mapa; // Devuelve la matriz de TipoLocalizacion
        }

        public void FiltrarUbicacionesPorTipo()
        {
            bool continuar = false;

            do
            {
                Console.WriteLine("Seleccione el tipo de localización que desea buscar:");
                Console.WriteLine("1. Terreno Baldío");
                Console.WriteLine("2. Planicie");
                Console.WriteLine("3. Bosque");
                Console.WriteLine("4. Sector Urbano");
                Console.WriteLine("5. Vertedero");
                Console.WriteLine("6. Lago");
                Console.WriteLine("7. Vertedero Electrónico");
                Console.WriteLine("8. Cuartel");
                Console.WriteLine("9. Sitio de Reciclaje");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    TipoLocalizaciones.TipoLocalizacion tipoSeleccionado;

                    switch (opcion)
                    {
                        case 1:
                            tipoSeleccionado = TipoLocalizaciones.TipoLocalizacion.TerrenoBaldio;
                            break;
                        case 2:
                            tipoSeleccionado = TipoLocalizaciones.TipoLocalizacion.Planicie;
                            break;
                        case 3:
                            tipoSeleccionado = TipoLocalizaciones.TipoLocalizacion.Bosque;
                            break;
                        case 4:
                            tipoSeleccionado = TipoLocalizaciones.TipoLocalizacion.SectorUrbano;
                            break;
                        case 5:
                            tipoSeleccionado = TipoLocalizaciones.TipoLocalizacion.Vertedero;
                            break;
                        case 6:
                            tipoSeleccionado = TipoLocalizaciones.TipoLocalizacion.Lago;
                            break;
                        case 7:
                            tipoSeleccionado = TipoLocalizaciones.TipoLocalizacion.VertederoElectronico;
                            break;
                        case 8:
                            tipoSeleccionado = TipoLocalizaciones.TipoLocalizacion.Cuartel;
                            break;
                        case 9:
                            tipoSeleccionado = TipoLocalizaciones.TipoLocalizacion.SitioReciclaje;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            continue;
                    }

                    // Filtrar y mostrar ubicaciones del tipo seleccionado
                    MostrarUbicacionesFiltradas(tipoSeleccionado);

                    // Preguntar si desea buscar otra ubicación
                    int respuesta;
                    do
                    {
                        Console.WriteLine("¿Desea buscar otra ubicación?");
                        Console.WriteLine("1. Sí");
                        Console.WriteLine("2. No");

                        if (int.TryParse(Console.ReadLine(), out respuesta) && (respuesta == 1 || respuesta == 2))
                        {
                            continuar = (respuesta == 1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida. Ingrese 1 para Sí o 2 para No.");
                        }
                    } while (true);
                }
                else
                {
                    Console.WriteLine("Opción no válida. Ingrese un número.");
                }
            } while (continuar!);
        }



        private void MostrarUbicacionesFiltradas(TipoLocalizaciones.TipoLocalizacion tipoSeleccionado)
        {
            Console.WriteLine($"Ubicaciones de tipo {tipoSeleccionado}:");

            for (int x = 0; x < mapa.GetLength(0); x++)
            {
                for (int y = 0; y < mapa.GetLength(1); y++)
                {
                    if (mapa[x, y] == tipoSeleccionado)
                    {
                        Console.WriteLine($"Posición: [{x},{y}] - Tipo de terreno: {tipoSeleccionado}");
                    }
                }
            }
        }


        public string BuscarEnMapa() // Método para buscar una posición específica en el mapa.
        {
            int x = 0; // Inicialización de la coordenada x.
            int y = 0; // Inicialización de la coordenada y.

            bool coordenadasValidas = false; // Para que vea que no le mande un While(true)

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

//public void CrearMapaVacio()
//{
//    for (int x = 0; x < mapa.GetLength(0); x++)
//    {
//        for (int y = 0; y < mapa.GetLength(1); y++)
//        {
//            TipoLocalizaciones.TipoLocalizacion localizacion = generadorLocalizaciones.LocalizacionAleatoria();
//            mapa[x, y] = localizacion;
//        }
//    }
//}        

//private void ColocarCuartelEquidistante(int x, int y)
//{
//    // Obtener el número actual de cuarteles generados
//    int cuartelesGenerados = generadorLocalizaciones.ObtenerCantidadTerrenoGenerado(TipoLocalizaciones.TipoLocalizacion.Cuartel);

//    // Verificar si se ha alcanzado el límite de cuarteles
//    if (cuartelesGenerados < 3)
//    {
//        // Calcular la distancia mínima equilibrada entre cuarteles (ajusta según tus necesidades)
//        int distanciaMinima = mapa.GetLength(0) / 3; // Divide el mapa en 3 secciones

//        // Verificar si la posición actual cumple con la distancia mínima
//        if (x % distanciaMinima == 0 && y % distanciaMinima == 0)
//        {
//            // Colocar el cuartel en la posición
//            mapa[x, y] = TipoLocalizaciones.TipoLocalizacion.Cuartel;
//        }
//    }
//}

//public void CrearMapaVacio()
//{
//    for (int x = 0; x < mapa.GetLength(0); x++)
//    {
//        for (int y = 0; y < mapa.GetLength(1); y++)
//        {
//            mapa[x, y] = generadorLocalizaciones.LocalizacionAleatoria(); // Establecer inicialmente todo como TerrenoVacio
//        }
//    }
//}

//public enum Ubicaciones
//{
//    Cuartel,
//    TerrenoBaldio,
//    Planicie,
//    Bosque,
//    SectorUrbano,
//    Vertedero,
//    Lago,
//    VertederoElectronico,
//    SitioReciclaje
//}

//public Dictionary<Ubicaciones, (int x, int y)> coordenadasUbicaciones = new Dictionary<Ubicaciones, (int x, int y)>
//{
//    { Ubicaciones.Cuartel, (0, 0) },
//    { Ubicaciones.Localizacion1, (40, 40) },
//    { Ubicaciones.Localizacion2, (65, 50) },
//    { Ubicaciones.Localizacion3, (122, 120) }
//    // Se pueden añadir mas coordenadas eventualmente
//};

//public (int x, int y) ObtenerCoordenadasDeUbicacion(Ubicaciones listaUbicaciones)
//{
//    if (coordenadasUbicaciones.ContainsKey(listaUbicaciones))
//    {
//        return coordenadasUbicaciones[listaUbicaciones];
//    }
//    return (-1, -1);
//}

//public void ActualizarPosicion(int x, int y, string nuevoValor) // Metodo para Actualizar una posicion en especifico, podria ser de utilidad para el TP2
//{
//    if (x >= 0 && x < mapa.GetLength(0) && y >= 0 && y < mapa.GetLength(1))
//    {
//        mapa[x, y] = nuevoValor; // Actualizamos el valor de la posicion seleccionada con el nuevo valor establecido
//    }
//    else
//    {
//        Console.WriteLine("Coordenadas fuera del mapa. No se pudo actualizar la posición.");
//    }
//}