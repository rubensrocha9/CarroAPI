using CarroAPI.Models;

namespace CarroAPI.Data.Dtos.Carros
{
    public class ReadCarrosDto : Automovel
    {
        public int Id { get; set; }
        public int QntdPortas { get; set; }
        public string CorDoCarro { get; set; }
        public object Adicionais { get; set; }
    }
}
