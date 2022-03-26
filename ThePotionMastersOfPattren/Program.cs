while (true)
{
    // create a new potion
    Potion currentPotion = new Potion();

    // loop while the potion is not ruined
    while (currentPotion.Type != Potions.Ruined)
    {
        Console.Clear();

        if (currentPotion.Type != Potions.None)
            Console.WriteLine($"You currently have a {currentPotion.Type} potion.");
        else
            Console.WriteLine($"You currently have water.");

        Console.Write("Do you want to add more ingredients? ");
        // break out of the loop and finish if the user selects no
        string input = Console.ReadLine().ToLower();
        if (input == "no" || input == "n")
            break;

        // keep prompting for ingredient until a valid choice is made
        Ingredients ingredient = Ingredients.None;
        do
        {
            ingredient = GetIngredient();
        }
        while (ingredient == Ingredients.None);

        // add ingredient to the potion
        currentPotion.Add(ingredient);
    }

    if (currentPotion.Type != Potions.None)
        Console.WriteLine($"\nYou have made a {currentPotion.Type} potion.\n\nPress any key to start again.");
    else
        Console.WriteLine($"\nYou have nothing but water.\n\nPress any key to start again.");

    Console.ReadKey();
}


Ingredients GetIngredient()
{
    // get an input from the user and turn it into an ingredient

    Console.WriteLine("What do you want to add?\n1. Stardust\n2. Snake venom\n3. Dragon breath\n4. Shadow glass\n5. Eyeshine gem");
    string input = Console.ReadLine();
    return input.ToLower() switch
    {
        "stardust"      or "1" => Ingredients.Stardust,
        "snake venom"   or "2" => Ingredients.SnakeVenom,
        "dragon breath" or "3" => Ingredients.DragonBreath,
        "shadow glass"  or "4" => Ingredients.ShadowGlass,
        "eyeshine gem"  or "5" => Ingredients.EyeshineGem,
        _                      => Ingredients.None
    };
}

public class Potion
{
    public List<Ingredients> Contains { get; } = new List<Ingredients> { Ingredients.Water };
    public Potions Type { get; set; } = Potions.None;

    public void Add(Ingredients ingredient)
    {
        // add the ingredient to the Contains list and mix the ingredient
        Contains.Add(ingredient);
        Mix(ingredient);
    }

    private void Mix(Ingredients ingredient)
    {
        // change the potions type according to its current type and ingredient added
        Type = (Type, ingredient) switch
        {
            (Potions.None, Ingredients.Stardust)            => Potions.Elixir,
            (Potions.Elixir, Ingredients.SnakeVenom)        => Potions.Poison,
            (Potions.Elixir, Ingredients.DragonBreath)      => Potions.Flying,
            (Potions.Elixir, Ingredients.ShadowGlass)       => Potions.Invisibility,
            (Potions.Elixir, Ingredients.EyeshineGem)       => Potions.NightSight,
            (Potions.NightSight, Ingredients.ShadowGlass)   => Potions.CloudyBrew,
            (Potions.Invisibility, Ingredients.EyeshineGem) => Potions.CloudyBrew,
            (Potions.CloudyBrew, Ingredients.Stardust)      => Potions.Wraith,
            (_, _)                                          => Potions.Ruined
        };
    }
}

public enum Ingredients { None, Water, Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem }
public enum Potions { None, Elixir, Poison, Flying, Invisibility, NightSight, CloudyBrew, Wraith, Ruined }
