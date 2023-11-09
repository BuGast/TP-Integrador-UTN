using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador
{
    public abstract class Operador
    {
        string id;
        Bateria bateria;
        string estado;
        int velocidadOptima;
        int[,] coordActual = new int[13, 13];
        //Localizacion localizacionBase;  //creo que no deberíamos almacenar en cada operador la ubicación del cuartel
        //Localizacion localizacionActual;

        public Operador(string id, Bateria bateria,string estado,int velocidadOptima, int[,] coordActual)
        {
            this.id = id;
            this.bateria = bateria;
            this.estado = estado;
            this.velocidadOptima = velocidadOptima;
            this.coordActual=coordActual;
        }

        public abstract void Mover(int[,] coordDeDestino);
        public void VerificarProximidadConOperador();
        public void VerificarEstado();
        public void ComprobarBateriaActual();
        public void DisminuirBateriaActual();
        public void TransferirCargaBateria();
        public void TransferirCargaFisica();
        public abstract void VolverAlCuartel();
        public void CargarBateria();
    }

}
