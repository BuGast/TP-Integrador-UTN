﻿// Gastón Camú, Alicia Nazar

/* Introduccion
 * En este apartado realizamos lo siguiente:
 * Creacion de la clase GuardarYCargarMapa:
     * Esta clase es fundamental para el manejo de carpetas y archivos del proceso de serializacion del mapa.
     * Es la encargada de crear los directorios y asignar los archivos.
     * Tambien se encarga del manejo de algunas excepciones a la hora de trabajar directorios.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_Integrador
{
    public class GuardarYCargarMapa
    {
        private const string MapasGuardados = "MapasGuardados";
        public void GuardarMapa()
        {
            bool sinGuardar = true;
            while (sinGuardar)
            {
                try
                {
                    Console.WriteLine("Ingresar el nombre del mapa: ");
                    string nombreMapa = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nombreMapa))
                    {
                        Console.WriteLine("Error! Ingrese nuevamente el nombre");
                    }
                    else
                    {
                        Directory.CreateDirectory(MapasGuardados);
                        string filePath = Path.Combine(MapasGuardados, $"{nombreMapa}.json");
                        Mapa mapa = new Mapa();
                        string mapaAGuardar = mapa.SerializarMapa();
                        File.WriteAllText(filePath, mapaAGuardar);
                        Console.WriteLine($"El mapa '{nombreMapa}' se guardó en '{filePath}'.");
                        sinGuardar = false;
                    }
                }
                catch (IOException ioException)
                {
                    Console.WriteLine($"Error de E/S: {ioException.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error inesperado: {e.Message}");
                }
            }
        }
    }
}
