using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Data.Models;

namespace ResTIConnect.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Sistemas> Sistemas {get; set;}
        public DbSet<Eventos> Eventos {get; set;}
        public DbSet<Usuarios> Usuarios {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = "server=localhost;user=resticonnect;password=Beto@9999;database=resticonnect;";
            var serverVersion = ServerVersion.AutoDetect(connectionString); // pega a versão do banco de dados
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Perfil>().ToTable("Perfis").HasKey(m => m.PerfilId);
            modelBuilder.Entity<Endereco>().ToTable("Enderecos").HasKey(p => p.EnderecoId);
            modelBuilder.Entity<Sistemas>().ToTable("Sistemas")
                .HasKey(s => s.SistemaId);
            modelBuilder.Entity<Eventos>().ToTable("Eventos")
                .HasKey(e => e.EventoId);
            modelBuilder.Entity<Usuarios>().ToTable("Usuarios")
                .HasKey(u => u.UsuarioId);
        }
    }
}
