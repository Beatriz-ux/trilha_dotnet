using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Infrastructure.Persistence.Configurations;

public class CasoJuridicoConfigurations : IEntityTypeConfiguration<CasoJuridico>
{
    public void Configure(EntityTypeBuilder<CasoJuridico> builder)
    {
        builder
            .ToTable("CasoJuridico")
            .HasKey(x => x.CasoJuridicoId);

         builder
         .HasOne(x => x.Advogado)
         .WithMany(x => x.CasosJuridicos)
         .HasForeignKey(x => x.CasoJuridicoId);

         builder
         .HasOne(x => x.Cliente)
         .WithMany(x => x.CasosJuridicos)
         .HasForeignKey(x => x.CasoJuridicoId);

         builder
         .HasOne(x => x.Documento)
         .WithMany(x => x.CasosJuridicos)
         .HasForeignKey(x => x.CasoJuridicoId);

    }
}
