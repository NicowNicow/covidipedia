using Microsoft.EntityFrameworkCore.Migrations;

namespace covidipedia.front.Data.Migrations
{
    public partial class PasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "AppUsers",
                maxLength: 84,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AppUsers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }
    }
}
