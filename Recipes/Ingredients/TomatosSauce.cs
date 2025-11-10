namespace Pizza_Cookbook.Recipes.Ingredients
{
    public class TomatosSauce : Ingredient
    {
        public override string Name => "Tomato sauce";
        public int TomatosIn1000Grams { get; }

        public override int Id { get; } = 3;

        public override string PreparationInstuctions => "Tomato";


    }
}






