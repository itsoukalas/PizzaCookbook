
using Pizza_Cookbook.Recipes;
using Pizza_Cookbook.Recipes.Ingredients;


var pizzaRecipesApp = new PizzaRecipesApp(
    new RecipesRepository(),
    new RecipesConsoleUserInteraction(
        new IngredientsRegister()
        ));

pizzaRecipesApp.Run("test");



Console.ReadKey();

public class PizzaRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipeUserInteraction _recipesUserInteraction;

    public PizzaRecipesApp(IRecipesRepository recipesRepository, IRecipeUserInteraction recipesConsoleUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesConsoleUserInteraction;
    }

    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);
        _recipesUserInteraction.PromptToCreateRecipe();
        //var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        //if (ingredients.Count > 0)
        //{
        //    var recipe = new Recipe(ingredients);
        //    allRecipes.add(recipe);
        //    _recipesRepository.Write(filePath, allRecipes);
        //    _recipesUserInteraction.ShowMessage(recipe.ToString());
        //}
        //else
        //{
        //    _recipesUserInteraction.ShowMessage(
        //        "No ingredient have been selected" +
        //        "Recipe will not be saved");
        //}
        _recipesUserInteraction.Exit();
    }
}

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
}

public interface IRecipeUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
}

public class RecipesConsoleUserInteraction : IRecipeUserInteraction
{
    private readonly IngredientsRegister _ingredientRegister;

    public RecipesConsoleUserInteraction(IngredientsRegister ingredientsRegister)
    {
        _ingredientRegister = ingredientsRegister;
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existring recipes are: " + Environment.NewLine);
            int recipeIndex = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"***** {recipeIndex}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                recipeIndex++;
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new pizza recipe!" +
            "Available ingredients are: ");
        foreach (var ingredient in _ingredientRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    public void ShowMessage(string v)
    {
        Console.WriteLine(v);
    }
}

public class IngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
    new Cheddar(),
    new Mozzarella(),
    new TomatosSauce(),
    };
}

public class RecipesRepository : IRecipesRepository
{
    public List<Recipe> Read(string filePath)
    {
        return new List<Recipe> {
        new Recipe(new List<Ingredient>
        {
            new Cheddar(),
            new TomatosSauce()
        }),
        new Recipe(new List<Ingredient>
        {
            new Cheddar(),
            new Mozzarella()
        })
        };

    }
}






