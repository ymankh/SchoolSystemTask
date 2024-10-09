using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemTask.Migrations
{
    /// <inheritdoc />
    public partial class ExamTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Classes_ClassId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_TeacherSubject_TeacherSubjectId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamMark_Exam_ExamId",
                table: "ExamMark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_TeacherSubjectId",
                table: "Exams",
                newName: "IX_Exams_TeacherSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_ClassId",
                table: "Exams",
                newName: "IX_Exams_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamMark_Exams_ExamId",
                table: "ExamMark",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Classes_ClassId",
                table: "Exams",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_TeacherSubject_TeacherSubjectId",
                table: "Exams",
                column: "TeacherSubjectId",
                principalTable: "TeacherSubject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamMark_Exams_ExamId",
                table: "ExamMark");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Classes_ClassId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_TeacherSubject_TeacherSubjectId",
                table: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_TeacherSubjectId",
                table: "Exam",
                newName: "IX_Exam_TeacherSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_ClassId",
                table: "Exam",
                newName: "IX_Exam_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Classes_ClassId",
                table: "Exam",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_TeacherSubject_TeacherSubjectId",
                table: "Exam",
                column: "TeacherSubjectId",
                principalTable: "TeacherSubject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamMark_Exam_ExamId",
                table: "ExamMark",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
