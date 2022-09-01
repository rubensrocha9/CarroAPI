using System.Text.Json.Serialization;

namespace CarroAPI.Models
{
    public class Carro : Automovel
    {
        public int Id { get; set; }
        public int QntdPortas { get; set; }
        public string CorDoCarro { get; set; }
        public virtual ICollection<AdicionaisCarro> Adicionais { get; set; } // relacionamenro 1 para N

    }
}
