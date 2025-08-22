using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace resturangApi.Migrations
{
    /// <inheritdoc />
    public partial class addedseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tableId",
                table: "Tables",
                newName: "TableId");

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Description", "ImageUrl", "IsPopular", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Classic pizza with tomato sauce, mozzarella cheese, and fresh basil.", "https://example.com/images/pizza-margherita.jpg", true, "Pizza Margherita", 120 },
                    { 2, "Traditional Italian pasta dish with eggs, cheese, pancetta, and pepper.", "https://example.com/images/spaghetti-carbonara.jpg", true, "Spaghetti Carbonara", 150 },
                    { 3, "Crisp romaine lettuce with Caesar dressing, croutons, and parmesan cheese.", "https://example.com/images/caesar-salad.jpg", false, "Caesar Salad", 100 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Seats", "TableNumber" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 2, 2 },
                    { 3, 6, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Tables",
                newName: "tableId");
        }
    }
}
