using System.Dynamic;

int ID = 1;

while (true)
{
    Console.ForegroundColor = ConsoleColor.White;

    // create a new ExpandoObject and set the current ID
    dynamic robot = new ExpandoObject();
    robot.ID = ID;
    Console.WriteLine($"You are producing robot #{ID}");

    // ask if various properties are to be set and apply them to the robot object
    Console.Write("Do you want to name this robot? ");
    if (Console.ReadLine() == "yes")
    {
        Console.Write("What is its name? ");
        robot.Name = Console.ReadLine();
    }
    Console.Write("Does this robot have a specific size? ");
    if (Console.ReadLine() == "yes")
    {
        Console.Write("What is its height? ");
        robot.Height = Console.ReadLine();
        Console.Write("What is its width? ");
        robot.Width = Console.ReadLine();
    }
    Console.Write("Does this robot need to be a specific color? ");
    if (Console.ReadLine() == "yes")
    {
        Console.Write("What color? ");
        robot.Color = Console.ReadLine();
    }

    Console.ForegroundColor = ConsoleColor.Yellow;

    // print out each property of the robot
    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
    {
        Console.WriteLine($"{property.Key}: {property.Value}");
    }

    ID++;
}
