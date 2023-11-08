using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador.clases;

namespace TP_Integrador
{
    internal class Cuartel
    {   GeneradorOperadores GeneradorOperadores { get; set; }
        Localizacion localizacion = new Localizacion();
        string[,] mapa;

        int operadoresCreados = 0;
        int operadoresActivos = 0;
        int operadoresInactivos = 0;

        private Dictionary<int, K9> operadoresK9 = new Dictionary<int, K9>();
        private Dictionary<int, UAV> operadoresUAV = new Dictionary<int, UAV>();
        private Dictionary<int, M8> operadoresM8 = new Dictionary<int, M8>();

        private GeneradorOperadores generador = new GeneradorOperadores();

        public Cuartel()
        {
            mapa = localizacion.ObtenerMapa();
        }

        public void EstablecerCuartel()
        {
            localizacion.ActualizarPosicion(0, 0, "Cuartel");
        }

        public void CrearModeloK9()
        {
            AgregarOperador();
            GeneradorOperadores.CrearOperadorK9();
        }

        public void CrearModeloUAV()
        {
            AgregarOperador();
            GeneradorOperadores.CrearOperadorUAV();
        }

        public void CrearModeloM8()
        {
            AgregarOperador();
            GeneradorOperadores.CrearOperadorM8();
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
            operadoresCreados++;
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
