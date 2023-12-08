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


        [JsonConstructor]
        public SerializacionMapa(int tamanioMapaKm2)
        {
            TamanioMapaKm2 = tamanioMapaKm2;
        }

    }

}