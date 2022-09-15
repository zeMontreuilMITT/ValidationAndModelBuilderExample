using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValidationAndModelBuilder.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    TeachingStaffNumber = table.Column<int>(type: "int", nullable: false),
                    AssistingStaffNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseNumber);
                    table.UniqueConstraint("AK_Course_AssistingStaffNumber", x => x.AssistingStaffNumber);
                    table.UniqueConstraint("AK_Course_TeachingStaffNumber", x => x.TeachingStaffNumber);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentNumber);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: true),
                    JobTitle = table.Column<int>(type: "int", nullable: false),
                    TeachingCourseNumber = table.Column<int>(type: "int", nullable: true),
                    AssistingCourseNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffNumber);
                    table.ForeignKey(
                        name: "FK_Staff_Course_AssistingCourseNumber",
                        column: x => x.AssistingCourseNumber,
                        principalTable: "Course",
                        principalColumn: "AssistingStaffNumber");
                    table.ForeignKey(
                        name: "FK_Staff_Course_TeachingCourseNumber",
                        column: x => x.TeachingCourseNumber,
                        principalTable: "Course",
                        principalColumn: "TeachingStaffNumber");
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNumber = table.Column<int>(type: "int", nullable: false),
                    CourseNumber = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_CourseNumber",
                        column: x => x.CourseNumber,
                        principalTable: "Course",
                        principalColumn: "CourseNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_StudentNumber",
                        column: x => x.StudentNumber,
                        principalTable: "Student",
                        principalColumn: "StudentNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseNumber",
                table: "Enrollment",
                column: "CourseNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentNumber",
                table: "Enrollment",
                column: "StudentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_AssistingCourseNumber",
                table: "Staff",
                column: "AssistingCourseNumber",
                unique: true,
                filter: "[AssistingCourseNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_TeachingCourseNumber",
                table: "Staff",
                column: "TeachingCourseNumber",
                unique: true,
                filter: "[TeachingCourseNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
