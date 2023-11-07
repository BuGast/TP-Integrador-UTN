using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador.clases;

namespace TP_Integrador
{
    internal class Cuartel
    {
        Localizacion localizacion = new Localizacion();
        string[,] mapa;

        int operadoresActivos = 0;
        int operadoresInactivos = 0;

        public Cuartel()
        {
            mapa = localizacion.ObtenerMapa();
        }

        public void EstablecerCuartel()
        {
            localizacion.ActualizarPosicion(0, 0, "Cuartel");
        }               

        public void CantidadOperadoresActivos()
        {
            Console.WriteLine($"Cantidad de operadores activados: {operadoresActivos} operadores");
        }

        public void CantidadOperadoresInactivos()
        {
            Console.WriteLine($"Cantidad de operadores en STANDBY: {operadoresInactivos} operadores");
        }

        public void CantidadDeOperadoresTotales()
        {
            int total = operadoresActivos + operadoresInactivos;
            Console.WriteLine($"Actualmente hay {total} operadores creados.");
        }

        public void AgregarOperador()
        {
            operadoresActivos++;
        }

        public void EliminarOperador()
        {
            operadoresActivos--;
        }

        public void EstadoDelOperador()
        {
            
        }

        public void CambiarEstadoOperador()
        {

        }
        
        public void EnviarOperadorALocalizacion()
        {

        }

        public void TotalRecall()
        {

        }
    }
}
