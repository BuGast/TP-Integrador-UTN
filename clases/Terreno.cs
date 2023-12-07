// Gastón Camú, Alicia Nazar

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador;

namespace TP_Integrador
{
    
}
//public class Terreno
//{
//    private Localizacion[,] terreno;

//    public Terreno(int tamaño)
//    {
//        terreno = new Localizacion[tamaño, tamaño];
//        InicializarTerrenoAleatoriamente();

//    }


//    private void InicializarTerrenoAleatoriamente(int cantMaxCuarteles, int cantMaxSitiosReciclaje)
//    {
//        int contadorCuarteles = 0;
//        int contadorSitiosReciclaje = 0;

//        Random random = new Random();

//        for (int i = 0; i < terreno.GetLength(0); i++)
//        {
//            for (int j = 0; j < terreno.GetLength(1); j++)
//            {
//                do
//                {
//                    TipoLocalizacion tipo = (TipoLocalizacion)random.Next(Enum.GetValues(typeof(TipoLocalizacion)).Length; //extraigo del enum un valor aleatoriamente)
//                }
//                while (((tipo == Enum.GetName(typeof(TipoLocalizacion), 7)) && ValidarCantCuarteles(contadorCuarteles, cantMaxCuarteles) == false) || ((tipo == Enum.GetName(typeof(TipoLocalizacion), 8)) && ValidarCantSitiosReciclaje(contadorSitiosReciclaje, cantMaxSitiosReciclaje) == false))


//                        terreno[i, j] = new Localizacion($"Ubicación ({i}, {j})", i, j, tipo); //lo asigno en la matriz,le pongo nombre, guardo las coordenadas y el tipo
//            }
//        }
//    }

//    private bool ValidarCantCuarteles(int contadorCuarteles, int cantMaxCuarteles)
//    {
//        if (contadorCuarteles < cantMaxCuarteles)
//        {
//            contadorCuarteles++;
//            return true;
//        }
//    }
//    private bool ValidarCantSitiosReciclaje(int contadorSitiosReciclaje, int cantMaxSitiosReciclaje)
//    {
//        if (contadorSitiosReciclaje < cantMaxSitiosReciclaje)
//        {
//            contadorSitiosReciclaje++;
//            return true;
//        }
//    }
//}