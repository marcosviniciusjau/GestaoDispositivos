using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDispositivos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FK_Client_Id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivos_Clientes_ClienteId",
                table: "Dispositivos");

            migrationBuilder.DropIndex(
                name: "IX_Dispositivos_ClienteId",
                table: "Dispositivos");
        }
    }
}
