using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDispositivos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Nullable_Date_Field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtivacao",
                table: "Dispositivos",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtivacao",
                table: "Dispositivos");
        }
    }
}
