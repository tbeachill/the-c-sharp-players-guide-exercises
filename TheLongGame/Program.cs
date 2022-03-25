// ask the player for their name and create a new player object
string username;

do
{
    Console.Write("Enter your name: ");
    username = Console.ReadLine();
}
while (username == "");
Player player = new Player(username);

Console.WriteLine("Press keys. Esc to stop");

// add 1 to the score every key press until Esc is pressed
while (true)
{
    if (Console.ReadKey().Key == ConsoleKey.Escape)
    {
        // write the current score to a file with the players name as filename
        File.WriteAllText(player.Name + ".txt", Convert.ToString(player.Score));
        System.Environment.Exit(0);
    }
    else
    {
        player.Score++;
    }
}


public class Player
{
    public string Name { get; set; }
    public int Score { get; set; }

    public Player(string name)
    {
        // set the players name
        this.Name = name;

        // check for a previously saved score and load if exists
        if (File.Exists(Name + ".txt"))
            this.Score = Convert.ToInt32(File.ReadAllText(Name + ".txt"));
        else
            this.Score = 0;
    }
}
