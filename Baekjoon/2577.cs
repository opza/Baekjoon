const int INPUT_COUNT = 3;

var mul = 1;
for (var i = 0; i < INPUT_COUNT; i++)
{
    mul *= int.Parse(Console.ReadLine());
}

var numberCounts = new int[10];
foreach (var item in mul.ToString())
{
    var number = (int)char.GetNumericValue(item);
    numberCounts[number]++;
}


foreach (var count in numberCounts)
{
    Console.WriteLine(count);
}