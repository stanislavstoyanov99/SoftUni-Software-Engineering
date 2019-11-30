namespace P03_SalesDatabase.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ModifiedConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Sales",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 11, 8, 18, 43, 35, 22, DateTimeKind.Utc).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2019, 11, 8, 18, 43, 35, 22, DateTimeKind.Utc).AddTicks(9884));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Sales",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 11, 7, 17, 40, 40, 130, DateTimeKind.Utc).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2019, 11, 7, 17, 40, 40, 130, DateTimeKind.Utc).AddTicks(8994));
        }
    }
}
