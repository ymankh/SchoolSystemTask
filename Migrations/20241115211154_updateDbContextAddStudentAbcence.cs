using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemTask.Migrations
{
    /// <inheritdoc />
    public partial class updateDbContextAddStudentAbcence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAbsence_Students_StudentId",
                table: "StudentAbsence");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAbsence_TeacherSubjects_TeacherSubjectId",
                table: "StudentAbsence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAbsence",
                table: "StudentAbsence");

            migrationBuilder.RenameTable(
                name: "StudentAbsence",
                newName: "StudentAbsences");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAbsence_TeacherSubjectId",
                table: "StudentAbsences",
                newName: "IX_StudentAbsences_TeacherSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAbsence_StudentId",
                table: "StudentAbsences",
                newName: "IX_StudentAbsences_StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherSubjectId",
                table: "StudentAbsences",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAbsences",
                table: "StudentAbsences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAbsences_Students_StudentId",
                table: "StudentAbsences",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAbsences_TeacherSubjects_TeacherSubjectId",
                table: "StudentAbsences",
                column: "TeacherSubjectId",
                principalTable: "TeacherSubjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAbsences_Students_StudentId",
                table: "StudentAbsences");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAbsences_TeacherSubjects_TeacherSubjectId",
                table: "StudentAbsences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAbsences",
                table: "StudentAbsences");

            migrationBuilder.RenameTable(
                name: "StudentAbsences",
                newName: "StudentAbsence");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAbsences_TeacherSubjectId",
                table: "StudentAbsence",
                newName: "IX_StudentAbsence_TeacherSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAbsences_StudentId",
                table: "StudentAbsence",
                newName: "IX_StudentAbsence_StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherSubjectId",
                table: "StudentAbsence",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAbsence",
                table: "StudentAbsence",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAbsence_Students_StudentId",
                table: "StudentAbsence",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAbsence_TeacherSubjects_TeacherSubjectId",
                table: "StudentAbsence",
                column: "TeacherSubjectId",
                principalTable: "TeacherSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
