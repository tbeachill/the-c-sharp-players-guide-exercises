Random random = new Random();

Console.WriteLine(random.NextDouble(100));
Console.WriteLine(random.NextString("Red", "Green", "Blue"));
Console.WriteLine(random.CoinFlip());
Console.WriteLine(random.CoinFlip(0.25));

public static class RandomExtensions
{
    public static double NextDouble(this Random random, double max) => random.NextDouble() * max;
    public static string NextString(this Random random, params string[] strings) => strings[random.Next(strings.Length)];
    public static bool CoinFlip(this Random random, double p = 0.5) => random.NextDouble() < p;
}