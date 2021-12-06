using System;

Console.Write("X value: ");
int xVal = Convert.ToInt32(Console.ReadLine());

Console.Write("Y value: ");
int yVal = Convert.ToInt32(Console.ReadLine());

string direction = "?";

if (xVal < 0 && yVal > 0)
{
    direction = "NW";
}
else if (xVal < 0 && yVal == 0)
{
    direction = "W";
}
else if (xVal < 0 && yVal < 0)
{
    direction = "SW";
}
else if (xVal == 0 && yVal > 0)
{
    direction = "N";
}
else if (xVal == 0 && yVal == 0)
{
    direction = "!";
}
else if (xVal == 0 && yVal < 0)
{
    direction = "S";
}
else if (xVal > 0 && yVal > 0)
{
    direction = "NE";
}
else if (xVal > 0 && yVal == 0)
{
    direction = "E";
}
else if (xVal > 0 && yVal < 0)
{
    direction = "SE";
}

Console.WriteLine("\n" + direction);