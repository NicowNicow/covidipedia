using Microsoft.EntityFrameworkCore.Migrations;

namespace covidipedia.front.Data.Migrations
{
    public partial class RPPS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RPPS",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RPPS",
                table: "AspNetUsers");
        }
    }
}
