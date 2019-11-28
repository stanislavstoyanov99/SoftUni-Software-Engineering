namespace P03_FootballBetting.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedEnumerationAndDataSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Prediction",
                table: "Bets",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Prediction",
                table: "Bets",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldUnicode: false,
                oldMaxLength: 50);
        }
    }
}
