using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
var inputs = rs.ReadLine().Split().Select(int.Parse).ToArray();
var m = inputs[0];
var n = inputs[1];

var names = new Dictionary<string, string>();
for (int i = 1; i <= m; i++)
{
    var inputM = rs.ReadLine();
    var strI = i.ToString();
    names[inputM] = strI;
    names[strI] = inputM;
}

for (int i = 0; i < n; i++)
{
    var inputN = rs.ReadLine();
    ws.WriteLine(names[inputN]);
}