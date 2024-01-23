using Microsoft.EntityFrameworkCore;
using ResTIConnect.Infra.Data.Models;

namespace ResTIConnect.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = "server=localhost;user=root;password=123456;database=resticonnect;";
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Perfil>().ToTable("Perfis").HasKey(m => m.PerfilId);
            modelBuilder.Entity<Endereco>().ToTable("Enderecos").HasKey(p => p.EnderecoId);
        }
    }
}
