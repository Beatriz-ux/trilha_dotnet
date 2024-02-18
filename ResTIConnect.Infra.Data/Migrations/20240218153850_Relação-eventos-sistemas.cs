using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResTIConnect.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Relaçãoeventossistemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventosSistema",
                columns: table => new
                {
                    EventosEventoId = table.Column<int>(type: "int", nullable: false),
                    SistemasSistemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosSistema", x => new { x.EventosEventoId, x.SistemasSistemaId });
                    table.ForeignKey(
                        name: "FK_EventosSistema_Eventos_EventosEventoId",
                        column: x => x.EventosEventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventosSistema_Sistemas_SistemasSistemaId",
                        column: x => x.SistemasSistemaId,
                        principalTable: "Sistemas",
                        principalColumn: "SistemaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EventosSistema_SistemasSistemaId",
                table: "EventosSistema",
                column: "SistemasSistemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventosSistema");
        }
    }
}
