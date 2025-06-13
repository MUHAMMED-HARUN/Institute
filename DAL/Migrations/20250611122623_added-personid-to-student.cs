using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedpersonidtostudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityID",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Neighborhoods_Districts_DistrictID",
                table: "Neighborhoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.RenameTable(
                name: "Districts",
                newName: "District");

            migrationBuilder.RenameIndex(
                name: "IX_Districts_CityID",
                table: "District",
                newName: "IX_District_CityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_District",
                table: "District",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_District_Cities_CityID",
                table: "District",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Neighborhoods_District_DistrictID",
                table: "Neighborhoods",
                column: "DistrictID",
                principalTable: "District",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_District_Cities_CityID",
                table: "District");

            migrationBuilder.DropForeignKey(
                name: "FK_Neighborhoods_District_DistrictID",
                table: "Neighborhoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_District",
                table: "District");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "Districts");

            migrationBuilder.RenameIndex(
                name: "IX_District_CityID",
                table: "Districts",
                newName: "IX_Districts_CityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityID",
                table: "Districts",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Neighborhoods_Districts_DistrictID",
                table: "Neighborhoods",
                column: "DistrictID",
                principalTable: "Districts",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
