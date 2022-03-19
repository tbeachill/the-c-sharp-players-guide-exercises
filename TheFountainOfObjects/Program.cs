﻿new GameRunner();


public class GameRunner
{
    Map CurrentMap;
    Player CurrentPlayer = new Player();
    bool GameComplete = false;
    string[] Directions = { "north", "east", "south", "west" };

    public GameRunner()
    {
        // allow the user to select a map size
        ConsoleKey mapSelect;
        do
        {
            Console.WriteLine("Select a game size:\n1. Small\n2. Medium\n3. Large");
            mapSelect = Console.ReadKey().Key;
        }
        while (mapSelect != ConsoleKey.D1 && mapSelect != ConsoleKey.D2 && mapSelect != ConsoleKey.D3);

        // generate the map
        switch (mapSelect)
        {
            case ConsoleKey.D1:
                CurrentMap = new Map(4);
                CurrentPlayer.MapBound = 4;
                break;
            case ConsoleKey.D2:
                CurrentMap = new Map(6);
                CurrentPlayer.MapBound = 6;
                break;
            case ConsoleKey.D3:
                CurrentMap = new Map(8);
                CurrentPlayer.MapBound = 8;
                break;
        }

        // loop the game logic until the user wins
        while (GameComplete == false)
        {
            PrintLine();
            Console.WriteLine($"You are in the room at {CurrentPlayer.X}:{CurrentPlayer.Y}.");
            Console.WriteLine(CurrentMap.Rooms[CurrentPlayer.X, CurrentPlayer.Y].Description());

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
                CurrentMap.Rooms[CurrentPlayer.X, CurrentPlayer.Y].Interact();
            }
            else
            {
                Console.WriteLine("I don't know how to do that");
            }

            // winning conditions
            if (CurrentMap.Rooms[CurrentMap.FountainPos.X, CurrentMap.FountainPos.Y].Contents.IsEnabled == true &&
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
    public Room[,] Rooms { get; }
    public Coord FountainPos { get; }
    public Coord[] Coords { get; } = new Coord[1];

    public Map (int mapSize)
    {
        // generate a new map of rooms with a specified size

        Rooms = new Room[mapSize, mapSize];

        // Pick random positions for the features and ensure they don't overlap
        Random r = new Random();
        for (int i = 0; i < 1; i++)
        {
            int x;
            int y;
            bool inCoords;
            do
            {
                x = r.Next(0, mapSize - 1);
                y = r.Next(0, mapSize - 1);

                inCoords = false;
                foreach (Coord c in Coords)
                {
                    if (c.X == x && c.Y == y)
                        inCoords = true;
                }
            }
            while (inCoords == true);
            Coords[i].X = x;
            Coords[i].Y = y;
        }

        // generate the map
        for (int y = 0; y < mapSize; y++)
        {
            for (int x = 0; x < mapSize; x++)
            {
                // populate rooms with features
                if (x == 0 && y == 0)
                {
                    Rooms[x, y] = new Room(x, y, new Entrance());
                }
                else if (x == Coords[0].X && y == Coords[0].Y)
                {
                    Rooms[x, y] = new Room(x, y, new FountainOfObjects());
                    FountainPos = new Coord(x, y);
                }
                else
                {
                    Rooms[x, y] = new Room(x, y, new MapFeature());
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
    public int MapBound { get; set; }

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
        if (player.Y < player.MapBound)
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
        if (player.X < player.MapBound)
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

public struct Coord
{
    public int X = 0;
    public int Y = 0;

    public Coord(int x, int y)
    {
        X = x; Y = y;
    }
}
