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
        // public Dictionary<string, string[]> listaOperadores = new Dictionary<string, string[]>();
        //Localizacion localizacion = new Localizacion();
        

        public List<Operador> operadores = new List<Operador>();
        public List<Localizacion> Localizaciones = new List<Localizacion>();

        public void CantidadOperadoresActivos()
        {
            Cuartel cuartel = new Cuartel();
            int cantidadOperadores = ObtenerCantidadOperadoresActivos(cuartel);
            Console.WriteLine($"Cantidad de operadores activados: {cantidadOperadores}");
        }

        public int ObtenerCantidadOperadoresActivos(Cuartel cuartel)
        {
            return cuartel.operadores.Count;
        }

        public void AgregarOperador(Operador operador)
        {
            operadores.Add(operador);
        }

        public void EliminarOperador(Operador operador)
        {
            operadores.Remove(operador);
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
