var targetValue = int.Parse(Console.ReadLine());
for (int i = 1; i <= targetValue; i++)
{
    if (IsConstructor(targetValue, i))
    {
        Console.WriteLine(i);
        return;
    }
}

Console.WriteLine(0);


bool IsConstructor(int targetValue, int value)
{
    var sum = value;
    while (value > 0)
    {
        sum += value % 10;
        value /= 10;
    }

    return targetValue == sum;
}