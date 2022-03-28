const int INOUT_COUNT = 10;

var numbers = new List<int>(INOUT_COUNT);
for (int i = 0; i < INOUT_COUNT; i++)
{
    numbers.Add(int.Parse(Console.ReadLine()));
}

var uniqCount = numbers.Select(number => number % 42).Distinct().Count();
Console.WriteLine(uniqCount);
