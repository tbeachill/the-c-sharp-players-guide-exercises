Console.Write("Enter a value: ");

if (int.TryParse(Console.ReadLine(), out int intValue))
{
    Console.WriteLine($"Int entered: {intValue}.");
}
else if (double.TryParse(Console.ReadLine(),out double doubleValue))
{
    Console.WriteLine($"Double entered: {doubleValue}.");
}
else if (bool.TryParse(Console.ReadLine(), out bool boolValue))
{
    Console.WriteLine($"Bool entered: {boolValue}.");
}
else
{
    Console.WriteLine("Input not int, double or bool.");
}
