using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharpExam.Migrations
{
    public partial class ActivityEventID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Activities_RegisteredActivityActivityId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_RegisteredActivityActivityId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "RegisteredActivityActivityId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "ActivityEventId",
                table: "Participants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityEventId",
                table: "Activities",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "ActivityEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ActivityEventId",
                table: "Participants",
                column: "ActivityEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Activities_ActivityEventId",
                table: "Participants",
                column: "ActivityEventId",
                principalTable: "Activities",
                principalColumn: "ActivityEventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Activities_ActivityEventId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_ActivityEventId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityEventId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ActivityEventId",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Participants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegisteredActivityActivityId",
                table: "Participants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "ActivityId");

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
    }
}
