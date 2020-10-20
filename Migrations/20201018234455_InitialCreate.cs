using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    BuyerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.BuyerID);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    BuyerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_Buyer_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Buyer",
                        principalColumn: "BuyerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CardNumber = table.Column<string>(nullable: true),
                    SecCode = table.Column<int>(nullable: false),
                    Preferred = table.Column<bool>(nullable: false),
                    BuyerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardID);
                    table.ForeignKey(
                        name: "FK_Card_Buyer_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Buyer",
                        principalColumn: "BuyerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaveForLater",
                columns: table => new
                {
                    SaveForLaterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    ShoppingCartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    BuyerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.ShoppingCartID);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Buyer_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Buyer",
                        principalColumn: "BuyerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Isbn = table.Column<string>(nullable: true),
                    Seller = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    RatingAve = table.Column<double>(nullable: false),
                    Cover = table.Column<byte[]>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SaveForLaterID = table.Column<int>(nullable: true),
                    ShoppingCartID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Book_SaveForLater_SaveForLaterID",
                        column: x => x.SaveForLaterID,
                        principalTable: "SaveForLater",
                        principalColumn: "SaveForLaterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_ShoppingCart_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalTable: "ShoppingCart",
                        principalColumn: "ShoppingCartID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    BuyerID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Ratingtxt = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Buyer_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Buyer",
                        principalColumn: "BuyerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_BuyerID",
                table: "Address",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_SaveForLaterID",
                table: "Book",
                column: "SaveForLaterID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_ShoppingCartID",
                table: "Book",
                column: "ShoppingCartID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Card_BuyerID",
                table: "Card",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_BookID",
                table: "Review",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_BuyerID",
                table: "Review",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_SaveForLater_BuyerID",
                table: "SaveForLater",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_BuyerID",
                table: "ShoppingCart",
                column: "BuyerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BookBuyer");

            migrationBuilder.DropTable(
                name: "BookSaveForLater");

            migrationBuilder.DropTable(
                name: "BookShoppingCart");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "SaveForLater");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Buyer");
        }
    }
}
