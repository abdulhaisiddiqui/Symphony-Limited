using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Symphony_Limited.Migrations
{
    /// <inheritdoc />
    public partial class entranceExamMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_students_exams");

            migrationBuilder.CreateTable(
                name: "EntranceExams",
                columns: table => new
                {
                    examId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    examName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    examDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    examFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntranceExams", x => x.examId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntranceExams");

            migrationBuilder.CreateTable(
                name: "tbl_students_exams",
                columns: table => new
                {
                    exam_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cour_id = table.Column<int>(type: "int", nullable: false),
                    exam_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exam_score = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stu_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_students_exams", x => x.exam_id);
                });
        }
    }
}
