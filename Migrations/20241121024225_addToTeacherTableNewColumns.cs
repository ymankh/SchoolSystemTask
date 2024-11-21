using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemTask.Migrations
{
    /// <inheritdoc />
    public partial class addToTeacherTableNewColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plane",
                table: "UserTeachers");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Teachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Teachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Teachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "Teachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserStudents",
                columns: table => new
                {
                    UserStudentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Salt = table.Column<string>(type: "TEXT", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStudents", x => x.UserStudentId);
                    table.ForeignKey(
                        name: "FK_UserStudents_Teachers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStudents_StudentId",
                table: "UserStudents",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStudents");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "Plane",
                table: "UserTeachers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
