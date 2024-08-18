using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorent.Migrations
{
    public partial class new5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterOfferNum",
                table: "MasterOffer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterOfferNum",
                table: "MasterOffer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
