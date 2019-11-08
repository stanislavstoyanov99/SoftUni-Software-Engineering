namespace P01_HospitalDatabase.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedFluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Visitations",
                type: "DATETIME2",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patients",
                unicode: false,
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Visitations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patients",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 80);
        }
    }
}
