using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemTask.Migrations
{
    /// <inheritdoc />
    public partial class cc1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentNote_NoteType_NoteTypeId",
                table: "StudentNote");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentNote_Students_StudentId",
                table: "StudentNote");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentNote_Teachers_TeacherId",
                table: "StudentNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentNote",
                table: "StudentNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteType",
                table: "NoteType");

            migrationBuilder.RenameTable(
                name: "StudentNote",
                newName: "StudentNotes");

            migrationBuilder.RenameTable(
                name: "NoteType",
                newName: "NoteTypes");

            migrationBuilder.RenameIndex(
                name: "IX_StudentNote_TeacherId",
                table: "StudentNotes",
                newName: "IX_StudentNotes_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentNote_StudentId",
                table: "StudentNotes",
                newName: "IX_StudentNotes_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentNote_NoteTypeId",
                table: "StudentNotes",
                newName: "IX_StudentNotes_NoteTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentNotes",
                table: "StudentNotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteTypes",
                table: "NoteTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNotes_NoteTypes_NoteTypeId",
                table: "StudentNotes",
                column: "NoteTypeId",
                principalTable: "NoteTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNotes_Students_StudentId",
                table: "StudentNotes",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNotes_Teachers_TeacherId",
                table: "StudentNotes",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentNotes_NoteTypes_NoteTypeId",
                table: "StudentNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentNotes_Students_StudentId",
                table: "StudentNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentNotes_Teachers_TeacherId",
                table: "StudentNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentNotes",
                table: "StudentNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteTypes",
                table: "NoteTypes");

            migrationBuilder.RenameTable(
                name: "StudentNotes",
                newName: "StudentNote");

            migrationBuilder.RenameTable(
                name: "NoteTypes",
                newName: "NoteType");

            migrationBuilder.RenameIndex(
                name: "IX_StudentNotes_TeacherId",
                table: "StudentNote",
                newName: "IX_StudentNote_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentNotes_StudentId",
                table: "StudentNote",
                newName: "IX_StudentNote_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentNotes_NoteTypeId",
                table: "StudentNote",
                newName: "IX_StudentNote_NoteTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentNote",
                table: "StudentNote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteType",
                table: "NoteType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNote_NoteType_NoteTypeId",
                table: "StudentNote",
                column: "NoteTypeId",
                principalTable: "NoteType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNote_Students_StudentId",
                table: "StudentNote",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNote_Teachers_TeacherId",
                table: "StudentNote",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
