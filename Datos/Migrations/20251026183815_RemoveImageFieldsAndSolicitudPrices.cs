using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImageFieldsAndSolicitudPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoBarra",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "MontoDJ",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "MontoGastro",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "MontoSalon",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Gastronomicos");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Djs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MontoBarra",
                table: "Solicitudes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoDJ",
                table: "Solicitudes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoGastro",
                table: "Solicitudes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoSalon",
                table: "Solicitudes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Gastronomicos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Djs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
