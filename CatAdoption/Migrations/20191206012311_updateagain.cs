using Microsoft.EntityFrameworkCore.Migrations;

namespace CatAdoption.Migrations
{
    public partial class updateagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cats",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 4,
                column: "UserId",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cats",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 1,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 2,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 3,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 4,
                column: "UserId",
                value: 0);
        }
    }
}
