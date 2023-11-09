using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador
{
    public class K9 : Operador
    {
        public K9()
            : base()
        {
            bateria.CargarCargaMaxima(6500);
            cargaMaxima = 40;
        }

        public override void Mover(int[,] coordDeDestino, int[,] coordMapa)
        {
            int xActual = coordActual.GetLength(0); // Obtener la posición actual del operador
            int yActual = coordActual.GetLength(1);
            int xDestino = coordDeDestino.GetLength(0); // Obtener la coordenada de destino
            int yDestino = coordDeDestino.GetLength(1);

            // Verifico si la coordenada de destino es válida en relación con la posición actual del operador
            if (xDestino >= 0 && xDestino <= coordMapa.GetLength(0) && //me fijo que xDestino sea >=0 y que sea < que el valor máximo de la coord en X del mapa
                yDestino >= 0 && yDestino <= coordMapa.GetLength(1))
            {
                while (xActual != xDestino || yActual != yDestino)
                {
                    if (xActual < xDestino)
                    {
                        xActual++;
                    }
                    else if (xActual > xDestino)
                    {
                        xActual--;
                    }

                    if (yActual < yDestino)
                    {
                        yActual++;
                    }
                    else if (yActual > yDestino)
                    {
                        yActual--;
                    }

                    // Actualizo la coordenada actual del operador
                    coordActual[xActual, yActual];
                    // Aquí podría poner luego una función que analice el terreno en el que está y en base a eso ejecute alguna funcionalidad (tp2)
                }
            }
            else
            {
                Console.WriteLine("La coordenada de destino no es válida");
            }
        }
    }
}
