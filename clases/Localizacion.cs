using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador
{
    internal class Localizacion
    {
        // Prueba 
        //quizás debería ser una matriz por lo que aparenta según la parte 2 del tp y podría llegar a ser algo así
        public string nombreLocalizacion { get; }
        public int coordenadaX { get; }
        public int coordenadaY { get; }
        public TipoLocalizacion tipoLocalizacion { get; }

        
        public Localizacion(string nombre, int coordX, int coordY, TipoLocalizacion tipo)
        {
            nombreLocalizacion = nombre;
            coordenadaX = coordX;
            coordenadaY = coordY;
            tipoLocalizacion = tipo;
        }

        // Inicio de la creacion de la matriz para el tablero "imaginario" de coordenadas.

        string[,] mapa = new string[100, 100]; // a modo de ejemplo, la matriz generada aca tiene espacio de 100x100 (estilo hoja cuadriculada, ejemplo: [0,1] = 1km recorrido)

        public void InicializarTableroVacio() // Este metodo debe generar el terreno con todos los espacios vacios, a determinar la ubicacion de cada objeto.
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mapa[i, j] = "Vacio";
                }
            }
        }


        // Fin de la matriz y sus metodos


    }
}
