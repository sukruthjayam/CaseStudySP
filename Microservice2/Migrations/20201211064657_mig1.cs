using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice2.Migrations
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
                    cname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ceo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    listed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CContexts", x => x.cid);
                });

            migrationBuilder.CreateTable(
                name: "IPOContexts",
                columns: table => new
                {
                    Iid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockExchage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price_per_share = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total_shares = table.Column<int>(type: "int", nullable: false),
                    open_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPOContexts", x => x.Iid);
                });

            migrationBuilder.CreateTable(
                name: "SPContexts",
                columns: table => new
                {
                    SPid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ccode = table.Column<int>(type: "int", nullable: false),
                    SE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    Tstamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPContexts", x => x.SPid);
                    table.ForeignKey(
                        name: "FK_SPContexts_CContexts_Ccode",
                        column: x => x.Ccode,
                        principalTable: "CContexts",
                        principalColumn: "cid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SPContexts_Ccode",
                table: "SPContexts",
                column: "Ccode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPOContexts");

            migrationBuilder.DropTable(
                name: "SPContexts");

            migrationBuilder.DropTable(
                name: "CContexts");
        }
    }
}
