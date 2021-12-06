using System;

Console.Title = "Defence of Consolas";

Console.Write("Target row: ");
int targetRow = Convert.ToInt32(Console.ReadLine());

Console.Write("Target column: ");
int targetColumn = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("\nDeploy to:");

Console.ForegroundColor = ConsoleColor.Red;

Console.WriteLine($"{targetRow} {targetColumn - 1}");
Console.WriteLine($"{targetRow} {targetColumn + 1}");
Console.WriteLine($"{targetRow - 1} {targetColumn}");
Console.WriteLine($"{targetRow + 1} {targetColumn}");

Console.Beep();