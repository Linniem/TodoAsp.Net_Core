using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskCore.Migrations
{
    public partial class AddForeignerKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskUnits_Users_UserId",
                table: "TaskUnits");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TaskUnits",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUnits_Users_UserId",
                table: "TaskUnits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskUnits_Users_UserId",
                table: "TaskUnits");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TaskUnits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUnits_Users_UserId",
                table: "TaskUnits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
