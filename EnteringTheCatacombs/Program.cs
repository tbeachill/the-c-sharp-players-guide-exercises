Point pointOne = new Point(2, 3);
Point pointTwo = new Point(-4, 0);

Console.WriteLine("Point 1: (" + pointOne.x + "," + pointOne.y + ")");
Console.WriteLine("Point 2: (" + pointTwo.x + "," + pointTwo.y + ")");
public class Point
{
    public float x { get; set; }
    public float y { get; set; }

    public Point(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public Point()
    {
        this.x = 0;
        this.y = 0;
    }
}