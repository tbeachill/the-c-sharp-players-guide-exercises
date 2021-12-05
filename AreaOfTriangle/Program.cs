using System;

Console.Write("Base: ");
decimal baseLength = Convert.ToDecimal(Console.ReadLine());

Console.Write("Height: ");
decimal height = Convert.ToDecimal(Console.ReadLine());

decimal area = (baseLength * height) / 2;

Console.WriteLine("\nArea of the triangle: " + area);