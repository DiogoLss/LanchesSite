using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    public partial class seedingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description)"
                + "VALUES('Normal', 'Snack made by normal ingredients')");
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description)"
                + "VALUES('Natural', 'Snack made by integral and natural ingredients')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
