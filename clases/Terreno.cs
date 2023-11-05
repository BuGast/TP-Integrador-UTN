using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador
{
    public class Terreno
    {
        private Localizacion[,] terreno;

        public Terreno(int tamaño)
        {
            terreno = new Localizacion[tamaño, tamaño];
            
        }


        private void InicializarTerrenoAleatoriamente()
        {
            Random random = new Random();

            for (int i = 0; i < terreno.GetLength(0); i++)
            {
                for (int j = 0; j < terreno.GetLength(1); j++)
                {
                    TipoLocalizacion tipo = (TipoLocalizacion)random.Next(Enum.GetValues(typeof(TipoLocalizacion)).Length); //extraigo del enum un valor aleatoriamente
                    terreno[i, j] = new Localizacion($"Celda ({i}, {j})", tipo); //lo asigno en la matriz
                }
            }
        }
    }
}
