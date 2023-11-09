using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador
{
    public class Bateria
    {

        protected int cargaMaxima;
        protected int cargaActual;

        public void CargarCargaMaxima(int cargaM)
        {
            this.cargaMaxima = cargaM;
            this.cargaActual = cargaMaxima;
        }
        public void RecargarBateria(int carga)
        {
            if (carga > 0)
            {
                if ((carga + this.cargaActual) <= this.cargaMaxima)
                {
                    this.cargaActual += carga;
                    Console.WriteLine("Se recargo la bateria");
                }
                else
                {
                    Console.WriteLine("La energia excede la bateria maxima");
                }
            }
        }
        public void DescargarBateria(int carga)
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
        }

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
