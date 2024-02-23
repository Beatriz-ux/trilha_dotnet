using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMed.Core.Entities;

namespace TechMed.Infra.Persistence.Configurations;
public class ExameConfiguration : IEntityTypeConfiguration<Exame>
{
    public void Configure(EntityTypeBuilder<Exame> builder)
    {
        builder
            .ToTable("Exames")
            .HasKey(m => m.ExameId);

        builder
            .HasOne(m => m.Atendimento)
            .WithMany(m => m.Exames)
            .HasForeignKey(m => m.AtendimentoId);
    }
}
