using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekyQuiz.Migrations
{
    public partial class fourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChoiceD",
                table: "Choices",
                newName: "optionD");

            migrationBuilder.RenameColumn(
                name: "ChoiceC",
                table: "Choices",
                newName: "optionC");

            migrationBuilder.RenameColumn(
                name: "ChoiceB",
                table: "Choices",
                newName: "optionB");

            migrationBuilder.RenameColumn(
                name: "ChoiceA",
                table: "Choices",
                newName: "optionA");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "optionD",
                table: "Choices",
                newName: "ChoiceD");

            migrationBuilder.RenameColumn(
                name: "optionC",
                table: "Choices",
                newName: "ChoiceC");

            migrationBuilder.RenameColumn(
                name: "optionB",
                table: "Choices",
                newName: "ChoiceB");

            migrationBuilder.RenameColumn(
                name: "optionA",
                table: "Choices",
                newName: "ChoiceA");

            migrationBuilder.AlterColumn<long>(
                name: "PhoneNumber",
                table: "Logins",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
