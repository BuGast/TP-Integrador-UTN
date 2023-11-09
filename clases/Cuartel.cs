using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador.clases;
using static TP_Integrador.clases.GeneradorDeMapa;

namespace TP_Integrador
{
    public class Cuartel
    {

        List<Operador> operadores = new List<Operador>();
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

                if (seleccionUsuario == 1)
                {
                    Operador operador = new UAV();
                    operador.id = i.ToString();
                    operadores.Add(operador);
                    operadoresCreados++;
                    id++;
                }
                else if (seleccionUsuario == 2)
                {
                    Operador operador = new K9();
                    operador.id = i.ToString();
                    operadores.Add(operador);
                    operadoresCreados++;
                    id++;
                }
                else if (seleccionUsuario == 3)
                {
                    Operador operador = new M8();
                    operador.id = i.ToString();
                    operadores.Add(operador);
                    operadoresCreados++;
                    id++;
                }
                else
                {
                    Console.WriteLine("opcion incorrecta");
                }
            }
            foreach (var operador in operadores)
            {
                MostrarDetallesOperador(operador);
            }
        }

        public void EliminarOperador()
        {
            Console.WriteLine("¿Qué tipo de operador desea eliminar?");
            Console.WriteLine("1: para UAV");
            Console.WriteLine("2: para K9");
            Console.WriteLine("3: para M8");
            int seleccionUsuario = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Ingrese el ID del operador a eliminar: ");
            string idAEliminar = Console.ReadLine();

            switch (seleccionUsuario)
            {
                case 1:
                    EliminarOperadorTipo(idAEliminar, typeof(UAV));
                    break;
                case 2:
                    EliminarOperadorTipo(idAEliminar, typeof(K9));
                    break;
                case 3:
                    EliminarOperadorTipo(idAEliminar, typeof(M8));
                    break;
                default:
                    Console.WriteLine("Opción incorrecta.");
                    break;
            }
        }

        public void EliminarOperadorTipo(string idAEliminar, Type tipoOperador)
        {
            // Utilice una expresion Lambda, pero no tengo mucha practica con ella y no se si su funcionalidad esta bien implementada, necesita verificacion
            var operadorAEliminar = operadores.FirstOrDefault(operador => operador.id == idAEliminar && operador.GetType() == tipoOperador);

            if (operadorAEliminar != null)
            {
                operadores.Remove(operadorAEliminar);

                // Reducir el ID y reorganizar los ID restantes
                foreach (var operador in operadores)
                {
                    if (int.Parse(operador.id) > int.Parse(idAEliminar))
                    {
                        int nuevoID = int.Parse(operador.id) - 1;
                        operador.id = nuevoID.ToString();
                    }
                }

                Console.WriteLine($"Operador {tipoOperador.Name} con ID {idAEliminar} eliminado con éxito.");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún operador {tipoOperador.Name} con ese ID.");
            }
        }

        public void MostrarDetallesOperador(Operador operador)
        {
            Console.WriteLine(operador.GetType().Name);
            Console.WriteLine("id: " + operador.id);
            Console.WriteLine("estado: " + operador.estado);
            Console.WriteLine("cargaMaxima: " + operador.cargaMaxima + " kg");
            Console.WriteLine("velocidad optima: " + operador.velocidadOptima);
            Console.WriteLine("coordenada actual: " + operador.coordActual[0, 0]);
            Console.WriteLine("");
            Console.WriteLine("BATERIA");
            Console.WriteLine("carga maxima: " + operador.bateria.MostrarCargaMaxima() + " mAh");
            Console.WriteLine("carga actual: " + operador.bateria.MostrarCargaActual() + " mAh");
            Console.WriteLine("---------------------------------------------------------");

        }

        public void MostrarDetallesOperadoresCreados()
        {
            foreach (var operador in operadores)
            {
                MostrarDetallesOperador(operador);
            }
        }

        public void CantidadOperadoresActivos()
        {
/*            Console.WriteLine($"Cantidad de operadores activos: {operadoresActivos} operadores");*/
        }

        public void CantidadOperadoresInactivos()
        {
/*            Console.WriteLine($"Cantidad de operadores en STANDBY: {operadoresInactivos} operadores");*/
        }

        public void CantidadDeOperadoresTotales()
        {
/*            int total = operadoresActivos + operadoresInactivos;
            Console.WriteLine($"Actualmente hay {total} operadores en servicio.");*/
        }

        public void CambiarEstadoOperador()
        {

        }

        public void EnviarOperadorALocalizacion()
        {

        }

        public void TotalRecall()
        {
            // Aqui deberia poder acceder a las coordenadas del cuartel
            var coordenadasCuartel = generador.coordenadasUbicaciones[Ubicaciones.Cuartel];

            // Y con un foreach itero en todos los operadores, y actualizo su coordenada actual por las coordenadas del cuartel
            foreach (var operador in operadores)
            {
                operador.CambiarPosicionACuartel(coordenadasCuartel);
            }
        }
    }
}
