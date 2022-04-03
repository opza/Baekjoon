using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var inputs = rs.ReadLine().Split().Select(int.Parse).ToArray();
var a = inputs[0];
var b = inputs[1];

var gcd = GetGcd(a, b);
var lcd = GetLcm(a, b, gcd);

ws.WriteLine(gcd);
ws.WriteLine(lcd);

int GetGcd(int a, int b)
{
    while (true)
    {
        var buff = a % b;
        if (buff == 0)
            return b;

        a = b;
        b = buff;
    }
}

int GetLcm(int a, int b, int gcd) => a * b / gcd;