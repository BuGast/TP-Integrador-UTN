using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador.clases;
using static TP_Integrador.clases.GeneradorDeMapa;

namespace TP_Integrador
{
    internal class Cuartel
    {
        GeneradorDeMapa generador = new GeneradorDeMapa();

        string[,] mapa;

        int id = 1;
        int operadoresCreados = 0;
        int operadoresActivos = 0;
        int operadoresInactivos = 0;

        private Dictionary<int, K9> operadoresK9 = new Dictionary<int, K9>();
        private Dictionary<int, UAV> operadoresUAV = new Dictionary<int, UAV>();
        private Dictionary<int, M8> operadoresM8 = new Dictionary<int, M8>();

        public Cuartel()
        {
            mapa = generador.ObtenerMapa();
            generador.CrearMapaVacio();
            generador.ActualizarPosicion(generador.coordenadasUbicaciones[Ubicaciones.Cuartel].x, generador.coordenadasUbicaciones[Ubicaciones.Cuartel].y, "Cuartel");
        }


        private void AsignarOperador<T>(Dictionary<int, T> diccionarioOperadores, T nuevoOperador) where T : Operador
        {
            diccionarioOperadores.Add(id, nuevoOperador);
            id++; // Incrementar el ID después de la asignación
        }

        public K9 CrearOperadorK9()
        {
            K9 nuevoOperadorK9 = new K9();
            AsignarOperador(operadoresK9, nuevoOperadorK9);
            operadoresCreados++;
            operadoresActivos++;
            return nuevoOperadorK9;
        }

        public UAV CrearOperadorUAV()
        {
            UAV nuevoOperadorUAV = new UAV();
            AsignarOperador(operadoresUAV, nuevoOperadorUAV);
            operadoresCreados++;
            operadoresActivos++;
            return nuevoOperadorUAV;
        }

        public M8 CrearOperadorM8()
        {
            M8 nuevoOperadorM8 = new M8();
            AsignarOperador(operadoresM8, nuevoOperadorM8);
            operadoresCreados++;
            operadoresActivos++;
            return nuevoOperadorM8;
        }

        public void MostrarDetallesOperador(Operador operador)
        {
            Console.WriteLine($"ID: {operador.ID}");
            Console.WriteLine($"Estado: {operador.Estado}");
            Console.WriteLine($"Batería: {operador.Bateria} mAh");

            // Aca estoy teniendo un problema, cuando lo vean si pueden ayudarme, joya, no puedo acceder a estos atributos del operador creado.
        }

        public void MostrarOperadoresK9()
        {
            foreach (var operador in operadoresK9)
            {
                Console.WriteLine($"ID: {operador.Key}");
                MostrarDetallesOperador(operador.Value);
            }
        }

        public void MostrarOperadoresUAV()
        {
            foreach (var operador in operadoresUAV)
            {
                Console.WriteLine($"ID: {operador.Key}");
                MostrarDetallesOperador(operador.Value);
            }
        }

        public void MostrarOperadoresM8()
        {
            foreach (var operador in operadoresM8)
            {
                Console.WriteLine($"ID: {operador.Key}");
                MostrarDetallesOperador(operador.Value);
            }
        }

        public void MostrarTodosLosOperadores() // Opcion para mostrar todos los diccionarios
        {
            MostrarOperadoresK9();
            MostrarOperadoresUAV();
            MostrarOperadoresM8();
        }

        

        public void CantidadOperadoresActivos()
        {
            Console.WriteLine($"Cantidad de operadores activos: {operadoresActivos} operadores");
        }

        public void CantidadOperadoresInactivos()
        {
            Console.WriteLine($"Cantidad de operadores en STANDBY: {operadoresInactivos} operadores");
        }

        public void CantidadDeOperadoresTotales()
        {
            int total = operadoresActivos + operadoresInactivos;
            Console.WriteLine($"Actualmente hay {total} operadores en servicio.");
        }

        public void AgregarOperador()
        {
            operadoresCreados++;
        }

        public void EliminarOperador()
        {
            operadoresActivos--;
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
