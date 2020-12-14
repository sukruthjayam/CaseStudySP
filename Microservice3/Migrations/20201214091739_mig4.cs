using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice3.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpriceContexts",
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
                    table.PrimaryKey("PK_SpriceContexts", x => x.SPid);
                    table.ForeignKey(
                        name: "FK_SpriceContexts_CompContexts_Ccode",
                        column: x => x.Ccode,
                        principalTable: "CompContexts",
                        principalColumn: "Cid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpriceContexts_Ccode",
                table: "SpriceContexts",
                column: "Ccode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpriceContexts");
        }
    }
}
