using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KeithsFunFunPantry.CS
{
    public static class GenerateRecipes
    {
        const string title1 = "Chicken and Bacon Fajitas";
        const string dir1 = "1) Heat a large skillet over medium-high heat. Cook the chicken breasts until the outside is golden brown, and the juices run clear. Salt the breasts to taste, then set aside. 2) Cook the bacon in the hot skillet until it begins to release some oil. Stir in the onion, and bell peppers; cook until the bacon is crispy and the onions are transluscent. Stir in the tomatoes and mushrooms, and continue cooking until the mushrooms have softened. 3) Slice the cooked chicken breasts into bite-sized pieces, then add to the skillet along with the cilantro. Stir to combine, and cook for a minute to reheat. Spoon into warmed tortillas to serve.";
        static List<Ingredient> ing = new List<Ingredient>() { new Ingredient("Skinless Chicken Breast Halves", new Measurement(3f, Unit.Count)), new Ingredient("Bacon", new Measurement(3f, Unit.Count)) };
        static List<Tag> tag1 = new List<Tag>() { Tag.Mexican };
        const string title2 = "Ravioli Dolci (Sweet Ravioli)";
        const string dir2 = "1) In a medium bowl, cream together the butter and sugar until smooth. Beat in the egg, then stir in the vanilla and almond extracts and lemon zest. Combine the flour, baking soda and salt; stir into the creamed mixture until a smooth dough forms. Divide dough into halves. Roll each portion out between two sheets of waxed paper into a 12 inch square. Refrigerate for at least one hour. 2) Preheat the oven to 350 degrees F (175 degrees C). Grease cookie sheets. 3) Remove one piece of the dough from the refrigerator, remove the top layer of waxed paper, and cut into 1 1/2 inch squares. Place about 1/4 teaspoon of the cherry preserves into the center of the first sheet of squares. Set aside. Remove the remaining piece of dough from the refrigerator, remove top layer of waxed paper, and cut into 1 1/2 inch squares also. Poke holes for venting in these squares using a fork. Place each vented square over one of the filled squares, and gently seal the edges by pressing with the tines of a fork. Place cookies 2 inches apart onto prepared cookie sheets. 4) Bake for 9 to 11 minutes in the preheated oven, or until the edges are lightly browned. Allow cookies to cool for 5 minutes on the baking sheets before removing to wire racks to cool completely. Dust cookies with confectioners' sugar while they are still warm.";
        static List<Ingredient> ing2 = new List<Ingredient>() { new Ingredient("Grated Lemon Zest", new Measurement(1f, Unit.Teaspoon)), new Ingredient("All-Purpose Flour", new Measurement(2.5f, Unit.Cup))};
        static List<Tag> tag2 = new List<Tag>() { Tag.Italian };
        const string title3 = "Pumpkin Swirled Cheese Cake";
        const string dir3 = "1) Preheat oven to 375 degrees F (190 degrees C.) 2) In a medium bowl, mix crushed cookies, 3 tablespoons melted butter and 3 tablespoons flour. Press firmly on bottom and side of ungreased 9 inch pie plate. Bake about 12 minutes or until light brown. Allow to cool. 3) In a large bowl, combine white sugar, brown sugar, flour, and cream cheese. Beat on low speed until smooth. Reserve 1/2 cup of this mixture to swirl in later. To the mixture in the bowl, add vanilla, cinnamon, nutmeg, ginger. Blend in eggs and pumpkin puree. Scrape bowl, and beat until smooth. Pour into crust. 4) Stir 1 tablespoon milk into the reserved cream cheese mixture. Drop by spoonfuls over the pumpkin mixture. Use a knife to decoratively swirl the two mixtures together. 5) Cover edge of crust with 2 to 3 inch strip of aluminum foil to prevent excessive browning. Bake in preheated 35 to 40 minutes or until knife inserted in center comes out clean. Remove foil the last 15 minutes of baking. Cool 30 minutes, then refrigerate at least 4 hours before serving.";
        static List<Ingredient> ing3 = new List<Ingredient>() { new Ingredient("Crushed Shortbread Cookies", new Measurement(1.5f, Unit.Cup)), new Ingredient("Butter", new Measurement(3f, Unit.Tablespoon)) };
        static List<Tag> tag3 = new List<Tag>() { Tag.American };

        public static void AddRecipes()
        {
            Recipe r = new Recipe(tag1, ing, title1, dir1);
            CheckIngredients(r);
            RecipeBook.Instance.Recipes.Add(r);
            Recipe r1 = new Recipe(tag2, ing2, title2, dir2);
            CheckIngredients(r1);
            RecipeBook.Instance.Recipes.Add(r1);
            Recipe r2 = new Recipe(tag3, ing3, title3, dir3);
            CheckIngredients(r2);
            RecipeBook.Instance.Recipes.Add(r2);
        }
        private static void CheckIngredients(Recipe r)
        {
            MessageBox.Show(Pantry.Ingredients.Count.ToString());
            foreach(Ingredient i in r.IngredientList)
            {
                if (!Pantry.Ingredients.Contains(i))
                {
                    Pantry.Ingredients.Add(i);
                }            
            }
        }
    }
}
