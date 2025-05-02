using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedHRMS.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusAndPaymentMethodToPayrolls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Payrolls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Payrolls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Payrolls");
        }
    }
}
