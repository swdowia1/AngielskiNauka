using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngielskiNauka.Migrations
{
    /// <inheritdoc />
    public partial class stan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<int>(
                name: "Stan",
                table: "Danes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stan",
                table: "Danes");

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
        }
    }
}
