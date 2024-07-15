using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Order.Persistance.Migrations
{
    public partial class AddedUserInformationsAtAddressEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "Addresses",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Detail1",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Detail2",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Detail2",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Addresses",
                newName: "Detail");
        }
    }
}
