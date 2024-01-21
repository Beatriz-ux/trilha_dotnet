using Microsoft.EntityFrameworkCore;
using Entities;

public class AppDbContext : DbContext
{
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = "server=localhost;user=projetopessoal;password=Beto@9999;database=projetopessoal;";
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Conta>(entity =>
            {
                entity.HasKey(e => e.IdConta);
                entity.Property(e => e.TipoConta).IsRequired();
                entity.Property(e => e.SaldoConta).IsRequired();
            });
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);
                entity.Property(e => e.NomeUsuario).IsRequired();
                entity.Property(e => e.EmailUsuario).IsRequired();
                entity.Property(e => e.SenhaUsuario).IsRequired();
                entity.Property(e => e.IdConta).IsRequired();
            });

            
        }
}
