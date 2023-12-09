// Gastón Camú, Alicia Nazar

/* Introduccion
 * En este apartado realizamos lo siguiente:
 * Creacion de la clase mapa
 * Metodo para agregar los operadores de cada respectivo cuartel en el mapa.
 * Metodo para generar mapa.
 * Metodo para mostrar mapa.
 * Metodo para obtener el simbolo de cada terreno.
 * Metodo para buscar una zona en el mapa y retorna dicha o dichas ubicaciones.
 * Metodo para serializar el mapa.
 * Metodo para deserializar el mapa.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TP_Integrador;

namespace TP_Integrador
{
    [Serializable]
    public class Mapa
    {
        private static Random random = new Random();
        List<Cuartel> listaDeCuarteles = new List<Cuartel>();
        List<Operador> listaDeOperadores = new List<Operador>();

        private int TamanioMapaKm2 = 100;
        private int MaxCuarteles = random.Next(1, 4);
        private TiposZonas[,] terrenos;

        // Pensamos en hacer que mapa sea un singleton para asegurarnos que no se creen más instancias 
        private static Mapa _instancia;
        public static Mapa Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new Mapa();
            }
            return _instancia;
        }

        // Decidimos que solo en estas localizaciones se puedan crear cuarteles
        private List<TiposZonas> terrenosComunes = new List<TiposZonas>
        {
            TiposZonas.TerrenoBaldio,
            TiposZonas.Planicie,
            TiposZonas.Bosque,
            TiposZonas.SectorUrbano
        };
        public void setTamanioMapaKm2(int tamanioMapa) { TamanioMapaKm2 = tamanioMapa; }
        public void setTerrenos(TiposZonas[,] terrenos) { this.terrenos = terrenos; }
        public void setOperadores(List<Operador> operadores)
        {
            listaDeOperadores.Clear();
            listaDeOperadores.AddRange(operadores);
        }

        public int getTamanioMapaKm2() { return TamanioMapaKm2; }
        public List<TiposZonas> getTerrenosComunes() { return terrenosComunes; }
        public TiposZonas[,] getTerrenos() { return terrenos; }


        public void AgregarOperadorAlMapa()
        {
            foreach (var cuartel in listaDeCuarteles)
            {
                foreach (var op in cuartel.operadores)
                {
                    listaDeOperadores.Add(op);
                }
            }
        }

        public Mapa()
        {
            terrenos = new TiposZonas[TamanioMapaKm2, TamanioMapaKm2];
            random = new Random();

            GenerarMapa();
            GenerarCuarteles();
        }

        private void GenerarMapa()
        {
            int contadorSitioReciclaje = 0;
            for (int x = 0; x < TamanioMapaKm2; x++)
            {
                for (int y = 0; y < TamanioMapaKm2; y++)
                {
                    terrenos[x, y] = GenerarTerrenoAleatorio(ref contadorSitioReciclaje);
                }
            }
        }

        private TiposZonas GenerarTerrenoAleatorio(ref int contadorSitioReciclaje)
        {
            int maximoSitioReciclaje = random.Next(1, 6);
            //int contadorSitioReciclaje = 0;
            double probabilidad = random.NextDouble();
            TiposZonas zona = TiposZonas.TerrenoBaldio;
            if (probabilidad < 0.1) { zona = TiposZonas.VertederoElectronico; }
            else if (probabilidad < 0.2 && contadorSitioReciclaje < maximoSitioReciclaje)
            {
                zona = TiposZonas.SitioReciclaje;
                contadorSitioReciclaje++;
            }
            else if (probabilidad < 0.3) { zona = TiposZonas.Lago; }
            else if (probabilidad < 0.4) { zona = TiposZonas.Bosque; }
            else if (probabilidad < 0.5) { zona = TiposZonas.SectorUrbano; }
            else if (probabilidad < 0.7) { zona = TiposZonas.Planicie; }
            else { zona = TiposZonas.TerrenoBaldio; }
            return zona;
        }
        private void GenerarCuarteles()
        {
            int cuartelesGenerados = 0;

            while (cuartelesGenerados < MaxCuarteles)
            {
                int x = random.Next(TamanioMapaKm2);
                int y = random.Next(TamanioMapaKm2);

                if (terrenosComunes.Contains(terrenos[x, y]))
                {
                    terrenos[x, y] = TiposZonas.Cuartel;
                    cuartelesGenerados++;
                    listaDeCuarteles.Add(new Cuartel(cuartelesGenerados.ToString(), x, y));
                }
            }
        }

        public void MostrarMapa()
        {
            for (int x = 0; x < TamanioMapaKm2; x++)
            {
                for (int y = 0; y < TamanioMapaKm2; y++)
                {
                    Console.Write(ObtenerSimboloTerreno(terrenos[x, y]) + " ");
                }
                Console.WriteLine();
            }
        }

        private char ObtenerSimboloTerreno(TiposZonas terreno)
        {
            switch (terreno)
            {
                case TiposZonas.TerrenoBaldio:
                    return 'B';
                case TiposZonas.Planicie:
                    return 'P';
                case TiposZonas.Bosque:
                    return 'F';
                case TiposZonas.SectorUrbano:
                    return 'U';
                case TiposZonas.Vertedero:
                    return 'V';
                case TiposZonas.Lago:
                    return 'L';
                case TiposZonas.VertederoElectronico:
                    return 'V';
                case TiposZonas.SitioReciclaje:
                    return 'R';
                case TiposZonas.Cuartel:
                    return 'C';
                default:
                    return ' ';
            }
        }

        public (int, int)[] BuscarZonaEnElMapa(TiposZonas zonaBuscada)
        {
            int filas = terrenos.GetLength(0);
            int columnas = terrenos.GetLength(1);
            var posiciones = Enumerable.Range(0, filas)
                .SelectMany(fila => Enumerable.Range(0, columnas).Select(columna => (fila, columna)))
                .Where(p => terrenos[p.Item1, p.Item2] == zonaBuscada)
                .ToArray();

            return posiciones;
        }


        public string SerializarMapa()
        {
            SerializacionMapa mapaEjemplo = new SerializacionMapa(TamanioMapaKm2, terrenos, listaDeOperadores);
            string jsonString = JsonSerializer.Serialize(mapaEjemplo);
            return jsonString;
        }
        public static Mapa DeserializarDesdeJson(string jsonString)
        {
            SerializacionMapa mapaSerializado = JsonSerializer.Deserialize<SerializacionMapa>(jsonString);
            return mapaSerializado?.DeserializarMapa();
        }



    }

}