using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskCore.Migrations
{
    public partial class AddUserMemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserMemoText",
                table: "TaskUnits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserMemoText",
                table: "TaskUnits");
        }
    }
}
