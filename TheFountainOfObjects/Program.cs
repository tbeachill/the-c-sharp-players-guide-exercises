new GameRunner();


public class GameRunner
{
    Map CurrentMap = new Map();
    Player CurrentPlayer = new Player();
    bool GameComplete = false;
    string[] Directions = { "north", "east", "south", "west" };

    public GameRunner()
    {
        while (GameComplete == false)
        {
            PrintLine();
            Console.WriteLine($"You are in the room at {CurrentPlayer.X}:{CurrentPlayer.Y}.");
            Console.WriteLine(CurrentMap.rooms[CurrentPlayer.X, CurrentPlayer.Y].Description());

            // get an action from the player
            Console.Write("What do you want to do? ");
            string[] input = Console.ReadLine().ToLower().Split(" ");
            
            // determine what type of action the player is performing
            if (input[0] == "move")
            {
                if (input.Length > 1)
                {
                    // if a valid direction is specified, move in that direction
                    if (Array.Exists(Directions, element => element == input[1]))
                    {
                        CurrentPlayer.Move(input[1] switch
                        {
                            "north" => new MoveNorth(),
                            "east" => new MoveEast(),
                            "south" => new MoveSouth(),
                            "west" => new MoveWest(),
                        });
                    }
                    else
                    {
                        Console.WriteLine("I can't go in that direction.");
                    }
                }
                else
                {
                    // if no direction is specified
                    Console.WriteLine("Specify a direction to go in (north, east, south, west).");
                }
            }
            else if (input[0] == "interact")
            {
                // interact with the contents of the current room
                CurrentMap.rooms[CurrentPlayer.X, CurrentPlayer.Y].Interact();
            }
            else
            {
                Console.WriteLine("I don't know how to do that");
            }

            // winning conditions
            if (CurrentMap.rooms[CurrentMap.FountainPos[0], CurrentMap.FountainPos[1]].Contents.IsEnabled == true &&
                CurrentPlayer.X == 0 && CurrentPlayer.Y == 0)
            {
                GameComplete = true;
            }
        }

        PrintLine();
        Console.WriteLine("You have won!");
    }

    private void PrintLine()
    {
        Console.WriteLine("----------------------------------------------");
    }
}


public class Map
{
    public Room[,] rooms { get; } = new Room[4,4];
    public int[] FountainPos = new int[2];

    public Map()
    {
        // generate a new map of rooms

        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                // populate rooms with features
                if (x == 0 && y == 0)
                {
                    rooms[x, y] = new Room(x, y, new Entrance());
                }
                else if (x == 2 && y == 0)
                {
                    rooms[x, y] = new Room(x, y, new FountainOfObjects());
                    (FountainPos[0], FountainPos[1]) = (x, y);
                }
                else
                {
                    rooms[x, y] = new Room(x, y, new MapFeature());
                }
            }
        }
    }
}


public struct Room
{
    public int X { get; }
    public int Y { get; }
    public dynamic Contents { get; }

    public Room(int x, int y, MapFeature contents)
    {
        X = x; Y = y; Contents = contents;
    }

    public static bool AreAdjacent(Room a, Room b)
    {
        // check if two given rooms are adjacent

        int xDiff = a.X - b.X;
        int yDiff = a.Y - b.Y;

        if ((Math.Abs(xDiff) == 1 && yDiff == 0) || (Math.Abs(yDiff) == 1 && xDiff == 0))
        {
            return true;
        }

        return false;
    }

    public string Description()
    {
        // return the description of the room contents
        return Contents.Description;
    }

    public void Interact()
    {
        // return the result of interacting with the rooms contents
       Contents.Interact();
    }
}


public class MapFeature
{
    public string Description = "You can't see anything.";
    public bool IsEnabled = false;
    
    public virtual void Interact()
    {
        Console.WriteLine("There is nothing to interact with.");
    }
}


public class FountainOfObjects : MapFeature
{
    public new string Description = "The fountain of objects is here!";
    public new bool IsEnabled = false;

    public override void Interact()
    {
        // turn the fountain of objects on or off

        if (IsEnabled == false)
        {
            IsEnabled = true;
            Console.WriteLine("You hear rushing waters from the Fountain of Objects. It has been enabled.");
        }
        else
        {
            IsEnabled = false;
            Console.WriteLine("The water stops rushing from the Fountain of Objects. It has been disabled.");
        }
    }
}


public class Entrance : MapFeature
{
    public new string Description = "You see light coming from the cavern entrance.";
}


public class Player
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;

    public void Move(PlayerMove command)
    {
            command.Move(this);
    }
}


public abstract class PlayerMove
{
    // base class for player movement

    public abstract void Move(Player player);
}


public class MoveNorth : PlayerMove
{
    // move the player north

    public override void Move(Player player)
    {
        if (player.Y < 3)
        {
            player.Y += 1;
        }
        else
        {
            Console.WriteLine("You cant move any further in that direction.");
        }
    }
}


public class MoveEast : PlayerMove
{
    // move the player east

    public override void Move(Player player)
    {
        if (player.X < 3)
        {
            player.X += 1;
        }
        else
        {
            Console.WriteLine("You cant move any further in that direction.");
        }
    }
}


public class MoveSouth : PlayerMove
{
    // move the player south

    public override void Move(Player player)
    {
        if (player.Y > 0)
        {
            player.Y -= 1;
        }
        else
        {
            Console.WriteLine("You cant move any further in that direction.");
        }
    }
}


public class MoveWest : PlayerMove
{
    // move the player west

    public override void Move(Player player)
    {
        if (player.X > 0)
        {
            player.X -= 1;
        }
        else
        {
            Console.WriteLine("You cant move any further in that direction.");
        }
    }
}
