using Microsoft.EntityFrameworkCore;
using Entities;

public class AppDbContext : DbContext
{
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<CustoVariavel> CustoVariaveis { get; set; }
    public DbSet<CustoFixo> CustoFixos { get; set; }
    public DbSet<Transacao> Transacaos { get; set; }

    //nova tabela custoTransacao

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
                //cria chave estrangeira
                entity.Property(e => e.TipoConta).IsRequired().f;
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

            modelBuilder.Entity<CustoFixo>(entity =>
            {
                entity.HasKey(e => e.IdCustoFixo);
                entity.Property(e => e.ValorParcelaFixo).IsRequired();
                entity.Property(e => e.DataProximaParcelaFixo).IsRequired();
                entity.Property(e => e.ParcelasRestantesFixo).IsRequired();
                entity.Property(e => e.IdConta).IsRequired();

                entity.HasOne(e => e.Conta)
                    .WithMany(c => c.CustosFixos)
                    .HasForeignKey(e => e.IdConta)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CustoVariavel>(entity =>
            {
                entity.HasKey(e => e.IdCustoVariavel);
                entity.Property(e => e.ValorVariavel).IsRequired();
                entity.Property(e => e.DataPlanejadaVariavel).IsRequired();
                entity.Property(e => e.IdConta).IsRequired();

                entity.HasOne(e => e.Conta)
                    .WithMany(c => c.CustosVariaveis)
                    .HasForeignKey(e => e.IdConta)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey(e => e.IdTransacao);
                entity.Property(e => e.ValorTransacao).IsRequired();
                entity.Property(e => e.DataTransacao).IsRequired();
                entity.Property(e => e.TipoTransacao);
                entity.Property(e => e.IdConta).IsRequired();

                entity.HasOne(e => e.Conta)
                    .WithMany(c => c.Transacoes)
                    .HasForeignKey(e => e.IdConta)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
        }
}
