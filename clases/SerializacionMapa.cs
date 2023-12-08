using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TP_Integrador.clases
{
    [Serializable]
    public class SerializacionMapa
    {
        [JsonPropertyName("TamanioMapaKm2")]
        public int TamanioMapaKm2 { get; set; }

        [JsonPropertyName("Terrenos")]
        public TiposZonas[,] Terrenos { get; set; }

        [JsonConstructor]
        public SerializacionMapa(int tamanioMapaKm2, TiposZonas[,] terrenos)
        {
            TamanioMapaKm2 = tamanioMapaKm2;
            Terrenos = terrenos;
        }
        public Mapa DeserializarMapa()
        {
            Mapa mapa = new Mapa();
            mapa.setTamanioMapaKm2(TamanioMapaKm2);
            mapa.setTerrenos(Terrenos);
            return mapa;
        }

    }

}