using System;

string response;

Console.WriteLine("The following items are available:");
Console.Write(@"1 - Rope
2 - Torches
3 - Climbing Equipment
4 - Clean Water
5 - Machete
6 - Canoe
7 - Food Supplies

What number do yo want to see the price of? ");
int choice = Convert.ToInt32(Console.ReadLine());

Console.Write("What is your name? ");
string userName = Console.ReadLine();

if (userName == "Tom")
{
    response = choice switch
    {
        1 => "Rope costs 5 gold.",
        2 => "Torches cost 7.5 gold.",
        3 => "Climbing equipment costs 12.5 gold.",
        4 => "Clean water costs 0.5 gold.",
        5 => "Machete costs 10 gold.",
        6 => "Canoe costs 100 gold.",
        7 => "Food supplies cost 0.5 gold.",
        _ => "I don't understand."
    };
}
else
{
    response = choice switch
    {
        1 => "Rope costs 10 gold.",
        2 => "Torches cost 15 gold.",
        3 => "Climbing equipment costs 25 gold.",
        4 => "Clean water costs 1 gold.",
        5 => "Machete costs 20 gold.",
        6 => "Canoe costs 200 gold.",
        7 => "Food supplies cost 1 gold.",
        _ => "I don't understand."
    };
}

Console.WriteLine("\n" + response);