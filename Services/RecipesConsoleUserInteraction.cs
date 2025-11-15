using Pizza_Cookbook.Interfaces;
using Pizza_Cookbook.Recipes;
using Pizza_Cookbook.Recipes.Ingredients;

namespace Pizza_Cookbook.Services
{
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
                Console.WriteLine("Existing recipes are: " + Environment.NewLine);
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

        public IEnumerable<Ingredient> ReadIngredientsFromUser()
        {
            bool shallStop = false;
            var ingredients = new List<Ingredient>();

            while (!shallStop)
            {
                Console.WriteLine("Add an ingredient by its ID," +
                    "or type anything else if finished.");

                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int id))
                {
                    var selectedIngrdient = _ingredientRegister.GetById(id);
                    if (selectedIngrdient is not null)
                    {
                        ingredients.Add(selectedIngrdient);
                    }
                }
                else
                { shallStop = true; }
                
            }
            return ingredients;
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

        public Ingredient GetById(int id)
        {
            foreach (var ingredient in All)
            {
                if(ingredient.Id==id)
                    return ingredient;
            }
            return null;
        }
    }




}


