using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var caseCount = int.Parse(rs.ReadLine());
for (int i = 0; i < caseCount; i++)
{
    var inputs = rs.ReadLine().Split().Select(int.Parse).ToArray();
    var h = inputs[0];
    var w = inputs[1];
    var n = inputs[2] - 1;

    var floor = n % h + 1;
    var number = n / h + 1;

    ws.WriteLine($"{floor}{number:00}");

}