var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
var n = inputs[0];
var k = inputs[1];

var result = Factorial(n) / (Factorial(k) * Factorial(n - k));
Console.WriteLine(result);

int Factorial(int value)
{
    var sum = 1;
    for (int i = value; i > 0; i--)
    {
        sum *= i;
    }

    return sum;
}