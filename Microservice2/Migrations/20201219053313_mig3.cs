using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice2.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sector",
                table: "CContexts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "stockexc",
                table: "CContexts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sector",
                table: "CContexts");

            migrationBuilder.DropColumn(
                name: "stockexc",
                table: "CContexts");
        }
    }
}
