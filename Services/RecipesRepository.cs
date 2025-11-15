using Pizza_Cookbook.Interfaces;
using Pizza_Cookbook.Recipes;
using Pizza_Cookbook.Recipes.Ingredients;

namespace Pizza_Cookbook.Services
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly IStringsReposirory _stringsReposiroryy;
        public RecipesRepository(IStringsReposirory stringsReposiroryy)
        {
            _stringsReposiroryy = stringsReposiroryy;
        }
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

        public void Write(string filePath, List<Recipe> allRecipes)
        {
            var recipesAsStrings= new List<string>();   
            foreach (var recipe in allRecipes)
            {
                var allIds=new List<int>();
                foreach(var ingredient in recipe.Ingredients)
                {
                    allIds.Add(ingredient.Id);
                }
            }
            _stringsReposiroryy.Write(filePath, recipesAsStrings);
        }
    }

    class StringsTextualRepository : IStringsReposirory
    {
        private static readonly string Separator = Environment.NewLine;

        public List<string> Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileContents = File.ReadAllText(filePath);
                return fileContents.Split(Separator).ToList();
            }
            return new List<string>();
        }

        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, string.Join(Separator, strings));
        }
    }
}







