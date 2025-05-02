using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedHRMS.Migrations
{
    /// <inheritdoc />
    public partial class PayrollTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bonus",
                table: "Payrolls");

            migrationBuilder.RenameColumn(
                name: "PayDate",
                table: "Payrolls",
                newName: "PaymentDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payrolls",
                newName: "PayrollId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Deductions",
                table: "Payrolls",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BasicSalary",
                table: "Payrolls",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Allowances",
                table: "Payrolls",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Bonuses",
                table: "Payrolls",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetSalary",
                table: "Payrolls",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "OvertimeHours",
                table: "Payrolls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OvertimePay",
                table: "Payrolls",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "Payrolls",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allowances",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "Bonuses",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "NetSalary",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "OvertimeHours",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "OvertimePay",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Payrolls");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "Payrolls",
                newName: "PayDate");

            migrationBuilder.RenameColumn(
                name: "PayrollId",
                table: "Payrolls",
                newName: "Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "Deductions",
                table: "Payrolls",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BasicSalary",
                table: "Payrolls",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Bonus",
                table: "Payrolls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
