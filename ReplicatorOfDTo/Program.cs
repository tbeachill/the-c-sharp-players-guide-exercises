int[] userArray = new int[5];

for (int i = 0; i < userArray.Length; i++)
{
    Console.Write("Enter a value: ");
    userArray[i] = Convert.ToInt32(Console.ReadLine());
}

int[] copyArray = new int[5];

for (int i = 0; i < userArray.Length; i++)
{
    copyArray[i] = userArray[i];
}

Console.WriteLine("\n" + String.Join(", ", userArray));
Console.WriteLine("\n" + String.Join(", ", copyArray));