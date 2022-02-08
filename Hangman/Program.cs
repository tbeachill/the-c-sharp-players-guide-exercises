Console.WriteLine(Dictionary.GetWord());

static class Dictionary
{
    public static string GetWord()
    {
        string[] words = File.ReadAllLines(@"C:\Users\Tom\OneDrive\Projects\Learning\The_C_Sharp_Players_Guide\Hangman\words.txt");
        Random rnd = new Random();
        int num = rnd.Next(0, words.Length);

        return words[num];

    }
}

class Player
{
    // Knows word, guesses and incorrect letters
}

class GameRunner
{
    // Pick a letter
    // State of game
}