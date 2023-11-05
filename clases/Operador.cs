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
        int cargaActual;
        int velocidadOptima;
        Localizacion localizacionBase;
        Localizacion localizacionActual;

        public abstract void Mover();
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
