using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class tjds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "286b2e72-6cb8-4dcd-81f1-491a9b928afb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90248704-f52a-40a5-96a6-7bb931d68b87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f41b0573-60b1-45c5-8a2f-fe4fdfcde784");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4820882a-e132-44d0-bad5-2c4884dd3901", "d6e42ecf-c5ee-4214-9823-1489ab5b994d", "Teacher", "teacher" },
                    { "68fb3704-4c25-4cfe-9af6-3a919eb32dce", "f7e608e2-b48e-4e58-bbb5-cc985ff595f9", "Admin", "admin" },
                    { "bae4de7e-8b0d-4bc1-9e34-6b7d0dd967c3", "79a2c9f7-8b4a-48af-a94c-30716f1034cb", "Student", "student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4820882a-e132-44d0-bad5-2c4884dd3901");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68fb3704-4c25-4cfe-9af6-3a919eb32dce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bae4de7e-8b0d-4bc1-9e34-6b7d0dd967c3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "286b2e72-6cb8-4dcd-81f1-491a9b928afb", "f295cbc4-8984-4bdc-b55a-35ac8fee755b", "Student", "student" },
                    { "90248704-f52a-40a5-96a6-7bb931d68b87", "5f988ce9-20f6-493e-9070-2af06918a9bd", "Teacher", "teacher" },
                    { "f41b0573-60b1-45c5-8a2f-fe4fdfcde784", "cebd408d-b983-41b3-8388-b242851292ac", "Admin", "admin" }
                });
        }
    }
}
