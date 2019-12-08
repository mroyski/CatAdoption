using Microsoft.EntityFrameworkCore.Migrations;

namespace CatAdoption.Migrations
{
    public partial class NewSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "Age", "Bio", "Gender", "ImagePath", "Name" },
                values: new object[] { 5, 2, "Auspicious One", "Female", "shiva.jpg", "Shiva" });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "Age", "Bio", "Gender", "ImagePath", "Name" },
                values: new object[] { 6, 1, "Fast as heck", "Male", "scooter.jpg", "Scooter" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 6);
        }
    }
}
