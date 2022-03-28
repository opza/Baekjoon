var inputs = Console.ReadLine().Split();
var number1 = int.Parse(string.Concat(inputs[0].Reverse()));
var number2 = int.Parse(string.Concat(inputs[1].Reverse()));

if (number1 > number2)
    Console.WriteLine(number1);
else
    Console.WriteLine(number2);