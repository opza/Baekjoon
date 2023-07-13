using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var caseCount = int.Parse(rs.ReadLine());
var values = new SortedList<int, int>();

for (int i = 0; i < caseCount; i++)
{
    var value = int.Parse(rs.ReadLine());
    values.Add(value, value);
}

foreach (var value in values)
{
    ws.WriteLine(value.Value);
}