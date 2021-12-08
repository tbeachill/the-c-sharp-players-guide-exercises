int result = AskForNumberInRange("Enter a number: ", 0, 100);

int AskForNumber(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int AskForNumberInRange(string text, int min, int max)
{
    int userNumber = int.MaxValue;

    do
        userNumber = AskForNumber(text);
    while (userNumber < min || userNumber > max);

    return userNumber;
}