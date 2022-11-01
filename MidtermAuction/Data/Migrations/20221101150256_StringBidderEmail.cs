using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidtermAuction.Data.Migrations
{
    public partial class StringBidderEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastBidderEmail",
                table: "Auctions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LastBidderEmail",
                table: "Auctions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
