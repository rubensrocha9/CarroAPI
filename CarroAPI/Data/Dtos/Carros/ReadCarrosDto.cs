using CarroAPI.Models;
using System.Text.Json.Serialization;

namespace CarroAPI.Data.Dtos.Carros
{
    public class ReadCarrosDto : Automovel
    {
        public int Id { get; set; }

        [JsonPropertyOrder(5)]
        [JsonPropertyName("Cor")]
        public string CorDoCarro { get; set; }

        [JsonPropertyOrder(4)]
        [JsonPropertyName("Portas")]
        public int QntdPortas { get; set; }

        [JsonPropertyOrder(6)]
        [JsonPropertyName("Opcionais")]
        public object Adicionais { get; set; }
    }
}
