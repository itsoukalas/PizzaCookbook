namespace Pizza_Cookbook.Recipes.Ingredients
{
    public class Mozzarella : Cheese
    {
        public override string Name => "Mozzarella";
        public bool IsLight { get; }

        public override int Id { get; } = 2;

        public override string PreparationInstuctions => "Slice thinkly and place on top of the pizza.";
    }
}






