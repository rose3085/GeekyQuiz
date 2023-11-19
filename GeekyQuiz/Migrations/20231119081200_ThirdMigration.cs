using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekyQuiz.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId1",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "PlayId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "QuestionId1",
                table: "Answers",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId1",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Answers",
                newName: "QuestionId1");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                newName: "IX_Answers_QuestionId1");

            migrationBuilder.AddColumn<int>(
                name: "PlayId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId1",
                table: "Answers",
                column: "QuestionId1",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
