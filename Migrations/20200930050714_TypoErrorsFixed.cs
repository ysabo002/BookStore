using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class TypoErrorsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nickname",
                table: "Buyer",
                newName: "Nickname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Buyer",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Buyer",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Book",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "seller",
                table: "Book",
                newName: "Seller");

            migrationBuilder.RenameColumn(
                name: "ratingAve",
                table: "Book",
                newName: "RatingAve");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Book",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Book",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "isbn",
                table: "Book",
                newName: "Isbn");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "Book",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "creationDate",
                table: "Book",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "author",
                table: "Book",
                newName: "Author");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Buyer",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Buyer",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Buyer",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Book",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Seller",
                table: "Book",
                newName: "seller");

            migrationBuilder.RenameColumn(
                name: "RatingAve",
                table: "Book",
                newName: "ratingAve");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Book",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Book",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Isbn",
                table: "Book",
                newName: "isbn");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Book",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Book",
                newName: "creationDate");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Book",
                newName: "author");
        }
    }
}
