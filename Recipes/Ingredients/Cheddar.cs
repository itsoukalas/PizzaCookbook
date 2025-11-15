namespace Pizza_Cookbook.Recipes.Ingredients
{
    public class Cheddar : Cheese
    {
        public override string Name => "Cheddar cheese";

        public int AgedForMonths { get; }

        public override int Id { get; } = 1;
        public override string PreparationInstuctions =>
            $"Cheddar {base.PreparationInstuctions}";


    }
}






