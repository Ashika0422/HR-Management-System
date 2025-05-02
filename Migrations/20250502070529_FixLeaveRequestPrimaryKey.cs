using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedHRMS.Migrations
{
    /// <inheritdoc />
    public partial class FixLeaveRequestPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LeaveRequests",
                newName: "LeaveRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LeaveRequestId",
                table: "LeaveRequests",
                newName: "Id");
        }
    }
}
