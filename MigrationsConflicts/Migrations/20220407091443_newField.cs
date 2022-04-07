using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationsConflicts.Migrations
{
    public partial class newField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewField",
                table: "IOTAssets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewField",
                table: "IOTAssets");
        }
    }
}
