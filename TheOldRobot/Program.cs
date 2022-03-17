Robot newRobot = new Robot();

// Get three commands from the user
for (int i = 0; i < 3; i++)
{
    Console.Write($"Command {i+1}: ");
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
    public RobotCommand[] Commands { get; } = new RobotCommand[3];

    public void Run()
    {
        foreach (RobotCommand command in Commands)
        {
            command.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    // Base class for controlling the robot

    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    // Turn on the robot

    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    // Turn off the robot

    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    // Move the robot north if it is powered on

    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y += 1;
    }
}

public class EastCommand : RobotCommand
{
    // Move the robot east if it is powered on

    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X += 1;
    }
}

public class SouthCommand : RobotCommand
{
    // Move the robot south if it is powered on

    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y -= 1;
    }
}

public class WestCommand : RobotCommand
{
    // Move the robot west if it is powered on

    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X -= 1;
    }
}
