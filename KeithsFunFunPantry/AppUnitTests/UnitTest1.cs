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
			Pantry.AddNewIngredient("Milk", new Measurement(1f, Unit.gallon));
			Assert.IsTrue(Pantry.Ingredients[Pantry.Ingredients.Count - 1].Name == "Milk");

			Pantry.AddNewIngredient("Sugar", new Measurement(1f, Unit.pound));
			Assert.IsTrue(Pantry.Ingredients[0].Name == "Milk");
			Assert.IsTrue(Pantry.Ingredients[Pantry.Ingredients.Count - 1].Name == "Sugar");

			Pantry.AddNewIngredient("Baking Powder", new Measurement(24f, Unit.tablespoon));
			Assert.IsTrue(Pantry.Ingredients[Pantry.Ingredients.Count - 1].Name == "Baking Powder");

			Pantry.AddNewIngredient("Salt", new Measurement(243.67f, Unit.kilogram));
			Assert.IsTrue(Pantry.Ingredients[Pantry.Ingredients.Count - 1].Name == "Salt");
		}
		[TestMethod]
		public void AddNewIngredientTest_IngredientCount()
		{
			Pantry.Ingredients = new List<Ingredient>();

			Pantry.AddNewIngredient("Milk", new Measurement(1f, Unit.gallon));
			Pantry.AddNewIngredient("Sugar", new Measurement(1f, Unit.pound));
			Pantry.AddNewIngredient("Baking Powder", new Measurement(24f, Unit.tablespoon));
			Pantry.AddNewIngredient("Salt", new Measurement(243.67f, Unit.kilogram));

			Assert.AreEqual(4, Pantry.Ingredients.Count);
		}
		//[TestMethod]
		//public void AddNewIngredientTest_IngredientCount()
		//{
		//	Pantry.Ingredients = new List<Ingredient>()
		//	{
		//		new Ingredient("Milk", new Measurement(1f, Unit.gallon)),
		//		new Ingredient("Sugar", new Measurement(1f, Unit.pound)),
		//		new Ingredient("Baking Powder", new Measurement(24f, Unit.tablespoon)),
		//		new Ingredient("Salt", new Measurement(243.67f, Unit.kilogram))
		//	};
		//	Assert.AreEqual(4, Pantry.Ingredients.Count);

		//	Pantry.RemoveIngredient(Pantry.Ingredients[2]);
		//	Assert.AreEqual(3, Pantry.Ingredients.Count);

		//	Pantry.RemoveIngredient(Pantry.Ingredients[2]);
		//	Assert.AreEqual(2, Pantry.Ingredients.Count);
		//}

		//    [TestMethod]
		//    public void ReadIngredientsFromFileTest()
		//    {
		//        Pantry p = new Pantry();
		//        var expectedResult = p.ingredients;
		//        p.ReadIngredientsFromFile();
		//        Assert.AreEqual(expectedResult, p.ingredients);
		//    }

		[TestMethod]
		public void RecipeNameSearchTest()
		{
			
		}

		[TestMethod]
		public void IngredientNameSearchTest()
		{
			Pantry.Ingredients = new List<Ingredient>()
			{
				new Ingredient("Milk", new Measurement(1f, Unit.gallon)),
				new Ingredient("Bleu Cheese Dressing", new Measurement(16.7f, Unit.ounce)),
				new Ingredient("Sugar", new Measurement(1f, Unit.pound)),
				new Ingredient("Baking Powder", new Measurement(24f, Unit.tablespoon)),
				new Ingredient("Shredded Cheese", new Measurement(12f, Unit.cup)),
				new Ingredient("Cheese", new Measurement(4.5f, Unit.cup)),
				new Ingredient("Salt", new Measurement(243.67f, Unit.kilogram))
			};

			string query = "cheese";
			List<Ingredient> results = Pantry.IngredientNameSearch(query);

			List<Ingredient> expectedResults = new List<Ingredient>()
			{
				new Ingredient("Bleu Cheese Dressing", new Measurement(16.7f, Unit.ounce)),
				new Ingredient("Shredded Cheese", new Measurement(12f, Unit.cup)),
				new Ingredient("Cheese", new Measurement(4.5f, Unit.cup)),
			};
			Assert.AreEqual(expectedResults, results);
		}
	}
}
