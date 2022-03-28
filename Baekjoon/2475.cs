var numbers = Console.ReadLine().Split().Select(int.Parse);
var sum = numbers.Sum(number => Math.Pow(number, 2));

Console.WriteLine(sum % 10);