// Gastón Camú, Alicia Nazar

/* Introduccion
 * En este apartado realizamos lo siguiente:

 * Creacion de la clase cuartel.
 * Creacion del operador permitiendo al usuario que decida cuantos y de que tipo de operador desea crear.
 * Metodo para mostrar los detalles de los atributos que contiene cada uno de los operadores.
 * Metodo para mostrar el estado de cada uno de los operadores.
 * Metodo TotalRecall.
 * Metodo para enviar a los operadores a mantenimiento.
 * Metodo para cambiar el estado de todos los operadores a STANDBY.
 * Metodo para mostrar el estado de los operadores en cierta localizacion.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador;

namespace TP_Integrador
{
    public class Cuartel
    {

        public List<Operador> operadores = new List<Operador>();

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
            // Esto va implementado en un menu que no hicimos, esto fue creado a manera de testeo.
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
                    operador = new UAV(idOperador, this.coordX, this.coordY, (int)BateriaOperadores.UAV, (int)CargaFisicaOperadores.UAV);

                }
                else if (seleccionUsuario == 2)
                {
                    operador = new K9(idOperador, this.coordX, this.coordY, (int)BateriaOperadores.K9, (int)CargaFisicaOperadores.K9);
                }                                               
                else if (seleccionUsuario == 3)                 
                {                                               
                    operador = new M8(idOperador, this.coordX, this.coordY, (int) BateriaOperadores.M8, (int)CargaFisicaOperadores.M8);                        
                }
                else
                {
                    Console.WriteLine("opcion incorrecta");
                }
                operadores.Add(operador);
            }
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

        public void TotalRecall(Mapa mapa)
        {
            foreach (var operador in operadores)
            {
                if (operador.getEstado() != Estado.EnEspera.ToString())
                {
                    operador.Mover(this.coordX, this.coordY, mapa);
                }
            }
        }

        public void EnviarOperadoresAMantenimiento(Mapa mapa)
        {
            foreach (var operador in operadores)
            {
                if (operador.getEstadoDañado() && operador.getEstado() != Estado.EnEspera.ToString())
                {
                    operador.Mover(this.coordX, this.coordY, mapa);
                    operador.ResetearValoresOriginales();
                }
            }
        }
        public void CambiarEstadoOperador()
        {
            foreach (var operador in operadores)
            {
                operador.setEstado((Estado.EnEspera).ToString());
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
