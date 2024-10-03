using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemTask.Migrations
{
    /// <inheritdoc />
    public partial class updateClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjects_Subjects_TeacherSubjectId",
                table: "ClassSubjects");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "ClassSubjects",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_SubjectId",
                table: "ClassSubjects",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjects_Subjects_SubjectId",
                table: "ClassSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjects_TeacherSubject_TeacherSubjectId",
                table: "ClassSubjects",
                column: "TeacherSubjectId",
                principalTable: "TeacherSubject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjects_Subjects_SubjectId",
                table: "ClassSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjects_TeacherSubject_TeacherSubjectId",
                table: "ClassSubjects");

            migrationBuilder.DropIndex(
                name: "IX_ClassSubjects_SubjectId",
                table: "ClassSubjects");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "ClassSubjects");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjects_Subjects_TeacherSubjectId",
                table: "ClassSubjects",
                column: "TeacherSubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
