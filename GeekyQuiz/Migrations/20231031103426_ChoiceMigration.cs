using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekyQuiz.Migrations
{
    /// <inheritdoc />
    public partial class ChoiceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Answers");

            migrationBuilder.AddColumn<int>(
                name: "IsCorrectChoiceId",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    ChoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId1 = table.Column<int>(type: "int", nullable: true),
                    ChoiceA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChoiceB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChoiceC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChoiceD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.ChoiceId);
                    table.ForeignKey(
                        name: "FK_Choices_Questions_QuestionId1",
                        column: x => x.QuestionId1,
                        principalTable: "Questions",
                        principalColumn: "QuestionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_IsCorrectChoiceId",
                table: "Answers",
                column: "IsCorrectChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_QuestionId1",
                table: "Choices",
                column: "QuestionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Choices_IsCorrectChoiceId",
                table: "Answers",
                column: "IsCorrectChoiceId",
                principalTable: "Choices",
                principalColumn: "ChoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Choices_IsCorrectChoiceId",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropIndex(
                name: "IX_Answers_IsCorrectChoiceId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "IsCorrectChoiceId",
                table: "Answers");

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
