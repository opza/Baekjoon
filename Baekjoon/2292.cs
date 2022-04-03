var targetValue = int.Parse(Console.ReadLine());

var length = 1;
while (targetValue > 1)
{
    targetValue -= length * 6;
    length++;
}

Console.WriteLine(length);