using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedHRMS.Migrations
{
    /// <inheritdoc />
    public partial class AddIsApprovedToEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Employees");
        }
    }
}
