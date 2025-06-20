using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDispositivos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class DispositivoIdForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Eventos_DispositivoId",
                table: "Eventos",
                column: "DispositivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Dispositivos_DispositivoId",
                table: "Eventos",
                column: "DispositivoId",
                principalTable: "Dispositivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Dispositivos_DispositivoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_DispositivoId",
                table: "Eventos");
        }
    }
}
