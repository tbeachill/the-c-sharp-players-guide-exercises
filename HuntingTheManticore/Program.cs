StartGame();


void StartGame()
{
    // Get initialised values, loop through rounds until The Manticore or Consolas is destroyed, then ask to replay.

    (int manticoreHealth, int consolasHealth, int roundNumber, int manticorePlacement) = InitialiseGame();

    while (manticoreHealth > 0 && consolasHealth > 0)
    {
        manticoreHealth = StartRound(manticoreHealth, consolasHealth, roundNumber, manticorePlacement);
        consolasHealth--;
        roundNumber++;
    }

    string playAgain = EndGame(manticoreHealth, consolasHealth);

    if (playAgain == "Y")
        StartGame();
    else
        Console.WriteLine("Goodbye.");
}

(int, int, int, int) InitialiseGame()
{
    // Initialise game starting values

    int manticoreHealth = 10;
    int consolasHealth = 15;
    int roundNumber = 1;
    Random random = new Random();
    int manticorePlacement = random.Next(100);
    
    Console.Clear();

    return (manticoreHealth, consolasHealth, roundNumber, manticorePlacement);
}

int StartRound(int manticoreHealth, int consolasHealth, int roundNumber, int manticorePlacement)
{
    // Main code for each round of the game

    int damage = CannonMultiple(roundNumber);

    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine($"STATUS: Round: {roundNumber} City: {consolasHealth}/15 Manticore: {manticoreHealth}/10");
    Console.WriteLine($"The cannon is expected to deal {damage} damage this round.");

    int cannonRange = NumberInput("Enter desired cannon range: ");
    string hitString = HitMiss(cannonRange, manticorePlacement);

    Console.WriteLine($"That round {hitString}");

    if (hitString == "was a DIRECT HIT!")
        manticoreHealth = manticoreHealth - damage;

    return manticoreHealth;
}

string EndGame(int manticoreHealth, int consolasHealth)
{
    // Declare the winner of the game and prompt to replay

    if (manticoreHealth < 1 && consolasHealth < 1)
        Console.WriteLine("\nBoth the manticore and the city have been destroyed!");
    else if (manticoreHealth < 1)
        Console.WriteLine("\nThe Manticore has been destroyed! The city of Consolas has been saved!");
    else
        Console.WriteLine("\nThe city of Consolas has been destroyed!");

    string input = "?";
    while (input != "N" && input != "Y")
    {
        Console.Write("Would you like to play again? Y/N: ");
        try
        {
            input = Console.ReadLine();
        }
        catch (FormatException)
        {
            // do nothing - will keep looping until correct input
        }
    }

    return input;
}

int NumberInput(string text)
{
    // Take in a number from the player

    int userNum = int.MaxValue;

    do
    {
        Console.Write(text);
        try
        {
            userNum = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            // do nothing - will keep looping until correct input
        }
    }
    while (userNum < 0 || userNum > 100);

    return userNum;
}

int CannonMultiple(int roundNumber)
{
    // Determine what amount of damage the cannon does in the current round

    int damageNumber = 1;

    if (roundNumber % 3 == 0 && roundNumber % 5 == 0)
        damageNumber = 10;
    else if (roundNumber % 5 == 0)
        damageNumber = 3;
    else if (roundNumber % 3 == 0)
        damageNumber = 3;

    return damageNumber;
}

string HitMiss(int cannonRange, int manticorePlacement)
{
    // Return whether the user hit The Manticore, overshot, or undershot

    string hitString = "";

    if (cannonRange > manticorePlacement)
        hitString = "OVERSHOT the target.";
    else if (cannonRange < manticorePlacement)
        hitString = "FELL SHORT of the target.";
    else if (cannonRange == manticorePlacement)
        hitString = "was a DIRECT HIT!";

    return hitString;
}