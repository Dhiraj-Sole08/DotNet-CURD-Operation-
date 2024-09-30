using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssignmentApp.Migrations
{
    /// <inheritdoc />
    public partial class DBV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Electronic items", "Electronics" },
                    { 2, "Apparel and clothing", "Clothing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
