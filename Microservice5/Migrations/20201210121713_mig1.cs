using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice5.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CContexts",
                columns: table => new
                {
                    cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CContexts", x => x.cid);
                });

            migrationBuilder.CreateTable(
                name: "SEContexts",
                columns: table => new
                {
                    sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brief = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEContexts", x => x.sid);
                });

            migrationBuilder.CreateTable(
                name: "CContextSEContext",
                columns: table => new
                {
                    Companycid = table.Column<int>(type: "int", nullable: false),
                    StockExchangesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CContextSEContext", x => new { x.Companycid, x.StockExchangesid });
                    table.ForeignKey(
                        name: "FK_CContextSEContext_CContexts_Companycid",
                        column: x => x.Companycid,
                        principalTable: "CContexts",
                        principalColumn: "cid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CContextSEContext_SEContexts_StockExchangesid",
                        column: x => x.StockExchangesid,
                        principalTable: "SEContexts",
                        principalColumn: "sid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CContextSEContext_StockExchangesid",
                table: "CContextSEContext",
                column: "StockExchangesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CContextSEContext");

            migrationBuilder.DropTable(
                name: "CContexts");

            migrationBuilder.DropTable(
                name: "SEContexts");
        }
    }
}
