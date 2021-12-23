Colour newColour = new Colour(2, 200, 20);
Colour fixedColour = Colour.Orange;

Console.WriteLine($"R={newColour.R} G={newColour.G} B={newColour.B}");
Console.WriteLine($"R={fixedColour.R} G={fixedColour.G} B={fixedColour.B}");

public class Colour
{
    public byte R;
    public byte G;
    public byte B;

    public Colour(byte r, byte g, byte b)
    {
        this.R = r;
        this.G = g;
        this.B = b;
    }

    public static Colour White { get; } = new Colour(255, 255, 255);
    public static Colour Black { get; } = new Colour(0, 0, 0);
    public static Colour Red { get; } = new Colour(255, 0, 0);
    public static Colour Orange { get; } = new Colour(255, 165, 0);
    public static Colour Yellow { get; } = new Colour(255, 255, 0);
    public static Colour Green { get; } = new Colour(0, 128, 0);
    public static Colour Blue { get; } = new Colour(0, 0, 255);
    public static Colour Purple { get; } = new Colour(128, 0, 128);
}