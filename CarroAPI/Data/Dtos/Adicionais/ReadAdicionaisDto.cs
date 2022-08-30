using CarroAPI.Models;

namespace CarroAPI.Data.Dtos.Adicionais
{
    public class ReadAdicionaisDto
    {
        public int Id { get; set; }
        public string OpcionaisCarros { get; set; }
        public Carro Carro { get; set; }
    }
}
