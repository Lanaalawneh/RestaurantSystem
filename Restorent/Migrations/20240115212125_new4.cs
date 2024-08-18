using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorent.Migrations
{
    public partial class new4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterOfferNum",
                table: "MasterOffer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterOfferNum",
                table: "MasterOffer");
        }
    }
}
