namespace P03_FootballBetting.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ApliedDataSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "Name" },
                values: new object[,]
                {
                    { 1, "Black" },
                    { 2, "White" },
                    { 3, "Red" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Bulgaria" },
                    { 2, "USA" },
                    { 3, "Italy" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "Name" },
                values: new object[,]
                {
                    { 1, "attacker" },
                    { 2, "deffender" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "TownId", "CountryId", "Name" },
                values: new object[] { 1, 1, "Sofia" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "TownId", "CountryId", "Name" },
                values: new object[] { 2, 2, "Los Angelis" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "TownId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "TownId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2);
        }
    }
}
