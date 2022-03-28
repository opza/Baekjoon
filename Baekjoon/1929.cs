#region 1

//using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
//using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

//var inputs = rs.ReadLine().Split();
//var min = int.Parse(inputs[0]);
//var max = int.Parse(inputs[1]);


//for (int value = min; value <= max; value++)
//{
//    bool isPrimeNumber = true;

//    for (int i = 2; i < value; i++)
//    {
//        if(value % i == 0)
//        {
//            isPrimeNumber = false;
//            break;
//        }
//    }

//    if(isPrimeNumber)
//        ws.WriteLine(value);
//}

#endregion
#region 2

using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var inputs = rs.ReadLine().Split();
var min = int.Parse(inputs[0]);
var max = int.Parse(inputs[1]);

var length = max - min + 1;
var values = new int[length];
for (int i = 0; i < length; i++)
{
    values[i] = min + i;
}

var primeMask = new bool[length];
if (values[0] == 1)
    primeMask[0] = true;

var maxDiv = MathF.Sqrt(max);

for (int i = 2; i <= maxDiv; i++)
{
    for (int j = 2 * i; j <= max; j += i)
    {
        if (j < min)
            continue;

        primeMask[j - min] = true;
    }
}

for (int i = 0; i < length; i++)
{
    if (!primeMask[i])
        ws.WriteLine(values[i]);
}

#endregion