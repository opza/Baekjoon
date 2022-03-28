var inputCount = int.Parse(Console.ReadLine());
var numbers = Console.ReadLine().Split().Select(int.Parse);

Console.WriteLine($"{numbers.Min()} {numbers.Max()}");