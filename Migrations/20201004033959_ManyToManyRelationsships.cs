using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class ManyToManyRelationsships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookBuyer",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false),
                    BuyerID = table.Column<int>(nullable: false),
                    BookBuyerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBuyer", x => new { x.BookID, x.BuyerID });
                    table.ForeignKey(
                        name: "FK_BookBuyer_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBuyer_Buyer_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Buyer",
                        principalColumn: "BuyerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookSaveForLater",
                columns: table => new
                {
                    SaveForLaterID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false),
                    BookSaveForLaterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSaveForLater", x => new { x.BookID, x.SaveForLaterID });
                    table.ForeignKey(
                        name: "FK_BookSaveForLater_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSaveForLater_SaveForLater_SaveForLaterID",
                        column: x => x.SaveForLaterID,
                        principalTable: "SaveForLater",
                        principalColumn: "SaveForLaterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookShoppingCart",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false),
                    ShoppingCartID = table.Column<int>(nullable: false),
                    BookShoppingCartID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookShoppingCart", x => new { x.BookID, x.ShoppingCartID });
                    table.ForeignKey(
                        name: "FK_BookShoppingCart_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookShoppingCart_ShoppingCart_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalTable: "ShoppingCart",
                        principalColumn: "ShoppingCartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBuyer_BuyerID",
                table: "BookBuyer",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_BookSaveForLater_SaveForLaterID",
                table: "BookSaveForLater",
                column: "SaveForLaterID");

            migrationBuilder.CreateIndex(
                name: "IX_BookShoppingCart_ShoppingCartID",
                table: "BookShoppingCart",
                column: "ShoppingCartID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBuyer");

            migrationBuilder.DropTable(
                name: "BookSaveForLater");

            migrationBuilder.DropTable(
                name: "BookShoppingCart");
        }
    }
}
