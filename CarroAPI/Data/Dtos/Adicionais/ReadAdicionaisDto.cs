using CarroAPI.Models;
using System.Text.Json.Serialization;

namespace CarroAPI.Data.Dtos.Adicionais
{
    public class ReadAdicionaisDto
    {        
        public int Id { get; set; }

        [JsonPropertyName("Colocado")]
        public string OpcionaisCarros { get; set; }
        public Carro Carro { get; set; }
    }
}
