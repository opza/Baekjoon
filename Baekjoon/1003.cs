using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var t = int.Parse(rs.ReadLine());
for (int i = 0; i < t; i++)
{
    var n = int.Parse(rs.ReadLine());
    var result = GetCount(n);
    ws.WriteLine($"{result.count0} {result.count1}");
}

(int count0, int count1) GetCount(int n)
{
    var values = new List<(int count0, int count1)>();
    values.Add((1, 0));
    values.Add((0, 1));

    for (int i = values.Count; i <= n; i++)
    {
        values.Add(SumValueTuple(values[i - 1], values[i - 2]));
    }

    return values[n];
}

(int, int) SumValueTuple((int, int) a, (int, int) b) => (a.Item1 + b.Item1, a.Item2 + b.Item2);
