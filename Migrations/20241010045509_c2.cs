using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemTask.Migrations
{
    /// <inheritdoc />
    public partial class c2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Classes_ClassId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_TeacherSubjects_TeacherSubjectId",
                table: "Exams");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherSubjectId",
                table: "Exams",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Exams",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ClassSubjectId",
                table: "Exams",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ClassSubjectId",
                table: "Exams",
                column: "ClassSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_ClassSubjects_ClassSubjectId",
                table: "Exams",
                column: "ClassSubjectId",
                principalTable: "ClassSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Classes_ClassId",
                table: "Exams",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_TeacherSubjects_TeacherSubjectId",
                table: "Exams",
                column: "TeacherSubjectId",
                principalTable: "TeacherSubjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_ClassSubjects_ClassSubjectId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Classes_ClassId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_TeacherSubjects_TeacherSubjectId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ClassSubjectId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ClassSubjectId",
                table: "Exams");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherSubjectId",
                table: "Exams",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Exams",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Classes_ClassId",
                table: "Exams",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_TeacherSubjects_TeacherSubjectId",
                table: "Exams",
                column: "TeacherSubjectId",
                principalTable: "TeacherSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
