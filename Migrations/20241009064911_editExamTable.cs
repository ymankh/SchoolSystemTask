using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemTask.Migrations
{
    /// <inheritdoc />
    public partial class editExamTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Exam",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Detailes",
                table: "Exam",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ExamDuration",
                table: "Exam",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExamStartDate",
                table: "Exam",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Exam",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MarkPublished",
                table: "Exam",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ClassId",
                table: "Exam",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Classes_ClassId",
                table: "Exam",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Classes_ClassId",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_ClassId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "Detailes",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "ExamDuration",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "ExamStartDate",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "MarkPublished",
                table: "Exam");
        }
    }
}
