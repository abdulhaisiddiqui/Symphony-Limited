using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Symphony_Limited.Migrations
{
    /// <inheritdoc />
    public partial class hasforeignkeyCourseEnrollmentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_courseEnrollment_course_id",
                table: "tbl_courseEnrollment",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_courseEnrollment_student_id",
                table: "tbl_courseEnrollment",
                column: "student_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_courseEnrollment_tbl_courses_course_id",
                table: "tbl_courseEnrollment",
                column: "course_id",
                principalTable: "tbl_courses",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_courseEnrollment_tbl_students_student_id",
                table: "tbl_courseEnrollment",
                column: "student_id",
                principalTable: "tbl_students",
                principalColumn: "student_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_courseEnrollment_tbl_courses_course_id",
                table: "tbl_courseEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_courseEnrollment_tbl_students_student_id",
                table: "tbl_courseEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_tbl_courseEnrollment_course_id",
                table: "tbl_courseEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_tbl_courseEnrollment_student_id",
                table: "tbl_courseEnrollment");
        }
    }
}
