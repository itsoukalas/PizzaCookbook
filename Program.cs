
using System.Threading.Channels;

var pizzaRecipesApp = new PizzaRecipesApp();
pizzaRecipesApp.Run();





Pizza piza = new Pizza();
piza.AddIngredients(new Cheddar());
piza.AddIngredients(new Mozzarella());
piza.AddIngredients(new TomatosSauce());
piza.Describe();

//var ingredients = new List<Ingredient> {
//        new Cheddar(),
//        new Mozzarella(),
//    new TomatosSauce()
//    };

//foreach (Ingredient ingredient in ingredients)
//{
//    Console.WriteLine(ingredient.Name);
//}
Console.ReadKey();


public class Pizza
{
    private List<Ingredient> _ingredients = new List<Ingredient>();

    public void AddIngredients(Ingredient ingredient) =>
        _ingredients.Add(ingredient);

    public void Describe()
    {
        Console.WriteLine($"This is a pizza with {string.Join(",", _ingredients)}");
    }

}

public abstract class Ingredient
{
    public virtual string Name { get; } = "Some Ingredient";
    public override string ToString() => Name;
    public abstract void Prepare();
}


public abstract class Cheese : Ingredient
{

}


public class Cheddar : Cheese
{
    public override string Name => $"{base.Name} Cheddar cheese";

    public int AgedForMonths { get; }

    public override void Prepare()
    {
        throw new NotImplementedException();
    }
}

public class TomatosSauce : Ingredient
{
    public override string Name => "Tomato sauce";
    public int TomatosIn1000Grams { get; }

    public override void Prepare()
    {
        throw new NotImplementedException();
    }
}

public class Mozzarella : Ingredient
{
    public override string Name => "Mozzarella";
    public bool IsLight { get; }

    public override void Prepare() =>
    Console.WriteLine($"Slice thinkly and place on top of the pizza.");
}
