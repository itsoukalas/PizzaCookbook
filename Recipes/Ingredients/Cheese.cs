
namespace Pizza_Cookbook.Recipes.Ingredients
{
    public abstract class Cheese:Ingredient
    {
        public override string PreparationInstuctions =>
          $"Sieve. {base.PreparationInstuctions}";
    }
}






