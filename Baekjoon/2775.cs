using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
//ws.AutoFlush = true;

var caseCount = int.Parse(rs.ReadLine());
for (int i = 0; i < caseCount; i++)
{
    var k = int.Parse(rs.ReadLine());
    var n = int.Parse(rs.ReadLine());

    ws.WriteLine(GetResidentCount(k, n));
}

int GetResidentCount(int k, int n)
{
    var lastLine = new int[n];
    for (int i = 0; i < n; i++)
    {
        lastLine[i] = i + 1;
    }

    for (int i = 0; i < k; i++)
    {
        var newLine = new int[n];
        var sumLine = 0;
        for (int j = 0; j < n; j++)
        {
            sumLine += lastLine[j];
            newLine[j] = sumLine;
        }

        lastLine = newLine;
    }

    return lastLine[n - 1];
}