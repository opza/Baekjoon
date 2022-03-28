const int INPUT_CONUT = 9;

var max = 0;
var maxIndex = 0;

for (int i = 0; i < INPUT_CONUT; i++)
{
    var number = int.Parse(Console.ReadLine());
    if(number > max)
    {
        max = number;
        maxIndex = i;
    }
}

Console.WriteLine(max);
Console.WriteLine(maxIndex + 1);