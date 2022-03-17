Pack newPack = new Pack(10, 20, 30);

while (true)
{
    InventoryItem a;
    // Display the menu of items
    Console.WriteLine("Select an item to add to the pack\n1. Arrow\n2. Bow\n3. Rope\n4. Water\n5. Food\n6. Sword");

    // Keep waiting for a selection until a valid selection is made and an item object is passed back
    do
    {
        a = SelectItem();
    } while (!(a is Arrow || a is Bow || a is Rope || a is Water || a is Food || a is Sword));

    Console.Clear();

    if (newPack.Add(a))
    {
        // If the item has been successfully added
        Console.WriteLine($"{a} has been added. {newPack.ToString()}");
    }
    else
    {
        // If the item could not fit in the pack
        Console.WriteLine($"{a} can not be added. The pack has {newPack.MaxCount - newPack.CurrentCount} places left. " +
            $"Remaining weight of {(newPack.MaxWeight - newPack.CurrentWeight).ToString("n2")} " +
            $"and remaining volume of {(newPack.MaxVolume - newPack.CurrentVolume).ToString("n2")}");
    }

    Console.WriteLine();
}

InventoryItem SelectItem()
{
    // Allows the user to make a menu selection using the number keys or numpad keys and returns a new object

    ConsoleKey input;
    input = Console.ReadKey().Key;

    return input switch
    {
        ConsoleKey.D1 => new Arrow(),
        ConsoleKey.NumPad1 => new Arrow(),
        ConsoleKey.D2 => new Bow(),
        ConsoleKey.NumPad2 => new Bow(),
        ConsoleKey.D3 => new Rope(),
        ConsoleKey.NumPad3 => new Rope(),
        ConsoleKey.D4 => new Water(),
        ConsoleKey.NumPad4 => new Water(),
        ConsoleKey.D5 => new Food(),
        ConsoleKey.NumPad5 => new Food(),
        ConsoleKey.D6 => new Sword(),
        ConsoleKey.NumPad6 => new Sword(),
        _ => new InventoryItem(1, 1)
    };
}

public class InventoryItem
{
    // Base class for an item

    public double Weight { get; }
    public double Volume { get; }

    public InventoryItem(double weight, double volume)
    {
        this.Weight = weight;
        this.Volume = volume;
    }
}

public class Pack
{
    // Pack for containing items

    public InventoryItem[] Contents { get; }
    public int MaxCount { get; }
    public double MaxWeight { get; }
    public double MaxVolume { get; }

    public int CurrentCount { get; set; }
    public double CurrentWeight { get; set; }
    public double CurrentVolume { get; set; }

    public Pack(int total, double maxWeight, double maxVolume)
    {
        this.MaxCount = total;
        this.MaxWeight = maxWeight;
        this.MaxVolume = maxVolume;
        this.Contents = new InventoryItem[MaxCount];
    }

    public bool Add(InventoryItem item)
    {
        // If adding the item does not exceed the max weight, volume, or item capacity, add the item

        if (CurrentWeight + item.Weight > MaxWeight ||
            CurrentVolume + item.Volume > MaxVolume ||
            CurrentCount + 1 > MaxCount)
        {
            return false;
        }

        Contents[CurrentCount] = item;
        CurrentWeight += item.Weight;
        CurrentVolume += item.Volume;
        CurrentCount++;

        return true;
    }

    public override string ToString()
    {
        string _contents = "Pack containing ";

        if (CurrentCount == 0)
        {
            _contents += "nothing.";
        }
        else
        {
            for (int i = 0; i < CurrentCount; i++)
            {
                _contents += Contents[i].ToString();
                if (i != CurrentCount - 1) _contents += " ";
            }

            _contents += ".";
        }

        return _contents;
    }
}

// Item classes - derived from the base class InventoryItem
public class Arrow : InventoryItem {
    public Arrow() : base(0.1, 0.05) { }

    public override string ToString() => "Arrow";
}

public class Bow : InventoryItem {
    public Bow() : base(1, 4) { }

    public override string ToString() => "Bow";
}

public class Rope : InventoryItem {
    public Rope() : base(1, 1.5) { }

    public override string ToString() => "Rope";
}

public class Water : InventoryItem {
    public Water() : base(2, 3) { }

    public override string ToString() => "Water";
}

public class Food : InventoryItem {
    public Food() : base(1, 0.5) { }

    public override string ToString() => "Food";
}

public class Sword : InventoryItem {
    public Sword() : base(5, 3) { }

    public override string ToString() => "Sword";
}