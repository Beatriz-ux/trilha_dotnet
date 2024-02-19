using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResTIConnect.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class relacaooperfilusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Perfis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_UsuarioId",
                table: "Perfis",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfis_Usuarios_UsuarioId",
                table: "Perfis",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_Usuarios_UsuarioId",
                table: "Perfis");

            migrationBuilder.DropIndex(
                name: "IX_Perfis_UsuarioId",
                table: "Perfis");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Perfis");
        }
    }
}
