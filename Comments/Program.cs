using System;

Console.WriteLine("What kind of thing are we talking about?");
string a = Console.ReadLine(); // type of object

Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
string b = Console.ReadLine(); // description of object

string c = "of Doom"; // appended description
string d = "3000";

Console.WriteLine("The " + b + " " + a + " " + c + " " + d + "!");