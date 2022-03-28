using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var kn = rs.ReadLine().Split();
var k = int.Parse(kn[0]);
var n = int.Parse(kn[1]);

var lanLengths = new int[k];
for (int i = 0; i < k; i++)
{
    lanLengths[i] = int.Parse(rs.ReadLine());
}

long min = 1;
long max = lanLengths.Max();
long result = 0;

while (min <= max)
{
    var mid = (min + max) / 2;

    var count = lanLengths.Sum(lanLength => lanLength / mid);

    if (count < n)
        max = mid - 1;
    else 
    { 
        min = mid + 1;
        result = result < mid ? mid : result;
    }
}

ws.WriteLine(result);
