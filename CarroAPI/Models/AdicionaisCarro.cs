namespace CarroAPI.Models
{
    public class AdicionaisCarro
    {
        public int Id { get; set; }
        public string OpcionaisCarros { get; set; }
        public Carro Carro { get; set; }
        public int CarroId { get; set; }
    }
}
