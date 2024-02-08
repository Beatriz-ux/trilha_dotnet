using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoTransacaoERemovendoObjetivosInvestimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacaos_Contas_IdConta",
                table: "Transacaos");

            migrationBuilder.DropTable(
                name: "ObjetivoInvestimentos");

            migrationBuilder.DropIndex(
                name: "IX_Transacaos_IdConta",
                table: "Transacaos");

            migrationBuilder.AddColumn<int>(
                name: "ContaIdConta",
                table: "Transacaos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacaos_ContaIdConta",
                table: "Transacaos",
                column: "ContaIdConta");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacaos_Contas_ContaIdConta",
                table: "Transacaos",
                column: "ContaIdConta",
                principalTable: "Contas",
                principalColumn: "IdConta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacaos_Contas_ContaIdConta",
                table: "Transacaos");

            migrationBuilder.DropIndex(
                name: "IX_Transacaos_ContaIdConta",
                table: "Transacaos");

            migrationBuilder.DropColumn(
                name: "ContaIdConta",
                table: "Transacaos");

            migrationBuilder.CreateTable(
                name: "ObjetivoInvestimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InvestimentoIdInvestimento = table.Column<int>(type: "int", nullable: false),
                    ObjetivoId = table.Column<int>(type: "int", nullable: false),
                    IdInvestimento = table.Column<int>(type: "int", nullable: false),
                    IdObjetivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivoInvestimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjetivoInvestimentos_Investimentos_InvestimentoIdInvestimen~",
                        column: x => x.InvestimentoIdInvestimento,
                        principalTable: "Investimentos",
                        principalColumn: "IdInvestimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjetivoInvestimentos_Objetivo_ObjetivoId",
                        column: x => x.ObjetivoId,
                        principalTable: "Objetivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Transacaos_IdConta",
                table: "Transacaos",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivoInvestimentos_InvestimentoIdInvestimento",
                table: "ObjetivoInvestimentos",
                column: "InvestimentoIdInvestimento");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivoInvestimentos_ObjetivoId",
                table: "ObjetivoInvestimentos",
                column: "ObjetivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacaos_Contas_IdConta",
                table: "Transacaos",
                column: "IdConta",
                principalTable: "Contas",
                principalColumn: "IdConta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
