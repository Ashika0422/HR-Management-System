using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedHRMS.Migrations
{
    /// <inheritdoc />
    public partial class AddAttendanceFieldsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastCheckIn",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastCheckOut",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalHoursWorked",
                table: "Users",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastCheckIn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastCheckOut",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TotalHoursWorked",
                table: "Users");
        }
    }
}
