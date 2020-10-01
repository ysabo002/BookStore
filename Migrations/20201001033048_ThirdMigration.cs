using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaveForLaterID",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SaveForLater",
                columns: table => new
                {
                    SaveForLaterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveForLater", x => x.SaveForLaterID);
                    table.ForeignKey(
                        name: "FK_SaveForLater_Buyer_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Buyer",
                        principalColumn: "BuyerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_SaveForLaterID",
                table: "Book",
                column: "SaveForLaterID");

            migrationBuilder.CreateIndex(
                name: "IX_SaveForLater_BuyerID",
                table: "SaveForLater",
                column: "BuyerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_SaveForLater_SaveForLaterID",
                table: "Book",
                column: "SaveForLaterID",
                principalTable: "SaveForLater",
                principalColumn: "SaveForLaterID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_SaveForLater_SaveForLaterID",
                table: "Book");

            migrationBuilder.DropTable(
                name: "SaveForLater");

            migrationBuilder.DropIndex(
                name: "IX_Book_SaveForLaterID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "SaveForLaterID",
                table: "Book");
        }
    }
}
