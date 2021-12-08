Countdown(10);

int Countdown(int num)
{
    Console.WriteLine(num);
    if (num == 0) return 0;
    return Countdown(num - 1);
}