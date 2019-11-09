namespace P01_StudentSystem.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedReflection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2019, 11, 9, 21, 24, 38, 327, DateTimeKind.Utc).AddTicks(4960), new DateTime(2019, 10, 10, 21, 24, 38, 327, DateTimeKind.Utc).AddTicks(5496) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2019, 11, 9, 21, 24, 38, 327, DateTimeKind.Utc).AddTicks(6624), new DateTime(2019, 9, 30, 21, 24, 38, 327, DateTimeKind.Utc).AddTicks(6634) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2019, 11, 9, 21, 24, 38, 327, DateTimeKind.Utc).AddTicks(6657), new DateTime(2019, 9, 20, 21, 24, 38, 327, DateTimeKind.Utc).AddTicks(6658) });

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 1,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 9, 21, 24, 38, 326, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 2,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 9, 21, 24, 38, 326, DateTimeKind.Utc).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 3,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 9, 21, 24, 38, 326, DateTimeKind.Utc).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredOn" },
                values: new object[] { new DateTime(2019, 11, 9, 21, 24, 38, 324, DateTimeKind.Utc).AddTicks(3831), new DateTime(2019, 10, 30, 21, 24, 38, 324, DateTimeKind.Utc).AddTicks(7398) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredOn" },
                values: new object[] { new DateTime(2019, 4, 23, 21, 24, 38, 324, DateTimeKind.Utc).AddTicks(8424), new DateTime(2019, 8, 1, 21, 24, 38, 324, DateTimeKind.Utc).AddTicks(8458) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2019, 11, 9, 21, 15, 43, 853, DateTimeKind.Utc).AddTicks(2271), new DateTime(2019, 10, 10, 21, 15, 43, 853, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2019, 11, 9, 21, 15, 43, 853, DateTimeKind.Utc).AddTicks(5409), new DateTime(2019, 9, 30, 21, 15, 43, 853, DateTimeKind.Utc).AddTicks(5420) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2019, 11, 9, 21, 15, 43, 853, DateTimeKind.Utc).AddTicks(5437), new DateTime(2019, 9, 20, 21, 15, 43, 853, DateTimeKind.Utc).AddTicks(5438) });

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 1,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 9, 21, 15, 43, 852, DateTimeKind.Utc).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 2,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 9, 21, 15, 43, 852, DateTimeKind.Utc).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 3,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 9, 21, 15, 43, 852, DateTimeKind.Utc).AddTicks(4295));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredOn" },
                values: new object[] { new DateTime(2019, 11, 9, 21, 15, 43, 850, DateTimeKind.Utc).AddTicks(2983), new DateTime(2019, 10, 30, 21, 15, 43, 850, DateTimeKind.Utc).AddTicks(4961) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredOn" },
                values: new object[] { new DateTime(2019, 4, 23, 21, 15, 43, 850, DateTimeKind.Utc).AddTicks(5580), new DateTime(2019, 8, 1, 21, 15, 43, 850, DateTimeKind.Utc).AddTicks(5608) });
        }
    }
}
