// get word from user
Console.Write("Enter a word: ");
string inWord = Console.ReadLine();

DateTime startTime = DateTime.Now;

// wait for the word to be generated
int attempts = await RandomlyRecreateAsync(inWord);

// display attempts to generate word and time taken
Console.WriteLine($"Attempts: {attempts}");
TimeSpan timeTaken = DateTime.Now - startTime;
Console.WriteLine($"Time taken: {timeTaken}");

Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run( () => RandomlyRecreate(word));
}

int RandomlyRecreate(string word)
{
    // return the number of attempts to randomly generate a given word

    // ensure the word is all lowercase
    word = word.ToLower();

    Random random = new Random();
    string randomWord = "";
    int attemptNum = 0;

    // keep looping until word is randomly generated
    while (randomWord != word)
    {
        // reset randomWord on every iteration
        randomWord = "";
        for (int i = 0; i < word.Length; i++)
            randomWord += (char)('a' + random.Next(26));

        attemptNum++;
    }

    return attemptNum;
}
