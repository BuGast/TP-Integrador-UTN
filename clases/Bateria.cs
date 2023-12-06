using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador
{
    public class Bateria
    {

        private int cargaMaxima;
        private int cargaActual;

        public void CargarCargaMaxima(int cargaM)
        {
            this.cargaMaxima = cargaM;
            this.cargaActual = cargaMaxima;
        }
        public void CargaYDescargaBateria(int carga, Bateria bateria2)
        {
            if (carga > 0 && carga<= bateria2.cargaActual)
            {
                if ((carga + this.cargaActual) <= this.cargaMaxima)
                {
                    this.cargaActual += carga;
                    bateria2.cargaActual -= carga;   
                }
                else
                {
                    bateria2.cargaActual -= this.cargaActual - this.cargaMaxima;
                    this.cargaActual = this.cargaMaxima;
                }
            }
            Console.WriteLine("Se actualizaron los valores de las baterías");
        }


/*        public void DescargarBateria(int carga)
        {
            if (carga > 0)
            {
                if (carga <= this.cargaActual)
                {
                    this.cargaActual += carga;
                    Console.WriteLine("Se descargo la bateria");
                }
                else
                {
                    Console.WriteLine("Error la descarga es mayor a la carga actual de la bateria");
                }
            }
        }*/

        public int MostrarCargaMaxima()
        {
            return cargaMaxima;
        }
        public int MostrarCargaActual()
        {
            return cargaActual;
        }


    }
}
