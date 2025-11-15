using Pizza_Cookbook.Recipes;
using Pizza_Cookbook.Recipes.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Cookbook.Interfaces
{
    public interface IRecipeUserInteraction
    {
        void ShowMessage(string message);
        void Exit();
        void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
        void PromptToCreateRecipe();
        IEnumerable<Ingredient> ReadIngredientsFromUser();
    }

    public interface IRecipesRepository
    {
        List<Recipe> Read(string filePath);
        void Write(string filePath, List<Recipe> allRecipes);
    }


    public interface IStringsReposirory
    {
        List<string> Read(string filePath);
        void Write(string filePath, List<string> strings);
    }
}
