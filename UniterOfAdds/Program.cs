// a single dynamic method can can add different types

Console.WriteLine(Add(2, 2));
Console.WriteLine(Add(1.25, 1.25));
Console.WriteLine(Add("123", "456"));
Console.WriteLine(Add(DateTime.Now, TimeSpan.FromDays(1)));

dynamic Add(dynamic a, dynamic b) => a + b;
