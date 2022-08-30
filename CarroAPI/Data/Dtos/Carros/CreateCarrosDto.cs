using CarroAPI.Models;

namespace CarroAPI.Data.Dtos.Carros
{
    public class CreateCarrosDto : Automovel
    {
        public int QntdPortas { get; set; }
        public string CorDoCarro { get; set; }
    }
}
