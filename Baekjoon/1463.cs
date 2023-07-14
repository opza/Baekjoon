#region 2회차
//var x = int.Parse(Console.ReadLine());
//Console.WriteLine(GetShortestDistance(x));

//static int GetShortestDistance(int x)
//{
//    if (x <= 1)
//        return 0;

//    var nextQueue = new PriorityQueue<int, int>();
//    nextQueue.Enqueue(x, -1);

//    var depth = 0;

//    while (nextQueue.Count > 0)
//    {
//        depth++;

//        var currentQueue = new PriorityQueue<int, int>(nextQueue.UnorderedItems);
//        nextQueue.Clear();

//        while (currentQueue.Count > 0)
//        {
//            var value = currentQueue.Dequeue();
//            var nextValue = -1;

//            if (value % 3 == 0)
//            {
//                nextValue = value / 3;
//                if (nextValue == 1)
//                    return depth;

//                nextQueue.Enqueue(nextValue, nextValue);
//            }

//            if (value % 2 == 0)
//            {
//                nextValue = value / 2;
//                if (nextValue == 1)
//                    return depth;

//                nextQueue.Enqueue(nextValue, nextValue);
//            }

//            nextValue = value - 1;
//            if (nextValue == 1)
//                return depth;

//            nextQueue.Enqueue(nextValue, nextValue);
//        }
//    }

//    return -1;
//}
#endregion
#region 3회차

//var x = int.Parse(Console.ReadLine());

//var values = new int[x + 1];
//for (int i = 2; i <= x; i++)
//{
//    values[i] = values[i - 1] + 1;
//    if (i % 2 == 0)
//        values[i] = Min(values[i], values[i / 2] + 1);
//    if (i % 3 == 0)
//        values[i] = Min(values[i], values[i / 3] + 1);
//}

//Console.WriteLine(values[x]);

//static int Min(int x, int y) => x <= y ? x : y;

#endregion
#region 4회차

//var x = int.Parse(Console.ReadLine());

//var values = new int[x + 1];
//Console.WriteLine(Calculate(x));

//int Calculate(int x)
//{
//    if (x < 2)
//        return 0;

//    if (values[x] > 1)
//        return values[x];

//    values[x] = Calculate(x - 1) + 1;

//    if (x % 2 == 0)   
//        values[x] = Math.Min(values[x], Calculate(x / 2) + 1);

//    if (x % 3 == 0)
//        values[x] = Math.Min(values[x], Calculate(x / 3) + 1);

//    return values[x];
//}

#endregion
#region 5회차

//var x = int.Parse(Console.ReadLine());

//var values = new int[x + 1];
//Console.WriteLine(Calculate(x));
//Console.ReadKey();

//int Calculate(int x)
//{
//    if (x < 2)
//        return 0;

//    if (values[x] > 1)
//        return values[x];

//    if (x % 3 == 0 && x % 2 == 0)
//        values[x] = Math.Min(Calculate(x / 3) + 1, Calculate(x / 2) + 1);
//    else
//    {
//        values[x] = Calculate(x - 1) + 1;

//        if (x % 3 == 0)
//            values[x] = Math.Min(values[x], Calculate(x / 3) + 1);
//        else if (x % 2 == 0)
//            values[x] = Math.Min(values[x], Calculate(x / 2) + 1);        
//    }

//    return values[x];
//}

var x = int.Parse(Console.ReadLine());

var values = new Dictionary<int, int>();
Console.WriteLine(Calculate(x));

int Calculate(int x)
{
    if (x < 2)
        return 0;

    if (!values.ContainsKey(x))
        values[x] = -1;
    else
        return values[x];

    if (x % 3 == 0 && x % 2 == 0)
        values[x] = Math.Min(Calculate(x / 3) + 1, Calculate(x / 2) + 1);
    else
    {
        values[x] = Calculate(x - 1) + 1;

        if (x % 3 == 0)
            values[x] = Math.Min(values[x], Calculate(x / 3) + 1);
        else if (x % 2 == 0)
            values[x] = Math.Min(values[x], Calculate(x / 2) + 1);
    }

    return values[x];
}

#endregion