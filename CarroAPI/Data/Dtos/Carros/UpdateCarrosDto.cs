using CarroAPI.Models;

namespace CarroAPI.Data.Dtos.Carros
{
    public class UpdateCarrosDto : Automovel
    {
        public int QntdPortas { get; set; }
        public string CorDoCarro { get; set; }
        public ICollection<AdicionaisCarro> Adicionais { get; set; }
    }
}
