using Microsoft.EntityFrameworkCore.Migrations;

namespace UserDashboard.Migrations
{
    public partial class TaskerModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taskers_Users_UserId",
                table: "Taskers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Taskers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserOfTasker",
                table: "Taskers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Taskers_Users_UserId",
                table: "Taskers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taskers_Users_UserId",
                table: "Taskers");

            migrationBuilder.DropColumn(
                name: "UserOfTasker",
                table: "Taskers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Taskers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Taskers_Users_UserId",
                table: "Taskers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
