using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationsConflicts.Migrations
{
    public partial class feature_B : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Field_B",
                table: "IOTAssets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Field_B",
                table: "IOTAssets");
        }
    }
}
