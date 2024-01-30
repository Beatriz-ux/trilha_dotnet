using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Infrastructure.Persistence.Configurations;

public class DocumentoConfigurations : IEntityTypeConfiguration<Documento>
{
    public void Configure(EntityTypeBuilder<Documento> builder)
    {
        builder
            .ToTable("Documentos")
            .HasKey(x => x.DocumentoId);
    }
}
