using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationsConflicts.Migrations
{
    public partial class AnotherField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnotherField",
                table: "IOTAssets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnotherField",
                table: "IOTAssets");
        }
    }
}
