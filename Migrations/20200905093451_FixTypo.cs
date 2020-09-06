using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskCore.Migrations
{
    public partial class FixTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_TaskListGroup_TaskListGroupId",
                table: "TaskList");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_Users_UserId",
                table: "TaskList");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskListGroup_Users_UserId",
                table: "TaskListGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskUnit_TaskListGroup_TaskListId",
                table: "TaskUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskUnit_TaskList_TaskListId1",
                table: "TaskUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskUnit_Users_UserId",
                table: "TaskUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskUnit",
                table: "TaskUnit");

            migrationBuilder.DropIndex(
                name: "IX_TaskUnit_TaskListId1",
                table: "TaskUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskListGroup",
                table: "TaskListGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskList",
                table: "TaskList");

            migrationBuilder.DropColumn(
                name: "TaskListId1",
                table: "TaskUnit");

            migrationBuilder.RenameTable(
                name: "TaskUnit",
                newName: "TaskUnits");

            migrationBuilder.RenameTable(
                name: "TaskListGroup",
                newName: "TaskListGroups");

            migrationBuilder.RenameTable(
                name: "TaskList",
                newName: "TaskLists");

            migrationBuilder.RenameIndex(
                name: "IX_TaskUnit_UserId",
                table: "TaskUnits",
                newName: "IX_TaskUnits_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskUnit_TaskListId",
                table: "TaskUnits",
                newName: "IX_TaskUnits_TaskListId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskListGroup_UserId",
                table: "TaskListGroups",
                newName: "IX_TaskListGroups_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskList_UserId",
                table: "TaskLists",
                newName: "IX_TaskLists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskList_TaskListGroupId",
                table: "TaskLists",
                newName: "IX_TaskLists_TaskListGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskUnits",
                table: "TaskUnits",
                column: "TaskUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskListGroups",
                table: "TaskListGroups",
                column: "TaskListGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskLists",
                table: "TaskLists",
                column: "TaskListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskListGroups_Users_UserId",
                table: "TaskListGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLists_TaskListGroups_TaskListGroupId",
                table: "TaskLists",
                column: "TaskListGroupId",
                principalTable: "TaskListGroups",
                principalColumn: "TaskListGroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLists_Users_UserId",
                table: "TaskLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUnits_TaskLists_TaskListId",
                table: "TaskUnits",
                column: "TaskListId",
                principalTable: "TaskLists",
                principalColumn: "TaskListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUnits_Users_UserId",
                table: "TaskUnits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskListGroups_Users_UserId",
                table: "TaskListGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskLists_TaskListGroups_TaskListGroupId",
                table: "TaskLists");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskLists_Users_UserId",
                table: "TaskLists");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskUnits_TaskLists_TaskListId",
                table: "TaskUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskUnits_Users_UserId",
                table: "TaskUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskUnits",
                table: "TaskUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskLists",
                table: "TaskLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskListGroups",
                table: "TaskListGroups");

            migrationBuilder.RenameTable(
                name: "TaskUnits",
                newName: "TaskUnit");

            migrationBuilder.RenameTable(
                name: "TaskLists",
                newName: "TaskList");

            migrationBuilder.RenameTable(
                name: "TaskListGroups",
                newName: "TaskListGroup");

            migrationBuilder.RenameIndex(
                name: "IX_TaskUnits_UserId",
                table: "TaskUnit",
                newName: "IX_TaskUnit_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskUnits_TaskListId",
                table: "TaskUnit",
                newName: "IX_TaskUnit_TaskListId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskLists_UserId",
                table: "TaskList",
                newName: "IX_TaskList_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskLists_TaskListGroupId",
                table: "TaskList",
                newName: "IX_TaskList_TaskListGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskListGroups_UserId",
                table: "TaskListGroup",
                newName: "IX_TaskListGroup_UserId");

            migrationBuilder.AddColumn<int>(
                name: "TaskListId1",
                table: "TaskUnit",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskUnit",
                table: "TaskUnit",
                column: "TaskUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskList",
                table: "TaskList",
                column: "TaskListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskListGroup",
                table: "TaskListGroup",
                column: "TaskListGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUnit_TaskListId1",
                table: "TaskUnit",
                column: "TaskListId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_TaskListGroup_TaskListGroupId",
                table: "TaskList",
                column: "TaskListGroupId",
                principalTable: "TaskListGroup",
                principalColumn: "TaskListGroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_Users_UserId",
                table: "TaskList",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskListGroup_Users_UserId",
                table: "TaskListGroup",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUnit_TaskListGroup_TaskListId",
                table: "TaskUnit",
                column: "TaskListId",
                principalTable: "TaskListGroup",
                principalColumn: "TaskListGroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUnit_TaskList_TaskListId1",
                table: "TaskUnit",
                column: "TaskListId1",
                principalTable: "TaskList",
                principalColumn: "TaskListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUnit_Users_UserId",
                table: "TaskUnit",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
