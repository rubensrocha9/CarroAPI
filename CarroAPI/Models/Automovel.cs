using System.Text.Json.Serialization;

namespace CarroAPI.Models
{
    public class Automovel
    {
        [JsonPropertyOrder(1)]
        [JsonPropertyName("Marca")]
        public string MarcaDoAutomovel { get; set; }
        [JsonPropertyOrder(2)]
        [JsonPropertyName("Modelo")]
        public string Modelo { get; set; }
        [JsonPropertyOrder(3)]
        [JsonPropertyName("Ano")]
        public int Ano { get; set; }
    }
}
