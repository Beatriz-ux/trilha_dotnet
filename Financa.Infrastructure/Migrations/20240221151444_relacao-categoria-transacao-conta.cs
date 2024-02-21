using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relacaocategoriatransacaoconta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Transacaos_IdCategoria",
                table: "Transacaos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Transacaos_IdConta",
                table: "Transacaos",
                column: "IdConta");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacaos_Categorias_IdCategoria",
                table: "Transacaos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacaos_Contas_IdConta",
                table: "Transacaos",
                column: "IdConta",
                principalTable: "Contas",
                principalColumn: "IdConta",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacaos_Categorias_IdCategoria",
                table: "Transacaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacaos_Contas_IdConta",
                table: "Transacaos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Transacaos_IdCategoria",
                table: "Transacaos");

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
    }
}
