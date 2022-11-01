using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidtermAuction.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SellerEmail = table.Column<string>(type: "TEXT", nullable: false),
                    ItemName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ItemDescription = table.Column<string>(type: "TEXT", maxLength: 10000, nullable: false),
                    LastPrice = table.Column<double>(type: "REAL", nullable: false),
                    LastBidderEmail = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
