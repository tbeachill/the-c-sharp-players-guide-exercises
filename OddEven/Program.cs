using System;

Console.Write("Enter a number: ");
int userNumber = Convert.ToInt32(Console.ReadLine());

if (userNumber % 2 == 0)
{
    Console.Write("Tick");
}
else
{
    Console.Write("Tock");
}