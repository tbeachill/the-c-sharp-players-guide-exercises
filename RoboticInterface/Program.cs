Robot newRobot = new Robot();

// Get three commands from the user
for (int i = 0; i < 3; i++)
{
    Console.Write($"Command {i + 1}: ");
    string input = Console.ReadLine();

    newRobot.Commands[i] = input.ToLower() switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "east" => new EastCommand(),
        "south" => new SouthCommand(),
        "west" => new WestCommand(),
    };
}

Console.WriteLine();
newRobot.Run();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand[] Commands { get; } = new IRobotCommand[3];

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