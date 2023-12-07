// Gastón Camú, Alicia Nazar

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador.clases;

namespace TP_Integrador
{
    public abstract class Operador
    {

        string id;
        Bateria bateria;
        string estado;
        int cargaFisicaMaxima;
        int cargaFisicaActual;
        int velocidadOptima;
        int coordX;
        int coordY;

        public Operador(string id,int coordX, int coordY, int cargaBateria, int cargaFisica)
        {
            this.id = id;
            this.bateria = new Bateria(cargaBateria);
            this.estado = Estado.EnEspera.ToString();
            this.cargaFisicaMaxima = cargaFisica;
            this.velocidadOptima = 1;
            this.coordX = coordX;
            this.coordY = coordY;
        }
        public string getEstado(){ return estado; }
        public string getId(){ return id; }
        public int getCoordX(){ return this.coordX; }
        public int getCoordY() { return this.coordY;}
        public void ComprobarBateriaActual()
        {
            Console.WriteLine("carga maxima: " + bateria.MostrarCargaMaxima());
            Console.WriteLine("carga actual: " + bateria.MostrarCargaActual());
        }

        public void TransferirCargaFisica(Operador operador2, int carga)
        {
            if (operador2.cargaFisicaMaxima >= this.cargaFisicaMaxima) 
            {
                operador2.cargaFisicaActual = this.cargaFisicaActual;
                this.cargaFisicaActual = 0;
            }
            else
            {
                Console.WriteLine("error el operador no puede levantar la carga");
            }
        }

        public void VerificarProximidadConOperador()
        {

        }
        public void VerificarEstado()
        {
            //este método se fija si está en espera, disponible, etc
        }

        public void Mover(int x, int y, Mapa mapa)
        {
            int xActual = this.coordX; // Obtener la posición actual del operador
            int yActual = this.coordY;
            int xDestino = x; // Obtener la coordenada de destino
            int yDestino = y;

            // Verifico si la coordenada de destino es válida en relación con la posición actual del operador
            if (xDestino >= 0 && xDestino <= mapa.getTamanioMapaKm2() && //me fijo que xDestino sea >=0 y que sea < que el valor máximo de la coord en X del mapa
                yDestino >= 0 && yDestino <= mapa.getTamanioMapaKm2())
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

        public void MostrarDetallesOperador()
        {
            Console.WriteLine(GetType().Name);
            Console.WriteLine("id: " + id);
            Console.WriteLine("estado: " + estado);
            Console.WriteLine("cargaMaxima: " + cargaFisicaMaxima + " kg");
            Console.WriteLine("velocidad optima: " + velocidadOptima);
            Console.WriteLine("coordenada actual: (" + this.coordX+" - "+this.coordY+")");
            Console.WriteLine("");
            Console.WriteLine("BATERIA");
            Console.WriteLine("carga maxima: " + bateria.MostrarCargaMaxima() + " mAh");
            Console.WriteLine("carga actual: " + bateria.MostrarCargaActual() + " mAh");
            Console.WriteLine("---------------------------------------------------------");

        }
    }

}
