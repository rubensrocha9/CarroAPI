using CarroAPI.Data.Configuracao_Contexto;
using CarroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarroAPI.Data
{
    public class CarroAPIContext : DbContext
    {
        public DbSet<Carro> Carro { get; set; }
        public DbSet<AdicionaisCarro> Opcionais { get; set; }
        public CarroAPIContext(DbContextOptions<CarroAPIContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdicionaisCarro>()
                .HasOne(c => c.Carro)
                .WithMany(c => c.Adicionais)
                .HasForeignKey(c => c.CarroId);

            modelBuilder.ApplyConfiguration(new CarroConfiguration());
            modelBuilder.ApplyConfiguration(new AdicionaisCarroConfiguration());
        }
    }
}
