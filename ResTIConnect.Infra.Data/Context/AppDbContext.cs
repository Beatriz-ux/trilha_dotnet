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
        public DbSet<Sistema> Sistemas { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        public void EnsureDatabaseCreated()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = "server=localhost;user=root;password=Bvg@2024;database=resticonnect;";
            // var connectionString = "server=192.168.3.213;user=usuario;password=Beto@9999;database=resticonnect;";
            var serverVersion = ServerVersion.AutoDetect(connectionString); // pega a versão do banco de dados
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Perfil>().ToTable("Perfis").HasKey(m => m.PerfilId);
            modelBuilder.Entity<Endereco>().ToTable("Enderecos").HasKey(p => p.EnderecoId);
            modelBuilder.Entity<Eventos>().ToTable("Eventos").HasKey(e => e.EventoId);
            modelBuilder.Entity<Usuarios>().ToTable("Usuarios").HasKey(u => u.UsuarioId);
            modelBuilder.Entity<Sistema>().ToTable("Sistemas").HasKey(s => s.SistemaId);

            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.Endereco)
                .WithMany(e => e.Usuarios)
                .HasForeignKey(u => u.EnderecoId);
            
            // Tabela Sistema
            modelBuilder.Entity<Sistema>(entity => {
                entity.HasMany(s => s.Usuarios).WithMany(u => u.Sistemas);
            });
        }
    }
}
