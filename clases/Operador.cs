using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador
{
    public abstract class Operador
    {

        public string id { get; set; }
        public Bateria bateria { get; set; }
        public string estado { get; set; }
        public int cargaMaxima { get; set; }
        public int cargaActual { get; set; }
        public int velocidadOptima { get; set; }
        public int[,] coordActual { get; set; }

        public Operador()
        {
            this.id = "0";
            this.bateria = new Bateria();
            this.estado = Estado.EnEspera.ToString();
            this.cargaMaxima = 0;
            this.cargaActual = 0;
            this.velocidadOptima = 1;
            this.coordActual= new int[1, 1];   
            //this.coordActual= Coordenada[0,0];
        }


        //public struct Coordenada
        //{
        //    public int X { get; set; }
        //    public int Y { get; set; }

        //    public Coordenada(int x, int y)
        //    {
        //        X = x;
        //        Y = y;
        //    }
        //}
        public void ComprobarBateriaActual()
        {
            Console.WriteLine("carga maxima: " + bateria.MostrarCargaMaxima());
            Console.WriteLine("carga actual: " + bateria.MostrarCargaActual());
        }
        public void TransferirCargaBateria(Operador operador1, Operador operador2, int carga)
        {
            operador1.bateria.DescargarBateria(carga);
            operador2.bateria.RecargarBateria(carga);
        }
        public void TransferirCargaFisica(Operador operador1, Operador operador2, int carga)
        {
            if (operador2.cargaMaxima >= operador1.cargaMaxima) 
            {
                operador2.cargaActual = operador1.cargaActual;
                operador1.cargaActual = 0;
            }
            else
            {
                Console.WriteLine("error el operador no puede levantar la carga");
            }
        }
        public void CargarBateria(Operador operador)
        {
            operador.bateria.RecargarBateria((bateria.MostrarCargaMaxima() - bateria.MostrarCargaActual()));
        }

        public void VerificarProximidadConOperador()
        {

        }
        public void VerificarEstado()
        {
            //este método se fija si está en espera, disponible, etc
        }
        public void CambiarPosicionACuartel((int x, int y) coordenadasCuartel)
        {
            this.coordActual = new int[,] { { coordenadasCuartel.x, coordenadasCuartel.y } };
        }

        public abstract void Mover(int[,] coordDeDestino, int[,] coordMapa);
    }

}
