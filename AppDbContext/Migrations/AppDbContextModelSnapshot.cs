﻿// <auto-generated />
using System;
using AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppDbContext.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Financa.Core.Entities.Conta", b =>
                {
                    b.Property<int>("IdConta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("SaldoConta")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TipoConta")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdConta");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("Financa.Core.Entities.CustoFixo", b =>
                {
                    b.Property<int>("IdCustoFixo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataProximaParcelaFixo")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdConta")
                        .HasColumnType("int");

                    b.Property<int>("ParcelasRestantesFixo")
                        .HasColumnType("int");

                    b.Property<float>("ValorParcelaFixo")
                        .HasColumnType("float");

                    b.HasKey("IdCustoFixo");

                    b.HasIndex("IdConta");

                    b.ToTable("CustoFixos");
                });

            modelBuilder.Entity("Financa.Core.Entities.CustoVariavel", b =>
                {
                    b.Property<int>("IdCustoVariavel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPlanejadaVariavel")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdConta")
                        .HasColumnType("int");

                    b.Property<float>("ValorVariavel")
                        .HasColumnType("float");

                    b.HasKey("IdCustoVariavel");

                    b.HasIndex("IdConta");

                    b.ToTable("CustoVariaveis");
                });

            modelBuilder.Entity("Financa.Core.Entities.Investimento", b =>
                {
                    b.Property<int>("IdInvestimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ContaIdConta")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdConta")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("TaxaDeRetorno")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("ValorInvestido")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("IdInvestimento");

                    b.HasIndex("ContaIdConta");

                    b.ToTable("Investimentos");
                });

            modelBuilder.Entity("Financa.Core.Entities.Objetivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Objetivo");
                });

            modelBuilder.Entity("Financa.Core.Entities.Transacao", b =>
                {
                    b.Property<int>("IdTransacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ContaIdConta")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataTransacao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdConta")
                        .HasColumnType("int");

                    b.Property<string>("TipoTransacao")
                        .HasColumnType("longtext");

                    b.Property<float>("ValorTransacao")
                        .HasColumnType("float");

                    b.HasKey("IdTransacao");

                    b.HasIndex("ContaIdConta");

                    b.ToTable("Transacaos");
                });

            modelBuilder.Entity("Financa.Core.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdConta")
                        .HasColumnType("int");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SenhaUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("InvestimentoObjetivo", b =>
                {
                    b.Property<int>("InvestimentosIdInvestimento")
                        .HasColumnType("int");

                    b.Property<int>("ObjetivosId")
                        .HasColumnType("int");

                    b.HasKey("InvestimentosIdInvestimento", "ObjetivosId");

                    b.HasIndex("ObjetivosId");

                    b.ToTable("InvestimentoObjetivo");
                });

            modelBuilder.Entity("Financa.Core.Entities.CustoFixo", b =>
                {
                    b.HasOne("Financa.Core.Entities.Conta", "Conta")
                        .WithMany("CustosFixos")
                        .HasForeignKey("IdConta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("Financa.Core.Entities.CustoVariavel", b =>
                {
                    b.HasOne("Financa.Core.Entities.Conta", "Conta")
                        .WithMany("CustosVariaveis")
                        .HasForeignKey("IdConta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("Financa.Core.Entities.Investimento", b =>
                {
                    b.HasOne("Financa.Core.Entities.Conta", null)
                        .WithMany("Investimentos")
                        .HasForeignKey("ContaIdConta");
                });

            modelBuilder.Entity("Financa.Core.Entities.Transacao", b =>
                {
                    b.HasOne("Financa.Core.Entities.Conta", null)
                        .WithMany("Transacoes")
                        .HasForeignKey("ContaIdConta");
                });

            modelBuilder.Entity("InvestimentoObjetivo", b =>
                {
                    b.HasOne("Financa.Core.Entities.Investimento", null)
                        .WithMany()
                        .HasForeignKey("InvestimentosIdInvestimento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Financa.Core.Entities.Objetivo", null)
                        .WithMany()
                        .HasForeignKey("ObjetivosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Financa.Core.Entities.Conta", b =>
                {
                    b.Navigation("CustosFixos");

                    b.Navigation("CustosVariaveis");

                    b.Navigation("Investimentos");

                    b.Navigation("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
