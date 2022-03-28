#region 1
//var inputCount = int.Parse(Console.ReadLine());
//var values = Console.ReadLine().Split()
//    .Select(int.Parse)
//    .ToList();

//if(values.Contains(1))
//    values.Remove(1);

//var max = values.Max();
//var maxDiv = MathF.Sqrt(max);
//for (int i = 2; i <= maxDiv; i++)
//{
//    for (int j = values.Count - 1; j >= 0; j--)
//    {       
//        var value = values[j];
//        if (value != i && value % i == 0)
//            values.RemoveAt(j);
//    }
//}

//Console.WriteLine(values.Count);
#endregion
#region 2
var inputCount = int.Parse(Console.ReadLine());
var values = Console.ReadLine().Split().Select(int.Parse).ToArray();

var primeCount = 0;
for (int i = 0; i < inputCount; i++)
{
    if (IsPrime(values[i]))
        primeCount++;
}

Console.WriteLine(primeCount);

bool IsPrime(int value)
{
    if (value == 1)
        return false;

    if (value == 2 || value == 3)
        return true;

    var maxDiv = MathF.Sqrt(value);
    for (int i = 2; i <= maxDiv; i++)
    {
        if (value == i)
            continue;

        if (value % i == 0)
            return false;
    }

    return true;
}

#endregion