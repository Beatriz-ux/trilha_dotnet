using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMed.Core.Entities;

namespace TechMed.Infra.Persistence.Configurations
{
    public class AtendimentoConfiguration : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder
                .ToTable("Atendimentos")
                .HasKey(m => m.AtendimentoId);

            builder
                .HasOne(m => m.Medico)
                .WithMany(m => m.Atendimentos)
                .HasForeignKey(m => m.MedicoId);

            builder
               .HasOne(m => m.Paciente)
               .WithMany(m => m.Atendimentos)
               .HasForeignKey(m => m.PacienteId);
        }
    }
}