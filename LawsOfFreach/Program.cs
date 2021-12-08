int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

int currentMinimum = int.MaxValue;
int total = 0;

foreach (int value in array)
{
    if (value < currentMinimum)
    {
        currentMinimum = value;
        total += value;
    }
}

float average = (float)total / array.Length;

Console.WriteLine("Minimum: " + currentMinimum + "\nTotal: " + total + "\nAverage: " + average);