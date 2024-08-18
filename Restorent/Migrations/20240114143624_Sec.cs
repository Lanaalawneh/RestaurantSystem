using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorent.Migrations
{
    public partial class Sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TransactionNewsletter",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "TransactionNewsletter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "TransactionNewsletter",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "TransactionNewsletter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TransactionNewsletter",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TransactionNewsletter",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TransactionContactUs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "TransactionContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "TransactionContactUs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "TransactionContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TransactionContactUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TransactionContactUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TransactionBookTable",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "TransactionBookTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "TransactionBookTable",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "TransactionBookTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TransactionBookTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TransactionBookTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "SystemSetting",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "SystemSetting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "SystemSetting",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "SystemSetting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SystemSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SystemSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterWorkingHour",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "MasterWorkingHour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterWorkingHour",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterWorkingHour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterWorkingHour",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterWorkingHour",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterSocialMedia",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "MasterSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterSocialMedia",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterSocialMedia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterSocialMedia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterSlider",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "MasterSlider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterSlider",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterSlider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterSlider",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterSlider",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterService",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "MasterService",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterService",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterService",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterService",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterService",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterPartner",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "MasterPartner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterPartner",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterPartner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterPartner",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterPartner",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterOffer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "MasterOffer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterOffer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterOffer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterOffer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterOffer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterItemMenu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterItemMenu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterItemMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterItemMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterItemMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterContactUsInformation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "MasterContactUsInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterContactUsInformation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterContactUsInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterContactUsInformation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterContactUsInformation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterCategoryMenu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "MasterCategoryMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterCategoryMenu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "MasterCategoryMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterCategoryMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterCategoryMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TransactionNewsletter");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "TransactionNewsletter");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "TransactionNewsletter");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "TransactionNewsletter");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TransactionNewsletter");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TransactionNewsletter");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TransactionBookTable");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "TransactionBookTable");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "TransactionBookTable");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "TransactionBookTable");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TransactionBookTable");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TransactionBookTable");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterWorkingHour");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "MasterWorkingHour");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterWorkingHour");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterWorkingHour");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterWorkingHour");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterWorkingHour");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterSlider");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "MasterSlider");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterSlider");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterSlider");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterSlider");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterSlider");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterService");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "MasterService");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterService");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterService");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterService");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterService");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterPartner");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "MasterPartner");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterPartner");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterPartner");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterPartner");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterPartner");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterOffer");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "MasterOffer");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterOffer");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterOffer");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterOffer");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterOffer");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterItemMenu");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterContactUsInformation");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "MasterContactUsInformation");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterContactUsInformation");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterContactUsInformation");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterContactUsInformation");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterContactUsInformation");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterCategoryMenu");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "MasterCategoryMenu");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterCategoryMenu");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "MasterCategoryMenu");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterCategoryMenu");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterCategoryMenu");
        }
    }
}
