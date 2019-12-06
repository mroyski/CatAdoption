using Microsoft.EntityFrameworkCore.Migrations;

namespace CatAdoption.Migrations
{
    public partial class InitialCats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.CatId);
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "Age", "Bio", "Gender", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, 4, "A fluffy and handsome cuddle muffin.", "Male", "~/imgs/herbert.jpg", "Herbert" },
                    { 2, 4, "He has a lot to say...", "Male", "~/imgs/kyrie.jpg", "Kyrie" },
                    { 3, 4, "His neck is a little crooked.", "Male", "~/imgs/crusher.jpg", "Crusher" },
                    { 4, 4, "Not a real cat.", "Female", "~/imgs/kelly.jpg", "Kelly" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats");
        }
    }
}
