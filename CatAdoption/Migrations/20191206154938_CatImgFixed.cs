using Microsoft.EntityFrameworkCore.Migrations;

namespace CatAdoption.Migrations
{
    public partial class CatImgFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 1,
                column: "ImagePath",
                value: "herbert.jpg");

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 2,
                column: "ImagePath",
                value: "kyrie.jpg");

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 3,
                column: "ImagePath",
                value: "crusher.jpg");

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 4,
                column: "ImagePath",
                value: "kelly.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 1,
                column: "ImagePath",
                value: "~/imgs/herbert.jpg");

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 2,
                column: "ImagePath",
                value: "~/imgs/kyrie.jpg");

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 3,
                column: "ImagePath",
                value: "~/imgs/crusher.jpg");

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 4,
                column: "ImagePath",
                value: "~/imgs/kelly.jpg");
        }
    }
}
