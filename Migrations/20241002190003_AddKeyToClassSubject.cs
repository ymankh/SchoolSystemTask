using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemTask.Migrations
{
    /// <inheritdoc />
    public partial class AddKeyToClassSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjects_Subjects_SubjectId",
                table: "ClassSubjects");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "ClassSubjects",
                newName: "TeacherSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjects_SubjectId",
                table: "ClassSubjects",
                newName: "IX_ClassSubjects_TeacherSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjects_Subjects_TeacherSubjectId",
                table: "ClassSubjects",
                column: "TeacherSubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjects_Subjects_TeacherSubjectId",
                table: "ClassSubjects");

            migrationBuilder.RenameColumn(
                name: "TeacherSubjectId",
                table: "ClassSubjects",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjects_TeacherSubjectId",
                table: "ClassSubjects",
                newName: "IX_ClassSubjects_SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjects_Subjects_SubjectId",
                table: "ClassSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
