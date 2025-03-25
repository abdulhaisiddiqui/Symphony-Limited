using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Symphony_Limited.Migrations
{
    /// <inheritdoc />
    public partial class studentExamsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "std_Exam",
                columns: table => new
                {
                    studentExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exam_id = table.Column<int>(type: "int", nullable: false),
                    stu_id = table.Column<int>(type: "int", nullable: false),
                    marksObtained = table.Column<int>(type: "int", nullable: false),
                    examScore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    examResult = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_std_Exam", x => x.studentExamId);
                    table.ForeignKey(
                        name: "FK_std_Exam_EntranceExams_exam_id",
                        column: x => x.exam_id,
                        principalTable: "EntranceExams",
                        principalColumn: "examId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_std_Exam_exam_id",
                table: "std_Exam",
                column: "exam_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "std_Exam");
        }
    }
}
