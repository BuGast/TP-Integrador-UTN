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
            int valor = 0;
            // Verifico si la coordenada de destino es válida en relación con la posición actual del operador
            if (xDestino >= 0 && xDestino <= mapa.getTamanioMapaKm2() && //me fijo que xDestino sea >=0 y que sea < que el valor máximo de la coord en X del mapa
                yDestino >= 0 && yDestino <= mapa.getTamanioMapaKm2())
            {
                while ((xActual != xDestino || yActual != yDestino)&&valor==0)
                {
                    if (xActual < xDestino)
                    {
                        xActual++;
                        analizarSituacionDelOperador(xActual,yActual,mapa.getTerrenos());
                    }
                    else if (xActual > xDestino)
                    {
                        xActual--;
                        analizarSituacionDelOperador(xActual,yActual, mapa.getTerrenos());
                    }

                    if (yActual < yDestino)
                    {
                        yActual++;
                        analizarSituacionDelOperador(xActual,yActual, mapa.getTerrenos());
                    }
                    else if (yActual > yDestino)
                    {
                        yActual--;
                        analizarSituacionDelOperador(xActual,yActual, mapa.getTerrenos());
                    }
                }
                // Actualizo la coordenada actual del operador
                this.coordX = xActual;
                this.coordY = yActual;
            }
            else
            {
                Console.WriteLine("La coordenada de destino no es válida");
            }
        }

        public int analizarSituacionDelOperador(int xActual,int yActual, TiposZonas[,] terrenos)
        {
            int valor = 0;
            TiposZonas terrenoActual = terrenos[xActual,yActual];
            if ((GetType().Name == "K9"|| GetType().Name == "M8") && terrenoActual == TiposZonas.Lago)
            {
                valor=1;
            }
            return valor;
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
