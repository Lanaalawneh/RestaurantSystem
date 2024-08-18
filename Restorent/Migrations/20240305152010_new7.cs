using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorent.Migrations
{
    public partial class new7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MasterItemMenuTotalPrice",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterItemMenuTotalPrice",
                table: "MasterItemMenu");
        }
    }
}
