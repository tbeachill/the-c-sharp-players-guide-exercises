(SoupType, MainIngredient, Seasoning)[] soupList = new (SoupType, MainIngredient, Seasoning)[3];

for (int i = 0; i < 3; i++)
{
    if (i != 0)
    {
        Console.WriteLine();
    }
    
    Console.WriteLine($"Soup {i+1}:");
    (SoupType, MainIngredient, Seasoning) soup = GetSoup();
    soupList[i] = soup;
}

Console.WriteLine("\nSoups:");
foreach ((SoupType, MainIngredient, Seasoning) soup in soupList)
{
    Console.WriteLine($"{soup.Item3} {soup.Item2} {soup.Item1}");
}

(SoupType, MainIngredient, Seasoning) GetSoup()
{
    SoupType type = GetSoupType();
    MainIngredient ingredient = GetMainIngredient();
    Seasoning seasoning = GetSeasoning();

    return (type, ingredient, seasoning);
}

SoupType GetSoupType()
{
    Console.Write("Soup type (soup, stew, gumbo) ");
    string input = Console.ReadLine();
    return input switch
    {
        "soup" => SoupType.Soup,
        "stew" => SoupType.Stew,
        "gumbo" => SoupType.Gumbo,
        _ => throw new ArgumentOutOfRangeException(nameof(input), $"Not expected input value: {input}"),
    };
}

MainIngredient GetMainIngredient()
{
    Console.Write("Main ingredient (mushrooms, chicken, carrots, potatoes) ");
    string input = Console.ReadLine();
    return input switch
    {
        "mushrooms" => MainIngredient.Mushroom,
        "chicken" => MainIngredient.Chicken,
        "carrots" => MainIngredient.Carrot,
        "potatoes" => MainIngredient.Potato,
        _ => throw new ArgumentOutOfRangeException(nameof(input), $"Not expected input value: {input}"),
    };
}

Seasoning GetSeasoning()
{
    Console.Write("Seasoning (spicy, salty, sweet) ");
    string input = Console.ReadLine();
    return input switch
    {
        "spicy" => Seasoning.Spicy,
        "salty" => Seasoning.Salty,
        "sweet" => Seasoning.Sweet,
        _ => throw new ArgumentOutOfRangeException(nameof(input), $"Not expected input value: {input}"),
    };
}

enum SoupType { Soup, Stew, Gumbo };
enum MainIngredient { Mushroom, Chicken, Carrot, Potato };
enum Seasoning { Spicy, Salty, Sweet };
