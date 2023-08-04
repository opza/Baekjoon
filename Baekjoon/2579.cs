#region 1
//50%까지만 맞음

//using System.Diagnostics;

//using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
//using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

//var stairsCount = int.Parse(rs.ReadLine()) + 1;
//var stairses = new Stairs[stairsCount];
//stairses[0] = new Stairs(0);
//for (int i = 1; i < stairsCount; i++)
//{
//    var point = int.Parse(rs.ReadLine());
//    stairses[i] = new Stairs(point);
//}

//ws.WriteLine(GetMaxPoint(stairses, 0, 0));

//int GetMaxPoint(Stairs[] stairses, int currIndex, int consecutiveValue)
//{
//    if (currIndex >= stairses.Length)
//        return 0;

//    var stairs = stairses[currIndex];

//    if (consecutiveValue >= 2)
//    {
//        if (!stairs.TotalPointOfJump.HasValue)
//            stairs.TotalPointOfJump = stairs.Point + GetMaxPoint(stairses, currIndex + 2, 1);

//        return stairs.TotalPointOfJump.Value;
//    }


//    if (!stairs.TotalPointOfJump.HasValue)
//        stairs.TotalPointOfJump = stairs.Point + GetMaxPoint(stairses, currIndex + 2, 1);

//    if (!stairs.TotalPointOf1Step.HasValue)
//        stairs.TotalPointOf1Step = stairs.Point + GetMaxPoint(stairses, currIndex + 1, consecutiveValue + 1); 

//    return stairs.TotalMaxPoint;
//}

//[DebuggerDisplay("{Point} {TotalPointOf1Step} {TotalPointOfJump} {TotalMaxPoint}")]
//class Stairs
//{
//    int _point;

//    public int Point => _point;
//    public int? TotalPointOf1Step { get; set; }
//    public int? TotalPointOfJump { get; set; }

//    public int TotalMaxPoint => Math.Max(TotalPointOf1Step ?? 0, TotalPointOfJump ?? 0);

//    public Stairs(int point)
//    {
//        _point = point;
//    }
//}
#endregion
#region 2
//using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
//using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

//var inputCount = int.Parse(rs.ReadLine()) + 1;
//var count = inputCount > 4 ? inputCount : 4;

//var stairses = new int[count];
//var points = new int[count];
//for (int i = 1; i < inputCount; i++)
//{
//    stairses[i] = int.Parse(rs.ReadLine());
//}

//points[1] = stairses[1];
//points[2] = stairses[1] + stairses[2];
//points[3] = Math.Max(stairses[1] + stairses[3], stairses[2] + stairses[3]);

//for (int i = 4; i < count; i++)
//{
//    points[i] = Math.Max(points[i - 2] + stairses[i], points[i - 3] + stairses[i - 1] + stairses[i]);
//}

//ws.WriteLine(points[inputCount - 1]);
#endregion
#region 3
using System.Diagnostics;

using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var stairsCount = int.Parse(rs.ReadLine()) + 1;
var stairses = new Stairs[stairsCount];
stairses[0] = new Stairs(0);
for (int i = 1; i < stairsCount; i++)
{
    var point = int.Parse(rs.ReadLine());
    stairses[i] = new Stairs(point);
}

ws.WriteLine(GetMaxPoint(stairses, 0, 0));

int GetMaxPoint(Stairs[] stairses, int currIndex)
{
    var stairs = stairses[currIndex];
    stairs.TotalPoint = stairs.Point + Math.Max(GetMaxPoint(stairses, currIndex + 1), GetMaxPoint(stairses, currIndex + 2));
}

[DebuggerDisplay("{Point} {Total}")]
class Stairs
{
    int _point;

    public int Point => _point;
    public int TotalPoint { get; set; }


    public Stairs(int point)
    {
        _point = point;
    }
}
#endregion

