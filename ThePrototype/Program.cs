using System;

int targetNumber = -1;

do
{
    Console.Write("User 1, enter a number between 1 and 100: ");
    targetNumber = Convert.ToInt32(Console.ReadLine());
}
while (targetNumber < 0 || targetNumber > 100);

Console.Clear();

Console.WriteLine("User 2, guess the number.\n");
int guessNumber = 101;

while (guessNumber != targetNumber)
{
    Console.Write("Enter a guess: ");
    guessNumber = Convert.ToInt32(Console.ReadLine());

    if (guessNumber > targetNumber)
        Console.WriteLine($"{guessNumber} is too high.\n");
    else if (guessNumber == targetNumber)
        Console.WriteLine("You guessed the number!");
    else
        Console.WriteLine($"{guessNumber} is too low.\n");
}