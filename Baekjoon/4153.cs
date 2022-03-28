using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

while (true)
{
    var inputs = rs.ReadLine().Split().Select(int.Parse).ToArray();

    var a = inputs[0];
    var b = inputs[1];
    var c = inputs[2];

    if (a == 0 && b == 0 && c == 0)
        break;

    var isRightTriangle = IsRightTriangle(a, b, c);
    if (isRightTriangle)
        ws.WriteLine("right");
    else
        ws.WriteLine("wrong");

}

bool IsRightTriangle(int a, int b, int c)
{
    var squaredA = a * a;
    var squaredB = b * b;
    var squaredC = c * c;

    if (squaredA == squaredB + squaredC || squaredB == squaredA + squaredC || squaredC == squaredA + squaredB)
        return true;

    return false;
}


