using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    BuyerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    nickname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.BuyerID);
                    table.ForeignKey(
                        name: "FK_Buyer_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
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
                    preferred = table.Column<bool>(nullable: false),
                    BuyerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_Buyer_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Buyer",
                        principalColumn: "BuyerID",
                        onDelete: ReferentialAction.Restrict);
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
                    BuyerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardID);
                    table.ForeignKey(
                        name: "FK_Card_Buyer_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Buyer",
                        principalColumn: "BuyerID",
                        onDelete: ReferentialAction.Restrict);
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
                    title = table.Column<string>(nullable: true),
                    author = table.Column<string>(nullable: true),
                    genre = table.Column<string>(nullable: true),
                    isbn = table.Column<string>(nullable: true),
                    seller = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    ratingAve = table.Column<double>(nullable: false),
                    creationDate = table.Column<DateTime>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    ShoppingCartID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Book_ShoppingCart_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalTable: "ShoppingCart",
                        principalColumn: "ShoppingCartID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Book_ShoppingCartID",
                table: "Book",
                column: "ShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_Buyer_UserID",
                table: "Buyer",
                column: "UserID");

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
                name: "IX_ShoppingCart_BuyerID",
                table: "ShoppingCart",
                column: "BuyerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
