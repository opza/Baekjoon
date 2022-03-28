var input = Console.ReadLine();
var splitedInputs = input.Split();

var a = int.Parse(splitedInputs[0]);
var b = int.Parse(splitedInputs[1]);

if (a < b)
    Console.WriteLine("<");
else if (a > b)
    Console.WriteLine(">");
else
    Console.WriteLine("==");