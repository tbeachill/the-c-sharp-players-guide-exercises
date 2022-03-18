// set up items
ColoredItem<Sword> blueSword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
ColoredItem<Bow> redBow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
ColoredItem<Axe> greenAxe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);

// print out the items in the color of the item
Console.WriteLine("Items:");
blueSword.Display();
redBow.Display();
greenAxe.Display();
Console.ForegroundColor = ConsoleColor.White;

// item classes
public class Sword { }
public class Bow { }
public class Axe { }

// colored item generic for storing an item with a color
public class ColoredItem<T>
{
    public T Item { get; }
    public ConsoleColor Color { get; }

    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item);
    }
}
