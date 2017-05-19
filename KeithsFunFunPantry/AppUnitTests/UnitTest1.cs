using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeithsFunFunPantry;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using KeithsFunFunPantry.CS;

namespace AppUnitTests
{
    [TestClass]
    public class PantryTest
    {
        [TestMethod]
        public void AddNewIngredientTest_IngredientAddedToEndOfList()
        {
            Pantry.AddNewIngredient("Milk", new Measurement(1f, Unit.Gallon));
            Assert.IsTrue(Pantry.Ingredients[Pantry.Ingredients.Count - 1].Name == "Milk");

            Pantry.AddNewIngredient("Sugar", new Measurement(1f, Unit.Pound));
            Assert.IsTrue(Pantry.Ingredients[0].Name == "Milk");
            Assert.IsTrue(Pantry.Ingredients[Pantry.Ingredients.Count - 1].Name == "Sugar");

            Pantry.AddNewIngredient("Baking Powder", new Measurement(24f, Unit.Tablespoon));
            Assert.IsTrue(Pantry.Ingredients[Pantry.Ingredients.Count - 1].Name == "Baking Powder");

            Pantry.AddNewIngredient("Salt", new Measurement(243.67f, Unit.Kilogram));
            Assert.IsTrue(Pantry.Ingredients[Pantry.Ingredients.Count - 1].Name == "Salt");
        }
        [TestMethod]
        public void AddNewIngredientTest_IngredientCount()
        {
            Pantry.Ingredients = new List<Ingredient>();

            Pantry.AddNewIngredient("Milk", new Measurement(1f, Unit.Gallon));
            Pantry.AddNewIngredient("Sugar", new Measurement(1f, Unit.Pound));
            Pantry.AddNewIngredient("Baking Powder", new Measurement(24f, Unit.Tablespoon));
            Pantry.AddNewIngredient("Salt", new Measurement(243.67f, Unit.Kilogram));

            Assert.AreEqual(4, Pantry.Ingredients.Count);
        }

        [TestMethod]
        public void RecipeNameSearchTest()
        {

        }

        [TestMethod]
        public void IngredientNameSearchTest()
        {
            Pantry.Ingredients = new List<Ingredient>()
            {
                new Ingredient("Milk", new Measurement(1f, Unit.Gallon)),
                new Ingredient("Bleu Cheese Dressing", new Measurement(16.7f, Unit.Ounce)),
                new Ingredient("Sugar", new Measurement(1f, Unit.Pound)),
                new Ingredient("Baking Powder", new Measurement(24f, Unit.Tablespoon)),
                new Ingredient("Shredded Cheese", new Measurement(12f, Unit.Cup)),
                new Ingredient("Cheese", new Measurement(4.5f, Unit.Cup)),
                new Ingredient("Salt", new Measurement(243.67f, Unit.Kilogram))
            };

            string query = "cheese";
            List<Ingredient> results = Pantry.IngredientNameSearch(query);

            List<Ingredient> expectedResults = new List<Ingredient>()
            {
                new Ingredient("Bleu Cheese Dressing", new Measurement(16.7f, Unit.Ounce)),
                new Ingredient("Shredded Cheese", new Measurement(12f, Unit.Cup)),
                new Ingredient("Cheese", new Measurement(4.5f, Unit.Cup)),
            };
            Assert.AreEqual(expectedResults, results);
        }
    }
}
