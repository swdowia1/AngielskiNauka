using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngielskiNauka.Migrations
{
    /// <inheritdoc />
    public partial class nowowsci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddNews",
                columns: table => new
                {
                    AddNewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poziom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddNews", x => x.AddNewId);
                });

            migrationBuilder.CreateTable(
                name: "Pozioms",
                columns: table => new
                {
                    PoziomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozioms", x => x.PoziomId);
                });

            migrationBuilder.CreateTable(
                name: "Danes",
                columns: table => new
                {
                    DaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PoziomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danes", x => x.DaneId);
                    table.ForeignKey(
                        name: "FK_Danes_Pozioms_PoziomId",
                        column: x => x.PoziomId,
                        principalTable: "Pozioms",
                        principalColumn: "PoziomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PoziomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Pozioms_PoziomId",
                        column: x => x.PoziomId,
                        principalTable: "Pozioms",
                        principalColumn: "PoziomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Danes_PoziomId",
                table: "Danes",
                column: "PoziomId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PoziomId",
                table: "Stats",
                column: "PoziomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddNews");

            migrationBuilder.DropTable(
                name: "Danes");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Pozioms");
        }
    }
}
