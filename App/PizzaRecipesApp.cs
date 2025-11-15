using Pizza_Cookbook.Interfaces;
using Pizza_Cookbook.Recipes;

namespace Pizza_Cookbook.App
{
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
            var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

            if (ingredients.Count() > 0)
            {
                var recipe = new Recipe(ingredients);
                allRecipes.Add(recipe);
                _recipesRepository.Write(filePath, allRecipes);
                _recipesUserInteraction.ShowMessage(recipe.ToString());
            }
            else
            {
                _recipesUserInteraction.ShowMessage(
                    "No ingredient have been selected" +
                    "Recipe will not be saved");
            }
            _recipesUserInteraction.Exit();
        }
    }
}




