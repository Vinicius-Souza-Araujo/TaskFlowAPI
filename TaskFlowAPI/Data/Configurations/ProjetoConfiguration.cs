using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlowAPI.Models;

namespace TaskFlowAPI.Data.Configurations
{
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Descricao)
                .HasMaxLength(500);

            builder.Property(p => p.DataCriacao)
                .IsRequired();

            builder.Property(p => p.Arquivado)
                .IsRequired();
        }
    }
}
