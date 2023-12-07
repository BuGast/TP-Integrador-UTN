// Gastón Camú, Alicia Nazar

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador.clases;

namespace TP_Integrador.clases
{
    public class Cuartel
    {

        List<Operador> operadores = new List<Operador>();

        string id;
        int coordX;
        int coordY;

        public Cuartel(string id,int x,int y) 
        {
            this.id = id;
            this.coordX = x;
            this.coordY = y;

        }

        public void CrearOperador()
        {

            Console.WriteLine("¿Que tipo de operador quiere crear?");
            Console.WriteLine("1: para UAV");
            Console.WriteLine("2: para K9");
            Console.WriteLine("3: para M8");
            int seleccionUsuario = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad de operadores a crear: ");
            int cantOperadores = Convert.ToInt16(Console.ReadLine());

            for (int i = 1; i <= cantOperadores; i++)
            {
                string idOperador = "C" + this.id +"-"+ operadores.Count().ToString();
                Operador operador = null;
                if (seleccionUsuario == 1)
                {
                    operador = new UAV(idOperador, this.coordX, this.coordY);

                }
                else if (seleccionUsuario == 2)
                {
                    operador = new K9(idOperador, this.coordX, this.coordY);
                }                                               
                else if (seleccionUsuario == 3)                 
                {                                               
                    operador = new M8(idOperador, this.coordX, this.coordY);                        
                }
                else
                {
                    Console.WriteLine("opcion incorrecta");
                }
                operadores.Add(operador);
            }
/*            foreach (var operador in operadores)
            {
                MostrarDetallesOperador(operador);
            }*/
        }

        public void MostrarDetallesOperadoresCreados()
        {
            foreach (var operador in operadores)
            {
                operador.MostrarDetallesOperador();
            }
        }

        public void MostrarEstadoTodosLosOperadores()
        {
            foreach (var operador in operadores)
            {
                Console.WriteLine("Id: "+operador.getId+": "+operador.getEstado());
            }
        }
        public void MostrarEstadoOperadoresEnCiertaLocalizacion(int x, int y)
        {
            foreach (var operador in operadores)
            {
                if (operador.getCoordX()==x&& operador.getCoordY() == y)
                Console.WriteLine("Id: " + operador.getId + ": " + operador.getEstado());
            }
        }




    }
}
