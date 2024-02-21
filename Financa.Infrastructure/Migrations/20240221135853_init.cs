using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    IdConta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoConta = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SaldoConta = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.IdConta);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Objetivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objetivo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustoFixos",
                columns: table => new
                {
                    IdCustoFixo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ValorParcelaFixo = table.Column<float>(type: "float", nullable: false),
                    DataProximaParcelaFixo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ParcelasRestantesFixo = table.Column<int>(type: "int", nullable: false),
                    IdConta = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustoFixos", x => x.IdCustoFixo);
                    table.ForeignKey(
                        name: "FK_CustoFixos_Contas_IdConta",
                        column: x => x.IdConta,
                        principalTable: "Contas",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustoVariaveis",
                columns: table => new
                {
                    IdCustoVariavel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ValorVariavel = table.Column<float>(type: "float", nullable: false),
                    DataPlanejadaVariavel = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdConta = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustoVariaveis", x => x.IdCustoVariavel);
                    table.ForeignKey(
                        name: "FK_CustoVariaveis_Contas_IdConta",
                        column: x => x.IdConta,
                        principalTable: "Contas",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Investimentos",
                columns: table => new
                {
                    IdInvestimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorInvestido = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TaxaDeRetorno = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IdConta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimentos", x => x.IdInvestimento);
                    table.ForeignKey(
                        name: "FK_Investimentos_Contas_IdConta",
                        column: x => x.IdConta,
                        principalTable: "Contas",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transacaos",
                columns: table => new
                {
                    IdTransacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ValorTransacao = table.Column<float>(type: "float", nullable: false),
                    DataTransacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TipoTransacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdConta = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    ContaIdConta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacaos", x => x.IdTransacao);
                    table.ForeignKey(
                        name: "FK_Transacaos_Contas_ContaIdConta",
                        column: x => x.ContaIdConta,
                        principalTable: "Contas",
                        principalColumn: "IdConta");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SenhaUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdConta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Contas_IdConta",
                        column: x => x.IdConta,
                        principalTable: "Contas",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InvestimentoObjetivo",
                columns: table => new
                {
                    InvestimentosIdInvestimento = table.Column<int>(type: "int", nullable: false),
                    ObjetivosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestimentoObjetivo", x => new { x.InvestimentosIdInvestimento, x.ObjetivosId });
                    table.ForeignKey(
                        name: "FK_InvestimentoObjetivo_Investimentos_InvestimentosIdInvestimen~",
                        column: x => x.InvestimentosIdInvestimento,
                        principalTable: "Investimentos",
                        principalColumn: "IdInvestimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestimentoObjetivo_Objetivo_ObjetivosId",
                        column: x => x.ObjetivosId,
                        principalTable: "Objetivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CustoFixos_IdConta",
                table: "CustoFixos",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_CustoVariaveis_IdConta",
                table: "CustoVariaveis",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_InvestimentoObjetivo_ObjetivosId",
                table: "InvestimentoObjetivo",
                column: "ObjetivosId");

            migrationBuilder.CreateIndex(
                name: "IX_Investimentos_IdConta",
                table: "Investimentos",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_Transacaos_ContaIdConta",
                table: "Transacaos",
                column: "ContaIdConta");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdConta",
                table: "Usuarios",
                column: "IdConta",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustoFixos");

            migrationBuilder.DropTable(
                name: "CustoVariaveis");

            migrationBuilder.DropTable(
                name: "InvestimentoObjetivo");

            migrationBuilder.DropTable(
                name: "Transacaos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Investimentos");

            migrationBuilder.DropTable(
                name: "Objetivo");

            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
