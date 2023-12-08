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
        SimuladorDeDaños simuladorDeDaños = new SimuladorDeDaños();
        public Operador(string id,int coordX, int coordY, int cargaBateria, int cargaFisica)
        {
            this.id = id;
            this.bateria = new Bateria(cargaBateria, simuladorDeDaños);
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
        public int getVelocidadOptima() {  return velocidadOptima; }
        public void setVelocidadOptima(int velocidadOptima) { this.velocidadOptima = velocidadOptima; }
        public void ComprobarBateriaActual()
        {
            Console.WriteLine("carga maxima: " + bateria.getCargaMaxima());
            Console.WriteLine("carga actual: " + bateria.getCargaActual());
        }

        public void TransferirCargaFisica(Operador operador2, int carga)
        {
            if (simuladorDeDaños.ServoAtascado == false)
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
                while ((xActual != xDestino || yActual != yDestino)&&valor==0 && Convert.ToInt32(bateria.getCargaActual) > 0)
                {
                    if (xActual < xDestino)
                    {
                        xActual++;
                        analizarSituacionDelOperador(xActual,yActual,mapa);
                    }
                    else if (xActual > xDestino)
                    {
                        xActual--;
                        analizarSituacionDelOperador(xActual,yActual, mapa);
                    }

                    if (yActual < yDestino)
                    {
                        yActual++;
                        analizarSituacionDelOperador(xActual,yActual, mapa);
                    }
                    else if (yActual > yDestino)
                    {
                        yActual--;
                        analizarSituacionDelOperador(xActual,yActual, mapa);
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

        public int analizarSituacionDelOperador(int xActual, int yActual, Mapa mapa)
        {
            Random randy = new Random();
            int valor = 0;
            TiposZonas[,] terreno = mapa.getTerrenos();
            TiposZonas terrenoActual = terreno[xActual, yActual];
            List<TiposZonas> terrenosComunes = mapa.getTerrenosComunes();
            if ((GetType().Name == "K9"|| GetType().Name == "M8") && terrenoActual == TiposZonas.Lago)
            {
                valor=1;
            }
            else if (terrenoActual == TiposZonas.Vertedero)
            {
                int probabilidad = randy.Next(0, 101);
                if (probabilidad <= 5)
                { 
                }
            }
            else if (terrenoActual == TiposZonas.VertederoElectronico)
            {
                this.bateria.setCargaMaxima(Convert.ToInt32(bateria.getCargaMaxima() * 0.8));
                if (this.bateria.getCargaActual() > this.bateria.getCargaMaxima())
                {
                    this.bateria.setCargaActual(this.bateria.getCargaMaxima());
                }
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
            Console.WriteLine("carga maxima: " + bateria.getCargaMaxima() + " mAh");
            Console.WriteLine("carga actual: " + bateria.getCargaActual() + " mAh");
            Console.WriteLine("---------------------------------------------------------");

        }
    }

}
