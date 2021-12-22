Arrow arrow = GetArrow();
Console.WriteLine($"\nThat arrow cost {arrow.GetCost()} gold.");
Console.WriteLine($"\nThat arrow has a length of {arrow.Length} an arrowhead made of {arrow.ArrowheadType} and a fletching made of {arrow.FletchingType}.");

Arrow GetArrow()
{
    string input = "";

    while (input != "1" && input != "2" && input != "3" && input != "4")
    {
        Console.WriteLine(input);
        Console.WriteLine("What kind of arrow do you want?\n1. Elite Arrow\n2. Beginner Arrow\n3. Marksman Arrow\n4. Custom Arrow");
        input = Console.ReadLine();
    }

    return input switch
    {
            "1" => Arrow.CreateEliteArrow(),
            "2" => Arrow.CreateBeginnerArrow(),
            "3" => Arrow.CreateMarksmanArrow(),
            "4" => GetCustomArrow()
    };
}

Arrow GetCustomArrow()
{
    Arrowhead arrowhead = GetArrowhead();
    Fletching fletching = GetFletching();
    float length = GetLength();

    return new Arrow(arrowhead, fletching, length);
}

Arrowhead GetArrowhead()
{
    string input = "";

    while (input != "steel" && input != "wood" && input != "obsidian")
    {
        Console.Write("Arrowhead type (steel, wood, obsidian) ");
        input = Console.ReadLine().ToLower();
    }

    return input switch
    {
        "steel" => Arrowhead.Steel,
        "wood" => Arrowhead.Wood,
        "obsidian" => Arrowhead.Obsidian
    };
}

Fletching GetFletching()
{
    string input = "";

    while (input != "turkey" && input != "goose" && input != "plastic")
    {
        Console.Write("Fletching type (plastic, turkey, goose) ");
        input = Console.ReadLine().ToLower();
    }

    return input switch
    {
        "turkey" => Fletching.TurkeyFeathers,
        "goose" => Fletching.GooseFeathers,
        "plastic" => Fletching.Plastic
    };
}

float GetLength()
{
    float input = 0;

    while (input < 60 || input > 100)
    {
        Console.Write("Shaft length (60-100) ");
        input = Convert.ToSingle(Console.ReadLine());
    }

    return input;
}

class Arrow
{
    public float Length { get; set; }
    public Arrowhead ArrowheadType { get; set; }
    public Fletching FletchingType { get; set; }

    public Arrow(Arrowhead arrowheadType, Fletching fletchingType, float length)
    {
        this.ArrowheadType = arrowheadType;
        this.FletchingType = fletchingType;
        this.Length = length;
    }

    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, Fletching.Plastic, 95);
    public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75);
    public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Steel, Fletching.GooseFeathers, 65);

    public float GetCost()
    {
        float arrowheadCost = this.ArrowheadType switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5
        };

        float fletchingCost = this.FletchingType switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3
        };

        float shaftCost = 0.05f * this.Length;

        return arrowheadCost + fletchingCost + shaftCost;
    }
}

public enum Arrowhead { Steel, Wood, Obsidian }
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }