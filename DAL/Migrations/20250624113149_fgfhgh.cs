using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class fgfhgh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadingDay_QuranStudents_QuranStudentID",
                table: "ReadingDay");

            migrationBuilder.DropIndex(
                name: "IX_ReadingDay_QuranStudentID",
                table: "ReadingDay");

            migrationBuilder.DropColumn(
                name: "QuranStudentID",
                table: "ReadingDay");

            migrationBuilder.AddColumn<int>(
                name: "QuranStudentID",
                table: "Readings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "ReadingDay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReadingDate",
                table: "ReadingDay",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Readings_QuranStudentID",
                table: "Readings",
                column: "QuranStudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_QuranStudents_QuranStudentID",
                table: "Readings",
                column: "QuranStudentID",
                principalTable: "QuranStudents",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_QuranStudents_QuranStudentID",
                table: "Readings");

            migrationBuilder.DropIndex(
                name: "IX_Readings_QuranStudentID",
                table: "Readings");

            migrationBuilder.DropColumn(
                name: "QuranStudentID",
                table: "Readings");

            migrationBuilder.DropColumn(
                name: "Discription",
                table: "ReadingDay");

            migrationBuilder.DropColumn(
                name: "ReadingDate",
                table: "ReadingDay");

            migrationBuilder.AddColumn<int>(
                name: "QuranStudentID",
                table: "ReadingDay",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReadingDay_QuranStudentID",
                table: "ReadingDay",
                column: "QuranStudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingDay_QuranStudents_QuranStudentID",
                table: "ReadingDay",
                column: "QuranStudentID",
                principalTable: "QuranStudents",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
