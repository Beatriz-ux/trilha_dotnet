using Microsoft.EntityFrameworkCore;
using ResTIConnect.Infra.Data.Models;

namespace ResTIConnect.Infra.Data.Context{
    public class AppDbContext : DbContext
    {
        public DbSet<Logs> Logs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = "server=localhost;user=resticonnect;password=Beto@9999;database=resticonnect;";
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
