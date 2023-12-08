// Gastón Camú, Alicia Nazar

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador.simulador_daño;

namespace TP_Integrador.operador
{
    public class Bateria
    {

        private int cargaMaxima;
        private int cargaActual;
        private bool bateriaDesconectada;

        public Bateria(int cargaMaxima, SimuladorDeDaños simuladorDeDaños)
        {
            this.cargaMaxima = cargaMaxima;
            cargaActual = this.cargaMaxima;
            bateriaDesconectada = simuladorDeDaños.PuertoBateriaDesconectado;
        }

        public void CargaYDescargaBateria(int carga, Bateria bateria2)
        {
            if (bateriaDesconectada == false)
            {
                if (carga > 0 && carga <= bateria2.cargaActual)
                {
                    if (carga + cargaActual <= cargaMaxima)
                    {
                        cargaActual += carga;
                        bateria2.cargaActual -= carga;
                    }
                    else
                    {
                        bateria2.cargaActual -= cargaActual - cargaMaxima;
                        cargaActual = cargaMaxima;
                    }
                }
                Console.WriteLine("Se actualizaron los valores de las baterías");
            }
        }

        public int getCargaMaxima()
        {
            return cargaMaxima;
        }
        public int getCargaActual()
        {
            return cargaActual;
        }
        public void setCargaMaxima(int cargaMaxima)
        {
            this.cargaMaxima = cargaMaxima;
        }
        public void setCargaActual(int cargaActual)
        {
            this.cargaActual = cargaActual;
        }


    }
}
