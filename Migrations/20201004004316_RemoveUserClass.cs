using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class RemoveUserClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Buyer_BuyerID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Buyer_User_UserID",
                table: "Buyer");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Buyer_BuyerID",
                table: "Card");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Buyer_UserID",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "Preferred",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "Card",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true) ;

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "Address",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",               
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Address",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Buyer_BuyerID",
                table: "Address",
                column: "BuyerID",
                principalTable: "Buyer",
                principalColumn: "BuyerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Buyer_BuyerID",
                table: "Card",
                column: "BuyerID",
                principalTable: "Buyer",
                principalColumn: "BuyerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Buyer_BuyerID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Buyer_BuyerID",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "Card",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Buyer",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "Address",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Preferred",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyer_UserID",
                table: "Buyer",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Buyer_BuyerID",
                table: "Address",
                column: "BuyerID",
                principalTable: "Buyer",
                principalColumn: "BuyerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Buyer_User_UserID",
                table: "Buyer",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Buyer_BuyerID",
                table: "Card",
                column: "BuyerID",
                principalTable: "Buyer",
                principalColumn: "BuyerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
