ChestState currentState = ChestState.Locked;
ChangeState(currentState);

ChestState ChangeState(ChestState currentState)
{
    while (true)
    {
        Console.Write($"The chest is {currentState}. What do you want to do? ");
        string userIntent = Console.ReadLine();

        switch (userIntent)
        {
            case "close":
                if (currentState == ChestState.Open)
                    currentState = ChestState.Closed;
                else
                    Console.WriteLine("You can't do that.");
                break;

            case "lock":
                if (currentState == ChestState.Closed)
                    currentState = ChestState.Locked;
                else
                    Console.WriteLine("You can't do that.");
                break;

            case "unlock":
                if (currentState == ChestState.Locked)
                    currentState = ChestState.Closed;
                else
                    Console.WriteLine("You can't do that.");
                break;

            case "open":
                if (currentState == ChestState.Closed)
                    currentState = ChestState.Open;
                else
                    Console.WriteLine("You can't do that.");
                break;

            default:
                Console.WriteLine("I don't understand.");
                break;
        }
    }
}

enum ChestState { Open, Closed, Locked };