// A game of Hangman

bool playAgain;
// Continue to play new games for as long as playAgain is true
do
{
    // Create and start a new game
    playAgain = false;
    Player currentPlayer = new Player();
    GameRunner currentGame = new GameRunner(currentPlayer);
    currentGame.StartGame();
    Console.WriteLine();

    // Ask if the player wants to play again until Y or N is selected
    do
    {
        Console.Write("Do you want to play again? (Y/N): ");
        if (Char.TryParse(Console.ReadLine(), out char selection))
        {
            if (Char.ToLower(selection) == 'y')
            {
                Console.Clear();
                playAgain = true;
            }
            else if (Char.ToLower(selection) == 'n')
            {
                System.Environment.Exit(0);
            }
        }
    } while (!playAgain);
} while (playAgain);

static class Dictionary
{
    public static string GetWord()
    {
        // Picks a random word from the words.txt file
        string[] words = File.ReadAllLines(@"C:\Users\Tom\OneDrive\Projects\Learning\The_C_Sharp_Players_Guide\Hangman\words.txt");
        Random rnd = new Random();
        int num = rnd.Next(0, words.Length);

        return words[num];
    }
}

class Player
{
    // Player class containing the word to guess, number of guesses, incorrect letters guessed, and all letters guessed
    public string Word { get; }
    public int Guesses { get; set; }
    public char[] IncorrectLetters { get; set; }
    public char[] AllLetters { get; set; }

    public Player()
    {
        this.Word = Dictionary.GetWord();
        this.Guesses = 0;
        this.IncorrectLetters = new char[11];
        this.AllLetters = new char[24];
    }
}

class GameRunner
{
    // Class for running each game of Hangman
    Player Player { get; set; }
    string GuessWord { get; set; }
    bool GameFinished = false;
    public GameRunner(Player player)
    {
        // Set up the game with the current player, the number of letters to be guessed as _'s
        this.Player = player;
        this.GuessWord = String.Concat(Enumerable.Repeat("_", Player.Word.Length));
    }

    public void StartGame()
    {
        // Start a game and keep repeating each round until the game is finished
        do
        {
            PickLetter();
        } while (!GameFinished);
    }

    public void PickLetter()
    {
        // Allows the player to guess a character that hasn't already been guessed
        char guess;
        var guessWordOut = string.Join<char>(" ", GuessWord);
        Console.Write($"Word: {guessWordOut} | Remaining: {11 - Player.Guesses} | Incorrect: { new String(Player.IncorrectLetters)} | Guess: ");
        if (Char.TryParse(Console.ReadLine(), out guess))
        {
            if (!Player.AllLetters.Contains(char.ToUpper(guess)))
            {
                GameState(guess);
            }
        }
    }

    public void GameState(char guess)
    {
        // Update the current game state after each new guess by the player
        Player.AllLetters = Player.AllLetters.Concat(new char[] { Char.ToUpper(guess) }).ToArray();

        foreach (char c in Player.Word)
        {
            if (c == guess)
            {
                // Find all locations of guess in Player.Word and reaveal the letter in the blanks
                for (int i = 0; i < Player.Word.Length; i++)
                {
                    if (Player.Word[i].Equals(guess))
                    {
                        char[] wordArray = GuessWord.ToCharArray();
                        wordArray[i] = Char.ToUpper(guess);
                        GuessWord = new string(wordArray);

                        if (!GuessWord.Contains('_'))
                        {
                            // If there are no more blanks (_) the player has won
                            Console.WriteLine($"\nYou win! The word was {Player.Word}");
                            GameFinished = true;
                            return;
                        }
                    }
                }
                return;
            }
        }

        // If the guess is incorrect, increase the number of guesses and add the incorrect letter to player
        Player.Guesses++;
        Player.IncorrectLetters = Player.IncorrectLetters.Concat(new char[] { Char.ToUpper(guess) }).ToArray();

        if (Player.Guesses == 11)
        {
            // If the player has ran out of guesses, end the game as a loss
            Console.WriteLine($"\nYou lost. The word was: {Player.Word.ToUpper()}");
            GameFinished = true;
        }

        return;
    }
}
