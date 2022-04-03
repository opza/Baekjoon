using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var caseCount = int.Parse(rs.ReadLine());
var array = new int[caseCount];
for (int i = 0; i < caseCount; i++)
{
    array[i] = int.Parse(rs.ReadLine());
}

Array.Sort(array);

for (int i = 0; i < caseCount; i++)
{
    ws.WriteLine(array[i]);
}