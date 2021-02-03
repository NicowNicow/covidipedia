using Microsoft.EntityFrameworkCore.Migrations;

namespace covidipedia.front.Data.Migrations
{
    public partial class Doc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "AppUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AppUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsMedical",
                table: "AppUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "IsMedical",
                table: "AppUsers");
        }
    }
}
