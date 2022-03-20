/*
 * A game in which the player has to navigate a dark cavern by description of senses
 * find the fountain of objects, activate it, then return to the cavern entrance
 * while avoiding obstacles.
*/

namespace TheFountainOfObjects
{
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

            // record the current time
            DateTime startTime = DateTime.Now;

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

                // losing conditions
                if (CurrentMap.Rooms[CurrentPlayer.X, CurrentPlayer.Y].Contents.Name == "Pit")
                {
                    Console.WriteLine("\nYou fall into a bottomless pit.");
                    Console.WriteLine("You are dead.");
                    GameComplete = true;
                }

                // winning conditions
                if (CurrentMap.Rooms[CurrentMap.FountainPos.X, CurrentMap.FountainPos.Y].Contents.IsEnabled == true &&
                    CurrentPlayer.X == 0 && CurrentPlayer.Y == 0)
                {
                    PrintLine();
                    Console.WriteLine("You have won!");
                    GameComplete = true;
                }
            }

            TimeSpan gameTime = DateTime.Now - startTime;
            Console.WriteLine($"The game lasted {gameTime.Minutes}m{gameTime.Seconds}s.");
        }

        private void PrintLine()
        {
            Console.WriteLine("----------------------------------------------");
        }
    }
}
