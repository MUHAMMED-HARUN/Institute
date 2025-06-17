using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateEnrollmentStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "EnrollmentStatus",
                table: "EnrolmentStudent",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrollmentStatus",
                table: "EnrolmentStudent");
        }
    }
}
