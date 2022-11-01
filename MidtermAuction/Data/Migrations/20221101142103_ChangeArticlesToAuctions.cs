using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidtermAuction.Data.Migrations
{
    public partial class ChangeArticlesToAuctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Auctions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auctions",
                table: "Auctions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Auctions",
                table: "Auctions");

            migrationBuilder.RenameTable(
                name: "Auctions",
                newName: "Articles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");
        }
    }
}
