using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
var inputs = rs.ReadLine().Split().Select(int.Parse).ToArray();
var n = inputs[0];
var m = inputs[1];

var groupA = new string[n];
for (int i = 0; i < n; i++)
{
    groupA[i] = rs.ReadLine();
}

var groupB = new string[m];
for (int i = 0; i < m; i++)
{
    groupB[i] = rs.ReadLine();
}

var intersectedGroup = groupA.Intersect(groupB).ToArray();
Array.Sort(intersectedGroup);

ws.WriteLine(intersectedGroup.Length);

foreach (var member in intersectedGroup)
{
    ws.WriteLine(member);
}
