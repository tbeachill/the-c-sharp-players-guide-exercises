int[] numArray = new int[] {1, 9, 2, 8, 3, 7, 4, 6, 5};

Console.WriteLine("Procedural");
foreach (int num in Procedural(numArray))
    Console.Write(num.ToString() + " ");

Console.WriteLine();

Console.WriteLine("Keyword based query expression");
foreach (int num in Keyword(numArray))
    Console.Write(num.ToString() + " ");

Console.WriteLine();

Console.WriteLine("Method call syntax");
foreach (int num in Method(numArray))
    Console.Write(num.ToString() + " ");

IEnumerable<int> Procedural(int[] numbers)
{
    // select even numbers
    List<int> evenNumbers = numbers.Where(x => x % 2 == 0).ToList();
    // double each number
    List<int> doubledNumbers = new List<int> { };
    foreach(int n in evenNumbers) doubledNumbers.Add(n * 2);
    // sort numbers
    doubledNumbers.Sort();

    return doubledNumbers;
}

IEnumerable<int> Keyword(int[] numbers)
{
    return from num in numbers
           where num % 2 == 0
           orderby num
           select num * 2;
}

IEnumerable<int> Method(int[] numbers)
{
    return numbers
        .Where(num => num % 2 == 0)
        .OrderBy(num => num)
        .Select(num => num * 2);
}
