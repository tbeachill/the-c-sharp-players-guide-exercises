Console.Write("Player 1 enter your name: ");
Player player1 = new Player(Console.ReadLine());
Console.Write("Player 2 enter your name: ");
Player player2 = new Player(Console.ReadLine());
Round currentRound = new Round();

while (true)
{
    currentRound.NewRound(player1, player2, currentRound);
}

public class Player
{
    public Int32 Wins { get; set; }
    public string Name { get; }
    public Hand PlayedHand { get; set; }
    public Player(string name)
    {
        this.Wins = 0;
        this.Name = name;
    }
}

public class Round
{
    public int RoundCount { get; set; }

    public Round()
    {
        this.RoundCount = 0;
    }
    public void NewRound(Player player1, Player player2, Round currentRound)
    {
        SelectHand(player1);
        Console.Clear();
        SelectHand(player2);
        Console.Clear();
        (Player winner, Player loser) = DetermineWinner(player1, player2);

        if (winner != null)
        {
            Console.WriteLine($"{winner.PlayedHand} beats {loser.PlayedHand}. {winner.Name} is the winner.");
            winner.Wins++;
        }
        else Console.WriteLine($"Both {player1.Name} and {player2.Name} played {player1.PlayedHand}. Draw.");

        currentRound.RoundCount++;
        Console.WriteLine($"{player1.Name} has {player1.Wins} wins and {player2.Name} has {player2.Wins} wins. {currentRound.RoundCount} rounds have been played.\n");
    }

    private void SelectHand(Player player)
    {
        while (true)
        {
            Console.Write($"{player.Name} pick a hand: ");
            string stringHand = Console.ReadLine().ToLower();
            if (stringHand.Length > 1) stringHand = stringHand.Substring(0, 1).ToUpper() + stringHand.Substring(1);

            if (Enum.TryParse(stringHand, out Hand playedHand) && !stringHand.Any(char.IsDigit))
            {
                player.PlayedHand = playedHand;
                return;
            }
            else
            {
                Console.WriteLine("I don't understand that choice.");
            }
        }
    }

    private (Player, Player) DetermineWinner(Player player1, Player player2)
    {
        if (player1.PlayedHand == player2.PlayedHand) return (null, null);
        if (player1.PlayedHand == Hand.Rock && player2.PlayedHand == Hand.Scissors) return (player1, player2);
        if (player1.PlayedHand == Hand.Paper && player2.PlayedHand == Hand.Rock) return (player1, player2);
        if (player1.PlayedHand == Hand.Scissors && player2.PlayedHand == Hand.Paper) return (player1, player2);
        return (player2, player1);
    }
}

public enum Hand { Rock, Paper, Scissors };