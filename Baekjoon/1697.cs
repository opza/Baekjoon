#region 0
//var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
//var n = inputs[0];
//var m = inputs[1];

//Console.WriteLine(GetTime(n, m));

//int GetTime(int startPos, int destPos)
//{
//    if (startPos > destPos)
//        return startPos - destPos;

//    var time = 0;

//    var openSet = new List<int>();
//    var nextOpenSet = new List<int>();
//    var visited = new bool[destPos * 2];

//    openSet.Add(startPos);

//    while (openSet.Count > 0)
//    {
//        foreach (var currPos in openSet)
//        {
//            if (currPos < 0)
//                continue;

//            if (currPos == destPos)
//                return time;

//            if (visited[currPos])
//                continue;

//            if (currPos < destPos)
//            {
//                nextOpenSet.Add(currPos * 2);
//                nextOpenSet.Add(currPos + 1);
//                nextOpenSet.Add(currPos - 1);
//            }
//            else
//                nextOpenSet.Add(currPos - 1);

//            visited[currPos] = true;
//        }

//        openSet = new List<int>(nextOpenSet);
//        nextOpenSet.Clear();

//        time++;
//    }

//    throw new Exception();
//}
#endregion
#region 1
var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
var n = inputs[0];
var m = inputs[1];

Console.WriteLine(GetTime(n, m));

int GetTime(int startPos, int destPos)
{
    if (startPos > destPos)
        return startPos - destPos;

    var time = 0;

    var openSet = new List<int>();
    var nextOpenSet = new List<int>();
    var visited = new bool[destPos * 2];

    openSet.Add(startPos);

    while (openSet.Count > 0)
    {
        foreach (var currPos in openSet)
        {
            if (currPos < 0)
                continue;

            if (currPos == destPos)
                return time;

            if (visited[currPos])
                continue;

            if (currPos < destPos)
            {
                nextOpenSet.Add(currPos * 2);
                nextOpenSet.Add(currPos + 1);
                nextOpenSet.Add(currPos - 1);
            }
            else
                nextOpenSet.Add(currPos - 1);

            visited[currPos] = true;
        }

        openSet = nextOpenSet;
        nextOpenSet = new List<int>();

        time++;
    }

    throw new Exception();
}
#endregion
