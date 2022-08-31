using Microsoft.EntityFrameworkCore.Migrations;

namespace ExplorerApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Places",
                newName: "City");

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "PlaceId", "City", "Country", "Description", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "Paris", "France", null, "Adrienne", 5 },
                    { 2, "Portland", "USA", null, "Royal", 5 },
                    { 3, "El Salvador", "South America", null, "Pancake", 3 },
                    { 4, "Madrid", "Spain", null, "Adrienne", 4 },
                    { 5, "Milan", "Italy", null, "Pancake", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Places",
                newName: "UserName");
        }
    }
}
