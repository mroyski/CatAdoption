using Microsoft.EntityFrameworkCore.Migrations;

namespace CatAdoption.Migrations.AdoptDb
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Adoptions",
                columns: new[] { "AdoptionId", "Age", "Bio", "CatId", "Gender", "Name", "UserId" },
                values: new object[] { 1, 4, "A fluffy and handsome cuddle muffin.", 1, "Male", "Herbert", "mroyski@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adoptions",
                keyColumn: "AdoptionId",
                keyValue: 1);
        }
    }
}
