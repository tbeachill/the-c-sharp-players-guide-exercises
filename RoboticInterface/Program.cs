Robot newRobot = new Robot();

bool finished = false;
// Get three commands from the user
while (finished == false)
{
    Console.Write($"Enter command: ");
    string input = Console.ReadLine();

    if (input == "stop")
    {
        finished = true;
        break;
    }

    newRobot.Commands.Add( input.ToLower() switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "east" => new EastCommand(),
        "south" => new SouthCommand(),
        "west" => new WestCommand(),
    });
}

Console.WriteLine();
newRobot.Run();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand> Commands { get; } = new List<IRobotCommand>();

    public void Run()
    {
        foreach (IRobotCommand command in Commands)
        {
            command.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    // Interface for controlling the robot

    void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    // Turn on the robot

    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    // Turn off the robot

    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    // Move the robot north if it is powered on

    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y += 1;
    }
}

public class EastCommand : IRobotCommand
{
    // Move the robot east if it is powered on

    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X += 1;
    }
}

public class SouthCommand : IRobotCommand
{
    // Move the robot south if it is powered on

    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y -= 1;
    }
}

public class WestCommand : IRobotCommand
{
    // Move the robot west if it is powered on

    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X -= 1;
    }
}