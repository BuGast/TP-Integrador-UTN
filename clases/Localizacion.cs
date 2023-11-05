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
    }
}
