using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngielskiNauka.Migrations
{
    /// <inheritdoc />
    public partial class repeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Repeat",
                table: "Stats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repeat",
                table: "Stats");
        }
    }
}
