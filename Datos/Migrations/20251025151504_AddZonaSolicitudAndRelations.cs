using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class AddZonaSolicitudAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    FechaDesde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoDJ = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MontoSalon = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MontoGastro = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MontoBarra = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.IdSolicitud);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    IdZona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.IdZona);
                });

            migrationBuilder.CreateTable(
                name: "BarraSolicitudes",
                columns: table => new
                {
                    IdBarraSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBarra = table.Column<int>(type: "int", nullable: false),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarraSolicitudes", x => x.IdBarraSolicitud);
                    table.ForeignKey(
                        name: "FK_BarraSolicitudes_Barras_IdBarra",
                        column: x => x.IdBarra,
                        principalTable: "Barras",
                        principalColumn: "IdBarra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarraSolicitudes_Solicitudes_IdSolicitud",
                        column: x => x.IdSolicitud,
                        principalTable: "Solicitudes",
                        principalColumn: "IdSolicitud",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DjSolicitudes",
                columns: table => new
                {
                    IdDjSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDj = table.Column<int>(type: "int", nullable: false),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DjSolicitudes", x => x.IdDjSolicitud);
                    table.ForeignKey(
                        name: "FK_DjSolicitudes_Djs_IdDj",
                        column: x => x.IdDj,
                        principalTable: "Djs",
                        principalColumn: "IdDj",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DjSolicitudes_Solicitudes_IdSolicitud",
                        column: x => x.IdSolicitud,
                        principalTable: "Solicitudes",
                        principalColumn: "IdSolicitud",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GastroSolicitudes",
                columns: table => new
                {
                    IdGastroSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGastro = table.Column<int>(type: "int", nullable: false),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastroSolicitudes", x => x.IdGastroSolicitud);
                    table.ForeignKey(
                        name: "FK_GastroSolicitudes_Gastronomicos_IdGastro",
                        column: x => x.IdGastro,
                        principalTable: "Gastronomicos",
                        principalColumn: "IdGastro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GastroSolicitudes_Solicitudes_IdSolicitud",
                        column: x => x.IdSolicitud,
                        principalTable: "Solicitudes",
                        principalColumn: "IdSolicitud",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalonSolicitudes",
                columns: table => new
                {
                    IdSalonSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSalon = table.Column<int>(type: "int", nullable: false),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonSolicitudes", x => x.IdSalonSolicitud);
                    table.ForeignKey(
                        name: "FK_SalonSolicitudes_Salones_IdSalon",
                        column: x => x.IdSalon,
                        principalTable: "Salones",
                        principalColumn: "IdSalon",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalonSolicitudes_Solicitudes_IdSolicitud",
                        column: x => x.IdSolicitud,
                        principalTable: "Solicitudes",
                        principalColumn: "IdSolicitud",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZonaBarras",
                columns: table => new
                {
                    IdZonaBarra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdZona = table.Column<int>(type: "int", nullable: false),
                    IdBarra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaBarras", x => x.IdZonaBarra);
                    table.ForeignKey(
                        name: "FK_ZonaBarras_Barras_IdBarra",
                        column: x => x.IdBarra,
                        principalTable: "Barras",
                        principalColumn: "IdBarra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZonaBarras_Zonas_IdZona",
                        column: x => x.IdZona,
                        principalTable: "Zonas",
                        principalColumn: "IdZona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZonaDJs",
                columns: table => new
                {
                    IdZonaDJ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdZona = table.Column<int>(type: "int", nullable: false),
                    IdDj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaDJs", x => x.IdZonaDJ);
                    table.ForeignKey(
                        name: "FK_ZonaDJs_Djs_IdDj",
                        column: x => x.IdDj,
                        principalTable: "Djs",
                        principalColumn: "IdDj",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZonaDJs_Zonas_IdZona",
                        column: x => x.IdZona,
                        principalTable: "Zonas",
                        principalColumn: "IdZona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZonaGastros",
                columns: table => new
                {
                    IdZonaGastro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdZona = table.Column<int>(type: "int", nullable: false),
                    IdGastro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaGastros", x => x.IdZonaGastro);
                    table.ForeignKey(
                        name: "FK_ZonaGastros_Gastronomicos_IdGastro",
                        column: x => x.IdGastro,
                        principalTable: "Gastronomicos",
                        principalColumn: "IdGastro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZonaGastros_Zonas_IdZona",
                        column: x => x.IdZona,
                        principalTable: "Zonas",
                        principalColumn: "IdZona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZonaSalones",
                columns: table => new
                {
                    IdZonaSalon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdZona = table.Column<int>(type: "int", nullable: false),
                    IdSalon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaSalones", x => x.IdZonaSalon);
                    table.ForeignKey(
                        name: "FK_ZonaSalones_Salones_IdSalon",
                        column: x => x.IdSalon,
                        principalTable: "Salones",
                        principalColumn: "IdSalon",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZonaSalones_Zonas_IdZona",
                        column: x => x.IdZona,
                        principalTable: "Zonas",
                        principalColumn: "IdZona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarraSolicitudes_IdBarra",
                table: "BarraSolicitudes",
                column: "IdBarra");

            migrationBuilder.CreateIndex(
                name: "IX_BarraSolicitudes_IdSolicitud",
                table: "BarraSolicitudes",
                column: "IdSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_DjSolicitudes_IdDj",
                table: "DjSolicitudes",
                column: "IdDj");

            migrationBuilder.CreateIndex(
                name: "IX_DjSolicitudes_IdSolicitud",
                table: "DjSolicitudes",
                column: "IdSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_GastroSolicitudes_IdGastro",
                table: "GastroSolicitudes",
                column: "IdGastro");

            migrationBuilder.CreateIndex(
                name: "IX_GastroSolicitudes_IdSolicitud",
                table: "GastroSolicitudes",
                column: "IdSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_SalonSolicitudes_IdSalon",
                table: "SalonSolicitudes",
                column: "IdSalon");

            migrationBuilder.CreateIndex(
                name: "IX_SalonSolicitudes_IdSolicitud",
                table: "SalonSolicitudes",
                column: "IdSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_IdCliente",
                table: "Solicitudes",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaBarras_IdBarra",
                table: "ZonaBarras",
                column: "IdBarra");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaBarras_IdZona",
                table: "ZonaBarras",
                column: "IdZona");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaDJs_IdDj",
                table: "ZonaDJs",
                column: "IdDj");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaDJs_IdZona",
                table: "ZonaDJs",
                column: "IdZona");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaGastros_IdGastro",
                table: "ZonaGastros",
                column: "IdGastro");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaGastros_IdZona",
                table: "ZonaGastros",
                column: "IdZona");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaSalones_IdSalon",
                table: "ZonaSalones",
                column: "IdSalon");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaSalones_IdZona",
                table: "ZonaSalones",
                column: "IdZona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarraSolicitudes");

            migrationBuilder.DropTable(
                name: "DjSolicitudes");

            migrationBuilder.DropTable(
                name: "GastroSolicitudes");

            migrationBuilder.DropTable(
                name: "SalonSolicitudes");

            migrationBuilder.DropTable(
                name: "ZonaBarras");

            migrationBuilder.DropTable(
                name: "ZonaDJs");

            migrationBuilder.DropTable(
                name: "ZonaGastros");

            migrationBuilder.DropTable(
                name: "ZonaSalones");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Zonas");
        }
    }
}
