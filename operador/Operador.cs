// Gastón Camú, Alicia Nazar

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador.enums;
using TP_Integrador.mapa;
using TP_Integrador.simulador_daño;

namespace TP_Integrador.operador
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
        bool dañado;
        SimuladorDeDaños simuladorDeDaños = new SimuladorDeDaños();
        public Operador(string id, int coordX, int coordY, int cargaBateria, int cargaFisica)
        {
            this.id = id;
            bateria = new Bateria(cargaBateria, simuladorDeDaños);
            estado = Estado.EnEspera.ToString();
            cargaFisicaMaxima = cargaFisica;
            velocidadOptima = 1;
            this.coordX = coordX;
            this.coordY = coordY;
        }

        public string getEstado() { return estado; }
        public string getId() { return id; }
        public int getCoordX() { return coordX; }
        public int getCoordY() { return coordY; }
        public int getVelocidadOptima() { return velocidadOptima; }
        public bool getEstadoDañado() { return dañado; }
        public void setVelocidadOptima(int velocidadOptima) { this.velocidadOptima = velocidadOptima; }
        public void setEstadoDañado(bool estadoDañado) { dañado = estadoDañado; }
        public void setEstado(string Estado) { estado = Estado; }
        public void ComprobarBateriaActual()
        {
            Console.WriteLine("carga maxima: " + bateria.getCargaMaxima());
            Console.WriteLine("carga actual: " + bateria.getCargaActual());
        }

        public void TransferirCargaFisica(Operador operador2, int carga)
        {
            if (simuladorDeDaños.ServoAtascado == false)
            {
                if (operador2.cargaFisicaMaxima >= cargaFisicaMaxima)
                {
                    operador2.cargaFisicaActual = cargaFisicaActual;
                    cargaFisicaActual = 0;
                }
                else
                {
                    Console.WriteLine("error el operador no puede levantar la carga");
                }
            }
        }

        public bool VerificarProximidadConOperador(Operador operador2)
        {
            bool operadorCerca = false;
            if (operador2.coordX == coordX && operador2.coordY == coordY)
            {
                operadorCerca = true;
            }
            return operadorCerca;
        }

        public void TransferirBateriaDesdeOtroOperador(Operador operador2)
        {
            bool operadorCerca = VerificarProximidadConOperador(operador2);
            if (operadorCerca == true && operador2.estado == Estado.EnEspera.ToString())
            {
                bool cargaValida;
                int carga = 0;
                do
                {
                    Console.WriteLine("Cuánta carga desea suministrar al operador?");
                    carga = Convert.ToInt32(Console.ReadLine());
                    cargaValida = ValidarCargaSinExceso(carga, operador2.bateria);
                }
                while (!cargaValida);

                bateria.CargaYDescargaBateria(carga, operador2.bateria);
            }
        }
        public bool ValidarCargaSinExceso(int carga, Bateria bateria)
        {
            bool cargaValida = false;
            if (carga < Convert.ToInt32(bateria.getCargaActual))
            {
                cargaValida = true;
            }
            return cargaValida;
        }

        public void Mover(int x, int y, Mapa mapa)
        {
            int xActual = coordX; // Obtener la posición actual del operador
            int yActual = coordY;
            int xDestino = x; // Obtener la coordenada de destino
            int yDestino = y;
            int detener = 0;
            // Verifico si la coordenada de destino es válida en relación con la posición actual del operador
            if (xDestino >= 0 && xDestino <= mapa.getTamanioMapaKm2() && //me fijo que xDestino sea >=0 y que sea < que el valor máximo de la coord en X del mapa
                yDestino >= 0 && yDestino <= mapa.getTamanioMapaKm2())
            {
                int contadorBateria = 0;
                while ((xActual != xDestino || yActual != yDestino) && detener == 0 && Convert.ToInt32(bateria.getCargaActual) > 0)
                {
                    if (xActual < xDestino) //podría haberse movido de muchas formas, pero decidimos que esta sea por defecto
                    {
                        xActual++;
                        contadorBateria++;
                        analizarSituacionDelOperador(xActual, yActual, mapa);
                        DisminucionDeBateria();
                        contadorBateria = ReduccionDeVelocidad(contadorBateria);
                    }
                    else if (xActual > xDestino)
                    {
                        xActual--;
                        contadorBateria++;
                        analizarSituacionDelOperador(xActual, yActual, mapa);
                        DisminucionDeBateria();
                    }

                    if (yActual < yDestino)
                    {
                        yActual++;
                        contadorBateria++;
                        analizarSituacionDelOperador(xActual, yActual, mapa);
                        DisminucionDeBateria();
                    }
                    else if (yActual > yDestino)
                    {
                        yActual--;
                        contadorBateria++;
                        analizarSituacionDelOperador(xActual, yActual, mapa);
                        DisminucionDeBateria();

                    }
                }
                // Actualizo la coordenada actual del operador
                coordX = xActual;
                coordY = yActual;
            }
            else
            {
                Console.WriteLine("La coordenada de destino no es válida");
            }
        }

        // por cada movimiento la bateria disminuye en 1 mAh en situaciones normales
        public void DisminucionDeBateria()
        {
            if (simuladorDeDaños.BateriaPerforada == true)
            {
                bateria.setCargaActual(bateria.getCargaActual() - 1 * 500);
            }
            else
            {
                bateria.setCargaActual(bateria.getCargaActual() - 1);
            }
        }

        public int ReduccionDeVelocidad(int contadorBateria)
        {
            int valor = bateria.getCargaMaxima() / 10;
            if (contadorBateria == valor)
            {
                contadorBateria = 0;
                velocidadOptima = Convert.ToInt32(velocidadOptima * 0.95);
            }
            return contadorBateria;
        }

        public int analizarSituacionDelOperador(int xActual, int yActual, Mapa mapa)
        {
            Random randy = new Random();
            int detener = 0;
            TiposZonas[,] terreno = mapa.getTerrenos();
            TiposZonas terrenoActual = terreno[xActual, yActual];
            List<TiposZonas> terrenosComunes = mapa.getTerrenosComunes();
            int probabilidadDaño = randy.Next(0, 101);
            if ((GetType().Name == "K9" || GetType().Name == "M8") && terrenoActual == TiposZonas.Lago)
            {
                detener = 1;
            }
            else if (terrenoActual == TiposZonas.Vertedero && probabilidadDaño <= 5)
            {
                int probabilidadSimuladorDaño = randy.Next(0, 101);
                if (probabilidadSimuladorDaño <= 20)
                {
                    simuladorDeDaños.SimularBateriaPerforada(this);
                }
                else if (probabilidadSimuladorDaño <= 40)
                {
                    simuladorDeDaños.SimularServoAtascado(this);
                }
                else if (probabilidadSimuladorDaño <= 60)
                {
                    simuladorDeDaños.SimularMotorComprometido(this);
                }
                else if (probabilidadSimuladorDaño <= 80)
                {
                    simuladorDeDaños.SimularPuertoBateriaDesconectado(this);
                }
                else
                {
                    simuladorDeDaños.SimularPinturaRayada(this);
                }
            }
            else if (terrenoActual == TiposZonas.VertederoElectronico)
            {
                bateria.setCargaMaxima(Convert.ToInt32(bateria.getCargaMaxima() * 0.8));
                if (bateria.getCargaActual() > bateria.getCargaMaxima())
                {
                    bateria.setCargaActual(bateria.getCargaMaxima());
                }
            }
            return detener;
        }

        public void ResetearValoresOriginales()
        {
            int cargaFisica = cargaFisicaActual;
            int cargaBateria = bateria.getCargaActual();
            if (GetType().Name == "UAV") { cargaFisica = (int)CargaFisicaOperadores.UAV; cargaBateria = (int)BateriaOperadores.UAV; }
            if (GetType().Name == "M8") { cargaFisica = (int)CargaFisicaOperadores.M8; cargaBateria = (int)BateriaOperadores.M8; }
            if (GetType().Name == "K9") { cargaFisica = (int)CargaFisicaOperadores.K9; cargaBateria = (int)BateriaOperadores.K9; }


            SimuladorDeDaños simuladorDeDaños = new SimuladorDeDaños();
            bateria = new Bateria(cargaBateria, simuladorDeDaños);
            estado = Estado.EnEspera.ToString();
            cargaFisicaMaxima = cargaFisica;
            velocidadOptima = 1;
        }
        public void RemplazarBateria()
        {
            if (GetType().Name == "UAV") { bateria = new Bateria((int)BateriaOperadores.UAV, simuladorDeDaños); }
            else if (GetType().Name == "M8") { bateria = new Bateria((int)BateriaOperadores.M8, simuladorDeDaños); }
            else { bateria = new Bateria((int)BateriaOperadores.K9, simuladorDeDaños); }
        }


        public void RecogerCargaEnVertedero(Mapa mapa)
        {
            (int, int)[] posicionesEncontradas = mapa.BuscarZonaEnElMapa(TiposZonas.Vertedero);
            (int, int) posicionMasCercana = SeleccionarPosicionMasCercana(coordX, coordY, posicionesEncontradas);
            Mover(posicionMasCercana.Item1, posicionMasCercana.Item2, mapa);
            if (posicionMasCercana.Item1 == coordX && posicionMasCercana.Item2 == coordY)
            {
                cargaFisicaActual = cargaFisicaMaxima;
            }

        }
        public (int, int) SeleccionarPosicionMasCercana(int opeCoordX, int opeCoordY, (int, int)[] posicionesEncontradas)
        {
            int puntajeMasCerca = 9999999;
            (int, int) posicionMasCercana = (0, 0);
            foreach (var posicion in posicionesEncontradas)
            {
                int x = posicion.Item1;
                int y = posicion.Item2;
                int puntajeDeCercania = Math.Abs(x - opeCoordX) + Math.Abs(y - opeCoordY);
                if (puntajeDeCercania < puntajeMasCerca)
                {
                    puntajeMasCerca = puntajeDeCercania;
                    posicionMasCercana = (x, y);
                }

            }
            return posicionMasCercana;
        }

        public void MostrarDetallesOperador()
        {
            Console.WriteLine(GetType().Name);
            Console.WriteLine("id: " + id);
            Console.WriteLine("estado: " + estado);
            Console.WriteLine("cargaMaxima: " + cargaFisicaMaxima + " kg");
            Console.WriteLine("velocidad optima: " + velocidadOptima);
            Console.WriteLine("coordenada actual: (" + coordX + " - " + coordY + ")");
            Console.WriteLine("");
            Console.WriteLine("BATERIA");
            Console.WriteLine("carga maxima: " + bateria.getCargaMaxima() + " mAh");
            Console.WriteLine("carga actual: " + bateria.getCargaActual() + " mAh");
            Console.WriteLine("---------------------------------------------------------");

        }
    }

}
