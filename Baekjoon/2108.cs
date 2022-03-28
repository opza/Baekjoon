using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var inputCount = int.Parse(rs.ReadLine());
var values = new int[inputCount];
for (int i = 0; i < inputCount; i++)
{
    values[i] = int.Parse(rs.ReadLine());
}

ws.WriteLine(GetAverage(values));
ws.WriteLine(GetMid(values));
ws.WriteLine(GetMode(values));
ws.WriteLine(GetRange(values));

int GetAverage(int[] values)
{
    var avg = values.Average();
    return (int)Math.Round(avg, 0);
}

int GetMid(int[] values)
{
    var sortedValues = values.OrderBy(v => v).ToArray();
    return sortedValues[sortedValues.Length / 2];
}

int GetMode(int[] values)
{
    var groups = values.GroupBy(v => v).OrderByDescending(g => g.Count()).ToArray();
    var modeCount = groups.First().Count();

    var hasSameModeCountGroups = groups.Where(g => g.Count() == modeCount).OrderBy(g => g.Key).ToArray();
    if (hasSameModeCountGroups.Length > 1)
        return hasSameModeCountGroups[1].Key;
    else
        return hasSameModeCountGroups[0].Key;
}

int GetRange(int[] values) => values.Max() - values.Min();