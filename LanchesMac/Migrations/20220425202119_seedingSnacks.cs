using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    public partial class seedingSnacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId,ShortDescription,DetailedDescription,InStock,ImageThumbnailUrl,ImageUrl,IsFavoriteSnack,Name,Price) VALUES(1,'Bread, hamburguer, egg, ham, cheese and straw potato','delicious hamburger bun with fried egg; top quality ham and cheese served with straw potatoes.',1,'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg',0,'Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId,ShortDescription,DetailedDescription,InStock,ImageThumbnailUrl,ImageUrl,IsFavoriteSnack,Name,Price) VALUES(1,'Bread, ham, mozzarella and tomato','Delicious warm French bread on the plate with ham and mozzarella well served with tomato prepared with care.',1,'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg','http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg',0,'Grilled ham and cheese', 8.00)");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId,ShortDescription,DetailedDescription,InStock,ImageThumbnailUrl,ImageUrl,IsFavoriteSnack,Name,Price) VALUES(1,'Bread, hamburger, ham, mozzarella and straw potato','Special hamburger bun with hamburger of our preparation and ham and mozzarella; accompanies straw potato.',1,'http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg','http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg',0,'Cheese Burger', 11.00)");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId,ShortDescription,DetailedDescription,InStock,ImageThumbnailUrl,ImageUrl,IsFavoriteSnack,Name,Price) VALUES(2,'Wholemeal bread, white cheese, turkey breast, carrots, lettuce, yogurt','Natural wholemeal bread with white cheese, turkey breast and grated carrots with chopped lettuce and natural yogurt.',1,'http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg','http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg',1,'Natural Snack Turkey breast', 15.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Snacks");
        }
    }
}
