using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace resturangApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Name", "PasswordHash" },
                values: new object[] { new Guid("7d17ec3e-8418-47b5-affb-d6b2a9fc67dc"), "admin", "9A0DEEADB7A880BC314CA2F3C7FF1A25EDC4B1B62FAE7743FDFC95F514314ECD.976DFD14270865CD5E53DE94E856F97E" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Name",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7d17ec3e-8418-47b5-affb-d6b2a9fc67dc"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
