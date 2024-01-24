using Microsoft.EntityFrameworkCore;
using Entities;
namespace AppDbContext;
public class AppDbContext : DbContext
{
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<CustoVariavel> CustoVariaveis { get; set; }
    public DbSet<CustoFixo> CustoFixos { get; set; }
    public DbSet<Transacao> Transacaos { get; set; }

    public DbSet<Investimento> Investimentos { get; set; }
    public DbSet<Objetivo> Objetivo { get; set; }
    public DbSet<ObjetivoInvestimento> ObjetivoInvestimentos { get; set; }


    //nova tabela custoTransacao

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //var connectionString = "server=localhost;user=usuario;password=Beto@9999;database=projetopessoal;";
            var connectionString = "server=192.168.3.205;user=usuario;password=Beto@9999;database=projetopessoal;";
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
            
            modelBuilder.Entity<Investimento>(entity =>{
                    entity.HasKey(e => e.IdInvestimento); //chave pimaria

                    entity.HasMany(e => e.Objetivos)
                    .WithMany(e => e.Investimentos);


            });
        }
}
