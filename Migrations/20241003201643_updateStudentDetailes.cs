using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemTask.Migrations
{
    /// <inheritdoc />
    public partial class updateStudentDetailes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentDetails_StudentDetailsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentDetailsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentDetailsId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_StudentId",
                table: "StudentDetails",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentDetails_Students_StudentId",
                table: "StudentDetails",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentDetails_Students_StudentId",
                table: "StudentDetails");

            migrationBuilder.DropIndex(
                name: "IX_StudentDetails_StudentId",
                table: "StudentDetails");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentDetails");

            migrationBuilder.AddColumn<int>(
                name: "StudentDetailsId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentDetailsId",
                table: "Students",
                column: "StudentDetailsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentDetails_StudentDetailsId",
                table: "Students",
                column: "StudentDetailsId",
                principalTable: "StudentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
