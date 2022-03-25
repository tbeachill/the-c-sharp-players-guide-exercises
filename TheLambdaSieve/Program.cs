Console.Write("Which filter do you want to use? (1=Even, 2=Positive, 3=MultipleOfTen) ");
int choice = Convert.ToInt32(Console.ReadLine());

Sieve sieve = choice switch
{
    1 => new Sieve(n => n % 2 == 0),
    2 => new Sieve(n => n > 0),
    3 => new Sieve(n => n % 10 == 0)
};

while (true)
{
    Console.Write("Enter a number: ");
    int number = Convert.ToInt32(Console.ReadLine());

    string goodOrBad = sieve.IsGood(number) ? "good" : "bad";
    Console.WriteLine($"That number is {goodOrBad}.");
}

public class Sieve
{
    private Func<int, bool> decisionFunction;

    public Sieve(Func<int, bool> decisionFunction)
    {
        this.decisionFunction = decisionFunction;
    }

    public bool IsGood(int number)
    {
        return decisionFunction(number);
    }
}
