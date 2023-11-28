using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekyQuiz.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "optionD",
                table: "Choices",
                newName: "OptionD");

            migrationBuilder.RenameColumn(
                name: "optionC",
                table: "Choices",
                newName: "OptionC");

            migrationBuilder.RenameColumn(
                name: "optionB",
                table: "Choices",
                newName: "OptionB");

            migrationBuilder.RenameColumn(
                name: "optionA",
                table: "Choices",
                newName: "OptionA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OptionD",
                table: "Choices",
                newName: "optionD");

            migrationBuilder.RenameColumn(
                name: "OptionC",
                table: "Choices",
                newName: "optionC");

            migrationBuilder.RenameColumn(
                name: "OptionB",
                table: "Choices",
                newName: "optionB");

            migrationBuilder.RenameColumn(
                name: "OptionA",
                table: "Choices",
                newName: "optionA");
        }
    }
}
