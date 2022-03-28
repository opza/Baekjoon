using System.Text;

var inputs = Console.ReadLine().Split();
var values = Console.ReadLine().Split().Select(int.Parse);
var comparedValue = int.Parse(inputs[1]);

var strBuilder = new StringBuilder();
foreach (var value in values.Where(value => value < comparedValue))
{
    strBuilder.Append($"{value} ");
}
strBuilder.Remove(strBuilder.Length - 1, 1);

Console.WriteLine(strBuilder.ToString());
