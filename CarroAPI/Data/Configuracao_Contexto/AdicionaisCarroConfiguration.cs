using CarroAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarroAPI.Data.Configuracao_Contexto
{
    public class AdicionaisCarroConfiguration : IEntityTypeConfiguration<AdicionaisCarro>
    {
        public void Configure(EntityTypeBuilder<AdicionaisCarro> builder)
        {
            builder.HasKey(p => new { p.Id }); // pega o Id da Tabela
            builder.ToTable("Opcionais"); // Nomeia a Tabela
            builder.Property(o => o.Id).HasColumnName("Id"); // nomeando e identificando a coluna na tabela
            builder.Property(o => o.OpcionaisCarros).HasColumnName("Opcionais"); // nomeando e identificando a coluna na tabela
            builder.Property(o => o.CarroId).HasColumnName("Carro Id"); // nomeando e identificando a coluna na tabela

        }
    }
}
