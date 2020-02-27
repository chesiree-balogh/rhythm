using Microsoft.EntityFrameworkCore.Migrations;

namespace rhythm.Migrations
{
    public partial class TableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BandName",
                table: "Bands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BandName",
                table: "Bands");
        }
    }
}
