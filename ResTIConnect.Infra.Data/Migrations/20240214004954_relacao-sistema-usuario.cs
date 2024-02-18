using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResTIConnect.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class relacaosistemausuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SistemaUsuarios",
                columns: table => new
                {
                    SistemasSistemaId = table.Column<int>(type: "int", nullable: false),
                    UsuariosUsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaUsuarios", x => new { x.SistemasSistemaId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_SistemaUsuarios_Sistemas_SistemasSistemaId",
                        column: x => x.SistemasSistemaId,
                        principalTable: "Sistemas",
                        principalColumn: "SistemaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SistemaUsuarios_Usuarios_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaUsuarios_UsuariosUsuarioId",
                table: "SistemaUsuarios",
                column: "UsuariosUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SistemaUsuarios");
        }
    }
}
