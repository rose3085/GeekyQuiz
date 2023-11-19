using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekyQuiz.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Choices_IsCorrectChoiceId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId1",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropIndex(
                name: "IX_Answers_IsCorrectChoiceId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "IsCorrectChoiceId",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId1",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsCorrectOptionId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_IsCorrectOptionId",
                table: "Answers",
                column: "IsCorrectOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Options_IsCorrectOptionId",
                table: "Answers",
                column: "IsCorrectOptionId",
                principalTable: "Options",
                principalColumn: "OptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId1",
                table: "Answers",
                column: "QuestionId1",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Options_IsCorrectOptionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId1",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Answers_IsCorrectOptionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "IsCorrectOptionId",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId1",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId1",
                table: "Answers",
                column: "QuestionId1",
                principalTable: "Questions",
                principalColumn: "QuestionId");
        }
    }
}
