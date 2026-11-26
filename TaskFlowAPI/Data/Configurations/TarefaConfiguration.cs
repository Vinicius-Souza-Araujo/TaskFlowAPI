using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlowAPI.Models;

namespace TaskFlowAPI.Data.Configurations
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Titulo)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(t => t.Descricao)
                .HasMaxLength(500);

            builder.Property(t => t.Status)
                .IsRequired();

            builder.Property(t => t.Prioridade)
                .IsRequired();

            builder.Property(t => t.DataCriacao)
                .IsRequired();

            builder.Property(t => t.DataVencimento);

            builder.HasOne(t => t.Projeto)
                .WithMany(p => p.Tarefas)
                .HasForeignKey(t => t.ProjetoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
