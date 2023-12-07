// Gastón Camú, Alicia Nazar

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador.clases
{
    public class Mapa
    {
        List<Cuartel> listaDeCuarteles = new List<Cuartel>();

        private const int TamanioMapaKm2 = 100;
        private const int MaxCuarteles = 3;

        private TiposZonas[,] terrenos;
        private Random random;

        public int getTamanioMapaKm2() { return TamanioMapaKm2; }

        // Decidimos que solo en estas localizaciones se puedan crear cuarteles
        private List<TiposZonas> LocalizacionesAptasParaCuartel = new List<TiposZonas>
        {
            TiposZonas.TerrenoBaldio,
            TiposZonas.Planicie,
            TiposZonas.Bosque,
            TiposZonas.SectorUrbano
        };

        public Mapa()
        {
            terrenos = new TiposZonas[TamanioMapaKm2, TamanioMapaKm2];
            random = new Random();

            GenerarMapa();
            GenerarCuarteles();
        }

        public TiposZonas[,] getTerrenos() { return  terrenos; }
        private void GenerarMapa()
        {
            for (int x = 0; x < TamanioMapaKm2; x++)
            {
                for (int y = 0; y < TamanioMapaKm2; y++)
                {
                    terrenos[x, y] = GenerarTerrenoAleatorio();
                }
            }
        }

        private TiposZonas GenerarTerrenoAleatorio()
        {
            double probabilidad = random.NextDouble();

            if (probabilidad < 0.1)
                return TiposZonas.VertederoElectronico;
            else if (probabilidad < 0.2)
                return TiposZonas.SitioReciclaje;
            else if (probabilidad < 0.3)
                return TiposZonas.Lago;
            else if (probabilidad < 0.4)
                return TiposZonas.Bosque;
            else if (probabilidad < 0.5)
                return TiposZonas.SectorUrbano;
            else if (probabilidad < 0.7)
                return TiposZonas.Planicie;
            else
                return TiposZonas.TerrenoBaldio;
        }
        private void GenerarCuarteles()
        {
            int cuartelesGenerados = 0;

            while (cuartelesGenerados < MaxCuarteles)
            {
                int x = random.Next(TamanioMapaKm2);
                int y = random.Next(TamanioMapaKm2);

                if (LocalizacionesAptasParaCuartel.Contains(terrenos[x,y]))
                {
                    terrenos[x, y] = TiposZonas.Cuartel;
                    cuartelesGenerados++;
                    listaDeCuarteles.Add(new Cuartel(cuartelesGenerados.ToString(),x, y));
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

        static (int, int)[] BuscarZonaEnElMapa(TiposZonas[,] terrenos, TiposZonas zonaBuscada)
        {
            int filas = terrenos.GetLength(0);
            int columnas = terrenos.GetLength(1);
            var posiciones = Enumerable.Range(0, filas)
                .SelectMany(fila => Enumerable.Range(0, columnas).Select(columna => (fila, columna)))
                .Where(p => terrenos[p.Item1, p.Item2] == zonaBuscada)
                .ToArray();

            return posiciones;
        }




    }

}