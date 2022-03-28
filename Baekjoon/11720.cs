var _ = int.Parse(Console.ReadLine());
var sum = Console.ReadLine().Sum(c => char.GetNumericValue(c));
Console.WriteLine(sum);