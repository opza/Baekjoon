var n = int.Parse(Console.ReadLine());
Console.WriteLine(GetNumberOfZero(n));

static int GetNumberOfZero(int value)
{
    var multiplesOf5 = new List<int>();
    var currMultiples = 5;
    while (value >= currMultiples)
    {
        multiplesOf5.Add(currMultiples);
        currMultiples *= 5;
    }

    var count = 0;
    foreach (var multiples in multiplesOf5)
    {
        count += value / multiples;
    }

    return count;
}

