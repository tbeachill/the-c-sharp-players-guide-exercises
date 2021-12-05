using System;

Console.Write("Number of provinces: ");
int numProvince = Convert.ToInt32(Console.ReadLine());

Console.Write("Number of duchies: ");
int numDuchies = Convert.ToInt32(Console.ReadLine());

Console.Write("Number of estates: ");
int numEstates = Convert.ToInt32(Console.ReadLine());

int totalScore = (numProvince * 6) + (numDuchies * 3) + numEstates;
Console.WriteLine("\nTotal score: " + totalScore);