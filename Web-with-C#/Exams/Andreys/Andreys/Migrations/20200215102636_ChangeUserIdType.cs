﻿namespace Andreys.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeUserIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId1",
                table: "Products",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId1",
                table: "Products",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
