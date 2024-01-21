using Microsoft.EntityFrameworkCore;
using ResTIConnect.Infra.Data.Models;

namespace ResTIConnect.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Perfis> Perfis { get; set; }
        public DbSet<Enderecos> Enderecos { get; set; }
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
        }
    }
}
