using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeStudentAttendanceDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "StudentAttendanceDate",
                table: "StudentAttendances",
                type: "dateonly",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StudentAttendanceDate",
                table: "StudentAttendances",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "dateonly");
        }
    }
}
