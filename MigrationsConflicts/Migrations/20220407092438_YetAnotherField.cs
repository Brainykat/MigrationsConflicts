using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationsConflicts.Migrations
{
    public partial class YetAnotherField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YetAnotherField",
                table: "IOTAssets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YetAnotherField",
                table: "IOTAssets");
        }
    }
}
