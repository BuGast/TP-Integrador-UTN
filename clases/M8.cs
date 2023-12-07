// Gastón Camú, Alicia Nazar

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador.clases;

namespace TP_Integrador
{
    public class M8 : Operador
    {
        BateriaOperadores valorBateria;
        CargaFisicaOperadores valorCargaFisica;
        public M8(string id, int coordX, int coordY)
            : base(id, coordX, coordY)
        {
            if (Enum.TryParse(BateriaOperadores.M8.ToString(), out valorBateria))
            {
                bateria.CargarCargaMaxima(Convert.ToInt32(valorBateria));
            }
            if (Enum.TryParse(CargaFisicaOperadores.M8.ToString(), out valorCargaFisica))
            {
                cargaMaxima = Convert.ToInt32(valorCargaFisica);
            }
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
/*                    coordActual[xActual, yActual];*/
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
