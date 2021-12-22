Arrow arrow = GetArrow();
Console.WriteLine($"\nThat arrow cost {arrow.GetCost()} gold.");
Console.WriteLine($"\nThat arrow has a length of {arrow.Length} an arrowhead made of {arrow.ArrowheadType} and a fletching made of {arrow.FletchingType}");

Arrow GetArrow()
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