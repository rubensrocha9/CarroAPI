using System.Text.Json.Serialization;

namespace CarroAPI.Models
{
    public class Carro : Automovel
    {
        [JsonPropertyOrder(-1)]
        public int Id { get; set; }

        [JsonPropertyOrder(5)]
        [JsonPropertyName("Cor")]
        public string CorDoCarro { get; set; }

        [JsonPropertyOrder(4)]
        [JsonPropertyName("Portas")]
        public int QntdPortas { get; set; }

        [JsonPropertyOrder(6)]
        [JsonPropertyName("Opcionais")]
        public virtual ICollection<AdicionaisCarro> Adicionais { get; set; } // relacionamenro 1 para N
        
    }
}
