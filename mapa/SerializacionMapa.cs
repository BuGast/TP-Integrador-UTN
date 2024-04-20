// Gastón Camú, Alicia Nazar

/* Introduccion
 * En este apartado realizamos lo siguiente:
 * Creacion de la clase SerializacionMapa:
    * Esta clase la utilizamos para serializar y deserializar el mapa.
    * 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using TP_Integrador;

namespace TP_Integrador
{
    [Serializable]
    public class SerializacionMapa
    {
        [JsonPropertyName("TamanioMapaKm2")]
        public int TamanioMapaKm2 { get; set; }

        [JsonPropertyName("Terrenos")]
        public TiposZonas[,] Terrenos { get; set; }
        [JsonPropertyName("Operadores")]
        public List<Operador> Operadores { get; set; }

        [JsonConstructor]
        public SerializacionMapa(int tamanioMapaKm2, TiposZonas[,] terrenos, List<Operador> operadores)
        {
            TamanioMapaKm2 = tamanioMapaKm2;
            Terrenos = terrenos;
            Operadores = operadores;
        }
        public Mapa DeserializarMapa()
        {
            Mapa mapa = new Mapa();
            mapa.setTamanioMapaKm2(TamanioMapaKm2);
            mapa.setTerrenos(Terrenos);
            mapa.setOperadores(Operadores);
            return mapa;
        }

    }

}