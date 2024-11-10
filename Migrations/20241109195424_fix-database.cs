using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemTask.Migrations
{
    /// <inheritdoc />
    public partial class fixdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Datetime",
                table: "StudentAbsence",
                newName: "DateTime");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "StudentClasses",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentClasses",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Relational:ColumnOrder", 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "StudentAbsence",
                newName: "Datetime");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "StudentClasses",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentClasses",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Relational:ColumnOrder", 1);
        }
    }
}
