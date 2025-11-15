using Pizza_Cookbook.Services;
using Pizza_Cookbook.App;

var pizzaRecipesApp = new PizzaRecipesApp(
    new RecipesRepository(new StringsTextualRepository()),
    new RecipesConsoleUserInteraction(
        new IngredientsRegister()
        ));

pizzaRecipesApp.Run("test");


Console.ReadKey();






