using Microsoft.EntityFrameworkCore.Migrations;

namespace UserDashboard.Migrations
{
    public partial class PriorityLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentPriority",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CommentPriority",
                table: "Comments");
        }
    }
}
