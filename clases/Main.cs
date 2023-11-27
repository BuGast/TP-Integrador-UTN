using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador.clases
{
    public class Main
    {
        static void main(string[] args)
        {
            GeneradorDeMapa generadorDeMapa = new GeneradorDeMapa();

            generadorDeMapa.CrearMapaVacio();
            generadorDeMapa.MostrarMapa();
        }
    }
}
