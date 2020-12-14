using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice3.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecContexts",
                columns: table => new
                {
                    Sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brief = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecContexts", x => x.Sid);
                });

            migrationBuilder.CreateTable(
                name: "CompContexts",
                columns: table => new
                {
                    Cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sectorid = table.Column<int>(type: "int", nullable: false),
                    Sname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompContexts", x => x.Cid);
                    table.ForeignKey(
                        name: "FK_CompContexts_SecContexts_Sectorid",
                        column: x => x.Sectorid,
                        principalTable: "SecContexts",
                        principalColumn: "Sid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompContexts_Sectorid",
                table: "CompContexts",
                column: "Sectorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompContexts");

            migrationBuilder.DropTable(
                name: "SecContexts");
        }
    }
}
