using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addcounter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherEvaluationCounter",
                table: "TeacherEvaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherEvaluationCounter",
                table: "TeacherEvaluations");
        }
    }
}
