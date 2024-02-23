using Microsoft.EntityFrameworkCore;
using TechMed.Core.Entities;

namespace TechMed.Infra.Persistence;
public sealed class TechMedContext : DbContext
{
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }
    public DbSet<Exame> Exames { get; set; }

    public TechMedContext(DbContextOptions<TechMedContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechMedContext).Assembly);
    }
}
