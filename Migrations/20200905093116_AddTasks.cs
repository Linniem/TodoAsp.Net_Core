using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskCore.Migrations
{
    public partial class AddTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskListGroup",
                columns: table => new
                {
                    TaskListGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskListGroupName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskListGroup", x => x.TaskListGroupId);
                    table.ForeignKey(
                        name: "FK_TaskListGroup_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskList",
                columns: table => new
                {
                    TaskListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskListName = table.Column<string>(nullable: true),
                    TaskListGroupId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskList", x => x.TaskListId);
                    table.ForeignKey(
                        name: "FK_TaskList_TaskListGroup_TaskListGroupId",
                        column: x => x.TaskListGroupId,
                        principalTable: "TaskListGroup",
                        principalColumn: "TaskListGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskUnit",
                columns: table => new
                {
                    TaskUnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    IsImportant = table.Column<bool>(nullable: false),
                    ExpiredTime = table.Column<DateTime>(nullable: true),
                    Steps = table.Column<string>(nullable: true),
                    ExpiredTodayTime = table.Column<DateTime>(nullable: true),
                    TaskListId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    TaskListId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUnit", x => x.TaskUnitId);
                    table.ForeignKey(
                        name: "FK_TaskUnit_TaskListGroup_TaskListId",
                        column: x => x.TaskListId,
                        principalTable: "TaskListGroup",
                        principalColumn: "TaskListGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskUnit_TaskList_TaskListId1",
                        column: x => x.TaskListId1,
                        principalTable: "TaskList",
                        principalColumn: "TaskListId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskUnit_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_TaskListGroupId",
                table: "TaskList",
                column: "TaskListGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_UserId",
                table: "TaskList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskListGroup_UserId",
                table: "TaskListGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUnit_TaskListId",
                table: "TaskUnit",
                column: "TaskListId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUnit_TaskListId1",
                table: "TaskUnit",
                column: "TaskListId1");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUnit_UserId",
                table: "TaskUnit",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskUnit");

            migrationBuilder.DropTable(
                name: "TaskList");

            migrationBuilder.DropTable(
                name: "TaskListGroup");
        }
    }
}
