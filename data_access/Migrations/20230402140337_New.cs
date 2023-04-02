using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkWithMigration.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emaillll",
                table: "Passangers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Emaillll",
                table: "Passangers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
