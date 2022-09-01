using System.Text.Json.Serialization;

namespace CarroAPI.Models
{
    public class AdicionaisCarro
    {
        public int Id { get; set; }
        public string OpcionaisCarros { get; set; }
        [JsonIgnore]
        public virtual Carro Carro { get; set; }
        public int CarroId { get; set; }
    }
}
