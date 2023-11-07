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
        //Localizacion localizacionBase;  //creo que no deberíamos almacenar en cada operador la ubicación del cuartel
        Localizacion localizacionActual;

        public Operador(string id, Bateria bateria,string estado,int velocidadOptima, Localizacion localizacionActual)
        {
            this.id = id;
            this.bateria = bateria;
            this.estado = estado;
            this.velocidadOptima = velocidadOptima;
            this.localizacionActual = localizacionActual;
        }

        public abstract void Mover(Localizacion ubicacionDeDestino);
        public abstract void VerificarProximidadConOperador();
        public abstract void VerificarEstado();
        public abstract void ComprobarBateriaActual();
        public abstract void DisminuirBateriaActual();
        public abstract void TransferirCargaBateria();
        public abstract void TransferirCargaFisica();
        public abstract void VolverAlCuartel();
        public abstract void CargarBateria();
    }

}
