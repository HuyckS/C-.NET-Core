using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharpExam.Migrations
{
    public partial class ActivityEventChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Activities_ActivityId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_ActivityId",
                table: "Participants");

            migrationBuilder.AddColumn<int>(
                name: "RegisteredActivityActivityId",
                table: "Participants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_RegisteredActivityActivityId",
                table: "Participants",
                column: "RegisteredActivityActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Activities_RegisteredActivityActivityId",
                table: "Participants",
                column: "RegisteredActivityActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Activities_RegisteredActivityActivityId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_RegisteredActivityActivityId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "RegisteredActivityActivityId",
                table: "Participants");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ActivityId",
                table: "Participants",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Activities_ActivityId",
                table: "Participants",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
