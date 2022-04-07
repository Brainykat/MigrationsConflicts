using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationsConflicts.Migrations
{
    public partial class fieldfrommaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldFromMaster",
                table: "IOTAssets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldFromMaster",
                table: "IOTAssets");
        }
    }
}
