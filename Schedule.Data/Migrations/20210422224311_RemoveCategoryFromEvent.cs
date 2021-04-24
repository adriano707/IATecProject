using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedule.Data.Migrations
{
    public partial class RemoveCategoryFromEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Event");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
