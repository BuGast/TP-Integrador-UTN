using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador
{
    internal abstract class Operador
    {
        string id;
        Bateria bateria;
        string estado;
        int cargaActual;
        int velocidadOptima;
        internal Localizacion localizacionBase;
        Localizacion localizacion;

        void Mover()
        {

        }
        void VerificarProximidadConOperador() { 
            
        }

        void VerificarEstado() { 
            
        }

        void ComprobarBateriaActual()
        {

        }
        void DisminuirBateriaActual()
        {

        }
        void TransferirCargaBateria()
        {

        }
        void TransferirCargaFisica()
        {

        }
        void VolverAlCuartel()
        {

        } 
        void CargarBateria()
        {

        }
    }

}
