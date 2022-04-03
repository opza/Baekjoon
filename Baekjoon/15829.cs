#region 1
//using System.Numerics;

//const int ASCII_a = 97;
//const int M = 1234567891;

//using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
//using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

//var strLength = int.Parse(rs.ReadLine());
//var str = rs.ReadLine();

//BigInteger mul = 0;
//BigInteger modResult = 0;
//for (int i = 0; i < strLength; i++)
//{
//    mul = BigInteger.Pow(31, i);
//    modResult += ((int)str[i] - ASCII_a + 1) * mul;
//    if (modResult >= M)
//        modResult %= M;
//}

//ws.WriteLine(modResult % M);
#endregion
#region 2
using System.Numerics;

const int ASCII_a = 97;
const int R = 31;
const int M = 1234567891;

using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var strLength = int.Parse(rs.ReadLine());
var str = rs.ReadLine();

BigInteger result = 0;
for (int i = 0; i < strLength; i++)
{
    result += ((int)str[i] - ASCII_a + 1) * BigInteger.ModPow(R, i, M);
    if (result >= M)
        result %= M;
}

ws.WriteLine(result);
#endregion