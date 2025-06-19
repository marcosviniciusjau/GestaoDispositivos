using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDispositivos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RemovingClientField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivos_Clientes_ClienteId",
                table: "Dispositivos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Dispositivos_DispositivoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_DispositivoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Dispositivos_ClienteId",
                table: "Dispositivos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Eventos_DispositivoId",
                table: "Eventos",
                column: "DispositivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_ClienteId",
                table: "Dispositivos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivos_Clientes_ClienteId",
                table: "Dispositivos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Dispositivos_DispositivoId",
                table: "Eventos",
                column: "DispositivoId",
                principalTable: "Dispositivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
