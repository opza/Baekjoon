var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
var a = inputs[0];
var b = inputs[1];
var v = inputs[2];

if(v == a)
{
    Console.WriteLine(1);
    return;
}

var realEnd = v - a;
var realSpeed = a - b;

var result = realEnd / realSpeed;
if (result * realSpeed < realEnd)
    result += 1;

result += 1;
Console.WriteLine(result);