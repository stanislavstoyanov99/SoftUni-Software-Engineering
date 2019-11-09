namespace P01_StudentSystem.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "char(10)", unicode: false, nullable: true),
                    RegisteredOn = table.Column<DateTime>(nullable: false),
                    Birthday = table.Column<DateTime>(type: "DATETIME2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Url = table.Column<string>(unicode: false, nullable: true),
                    ResourceType = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_Resources_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkSubmissions",
                columns: table => new
                {
                    HomeworkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(unicode: false, nullable: true),
                    ContentType = table.Column<int>(nullable: false),
                    SubmissionTime = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkSubmissions", x => x.HomeworkId);
                    table.ForeignKey(
                        name: "FK_HomeworkSubmissions_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeworkSubmissions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "EndDate", "Name", "Price", "StartDate" },
                values: new object[,]
                {
                    { 1, "C# OOP Module", new DateTime(2019, 11, 9, 21, 15, 43, 853, DateTimeKind.Utc).AddTicks(2271), "C# OOP", 350m, new DateTime(2019, 10, 10, 21, 15, 43, 853, DateTimeKind.Utc).AddTicks(3500) },
                    { 2, "C# Advanced Module", new DateTime(2019, 11, 9, 21, 15, 43, 853, DateTimeKind.Utc).AddTicks(5409), "C# Advanced", 400m, new DateTime(2019, 9, 30, 21, 15, 43, 853, DateTimeKind.Utc).AddTicks(5420) },
                    { 3, "Java Web Module", new DateTime(2019, 11, 9, 21, 15, 43, 853, DateTimeKind.Utc).AddTicks(5437), "Java Web", 500m, new DateTime(2019, 9, 20, 21, 15, 43, 853, DateTimeKind.Utc).AddTicks(5438) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Birthday", "Name", "PhoneNumber", "RegisteredOn" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 11, 9, 21, 15, 43, 850, DateTimeKind.Utc).AddTicks(2983), "Pesho", "0884034665", new DateTime(2019, 10, 30, 21, 15, 43, 850, DateTimeKind.Utc).AddTicks(4961) },
                    { 2, new DateTime(2019, 4, 23, 21, 15, 43, 850, DateTimeKind.Utc).AddTicks(5580), "Kiril", "0884034667", new DateTime(2019, 8, 1, 21, 15, 43, 850, DateTimeKind.Utc).AddTicks(5608) }
                });

            migrationBuilder.InsertData(
                table: "HomeworkSubmissions",
                columns: new[] { "HomeworkId", "Content", "ContentType", "CourseId", "StudentId", "SubmissionTime" },
                values: new object[,]
                {
                    { 1, "Some content here", 1, 1, 1, new DateTime(2019, 11, 9, 21, 15, 43, 852, DateTimeKind.Utc).AddTicks(3734) },
                    { 2, "Some content here 2", 2, 2, 1, new DateTime(2019, 11, 9, 21, 15, 43, 852, DateTimeKind.Utc).AddTicks(4282) },
                    { 3, "Some content here 3", 3, 2, 2, new DateTime(2019, 11, 9, 21, 15, 43, 852, DateTimeKind.Utc).AddTicks(4295) }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "CourseId", "Name", "ResourceType", "Url" },
                values: new object[,]
                {
                    { 1, 1, "SoftUni", 3, "softuni.bg" },
                    { 2, 2, "Telerik Academy", 1, "telerik.bg" },
                    { 4, 2, "Tech world and future technologies", 4, "techworldfuturetechnologies.com" },
                    { 3, 3, "Tech world", 2, "techworld.com" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "StudentId", "CourseId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmissions_CourseId",
                table: "HomeworkSubmissions",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmissions_StudentId",
                table: "HomeworkSubmissions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_CourseId",
                table: "Resources",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeworkSubmissions");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
