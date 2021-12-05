using System;

Console.Write("Number of eggs: ");
int numOfEggs = Convert.ToInt32(Console.ReadLine());

int eggsEach = numOfEggs / 4;
int eggRemainder = numOfEggs % 4;

Console.WriteLine("\nEggs each: " + eggsEach + "\nRemaining eggs: " + eggRemainder);