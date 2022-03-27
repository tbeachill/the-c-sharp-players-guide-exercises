RecentNumbers numObj = new RecentNumbers();

// create a new thread containing the Generate method and start it with numObj
Thread thread = new Thread(Generate);
thread.Start(numObj);


// when the user presses a key, check if the most recent two numbers are the same
while (true)
{
    Console.ReadKey();

    if (numObj.Numbers[0] == numObj.Numbers[1])
        Console.WriteLine("Correctly identified a repeat.");
    else
        Console.WriteLine("That is not a repeat.");
}


void Generate(object o)
{
    // cast o to a RecentNumbers object
    RecentNumbers recentNumbers = (RecentNumbers) o;
    Random random = new Random();

    while (true)
    {
        // generate a new random int and write it to the console
        int newNumber = random.Next(0, 9);
        Console.WriteLine(newNumber);

        // lock so that Numbers[0] and Numbers[1] are not updated at the same time
        lock (recentNumbers)
        {
            recentNumbers.Numbers[1] = recentNumbers.Numbers[0];
            recentNumbers.Numbers[0] = newNumber;
        }

        // sleep 1 sec
        Thread.Sleep(1000);
    }
}


public class RecentNumbers
{
    // stores the last two recent numbers
    public int[] Numbers = new int[2];
}
