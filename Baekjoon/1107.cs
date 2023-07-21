#region 1
//const int CHANNEL_MAX = 500000;
//const int CURRENT_CHANNEL = 100;

//using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
//using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
//var n = int.Parse(rs.ReadLine());
//var m = int.Parse(rs.ReadLine());
//var brokenButtons = m > 0 ? rs.ReadLine().Split().Select(int.Parse).ToArray() : new int[0];

//ws.WriteLine(GetPressCount(n, brokenButtons));

//int GetPressCount(int n, int[] brokenButtons)
//{
//    var unbrokenButtons = Enumerable.Range(0, 10).Except(brokenButtons).ToArray();
//    var nLength = n <= 0 ? 1 : (int)Math.Log10(n) + 1;

//    var pressCountWithChangedChannel = GetPressCountWithChangedChannel(n, nLength, 0, 0, unbrokenButtons);
//    var pressCountWithCurrentChannel = GetPressCountWithCurrentChannel(n);

//    return Math.Min(pressCountWithChangedChannel, pressCountWithCurrentChannel);
//}

//int GetPressCountWithChangedChannel(int n, int nLength, int value, int digit, int[] unbrokenButtons)
//{
//    if (digit > nLength)
//        return CalculatePressCount(n, value);

//    var nextDigit = digit + 1;
//    var pressCountMin = int.MaxValue;

//    foreach (var unbrokenButton in unbrokenButtons)
//    {
//        var currValue = value + unbrokenButton * (int)Math.Pow(10, digit);

//        var nextPressCount = GetPressCountWithChangedChannel(n, nLength, currValue, nextDigit, unbrokenButtons);
//        var currPressCount = CalculatePressCount(n, currValue);

//        pressCountMin = Math.Min(pressCountMin, Math.Min(nextPressCount, currPressCount));
//    }

//    return pressCountMin;
//}


//int GetPressCountWithCurrentChannel(int n) => Math.Abs(n - CURRENT_CHANNEL);

//int CalculatePressCount(int n, int value)
//{
//    if (value <= 0)
//        return Math.Abs(n - value) + 1;

//    return Math.Abs(n - value) + (int)Math.Log10(value) + 1;
//}

#endregion
#region 2
//const int INIT_CHANNEL = 100;

//using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
//using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
//var n = int.Parse(rs.ReadLine());
//var m = int.Parse(rs.ReadLine());
//var brokenButtons = m > 0 ? rs.ReadLine().Split().Select(int.Parse).ToArray() : new int[0];

//ws.WriteLine(GetPressCount(n, brokenButtons));

//int GetPressCount(int n, int[] brokenButtons)
//{
//    var pressCount = Math.Abs(n - INIT_CHANNEL);
//    var digitN = GetDigit(n);
//    var maxChannel = Math.Pow(10, digitN + 1);

//    for (int i = 0; i < maxChannel; i++)
//    {
//        if (ContainsBrokenButton(i, brokenButtons))
//            continue;

//        var currPressCount = Math.Abs(n - i) + GetDigit(i);
//        pressCount = Math.Min(pressCount, currPressCount);
//    }

//    return pressCount;
//}

//bool ContainsBrokenButton(int value, int[] brokenButtons)
//{
//    if (value == 0)
//        return brokenButtons.Contains(value);

//    while (value > 0)
//    {
//        var numOfEnd = value % 10;
//        if (brokenButtons.Contains(numOfEnd))
//            return true;

//        value /= 10;
//    }

//    return false;
//}

//int GetDigit(int value) => value <= 0 ? 1 : (int)Math.Log10(value) + 1;
#endregion
#region 3

//const int INIT_CHANNEL = 100;

//using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
//using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
//var n = int.Parse(rs.ReadLine());
//var m = int.Parse(rs.ReadLine());
//var brokenButtons = m > 0 ? rs.ReadLine().Split().Select(int.Parse).ToArray() : new int[0];
//var brokenStates = new bool[10];
//foreach (var brokenButton in brokenButtons)
//{
//    brokenStates[brokenButton] = true;
//}

//ws.WriteLine(GetPressCount(n, brokenStates));


//int GetPressCount(int n, bool[] brokenStates)
//{
//    var pressCount = Math.Abs(n - INIT_CHANNEL);
//    var digitN = GetDigit(n);
//    var maxChannel = Math.Pow(10, digitN + 1);

//    var currDigit = 1;
//    var digitThresholds = 10;
//    for (int i = 0; i < maxChannel; i++)
//    {
//        if (i >= digitThresholds)
//        {
//            currDigit++;
//            digitThresholds *= 10;
//        }

//        if (ContainsBrokenButton(i, brokenStates))
//            continue;

//        var currPressCount = Math.Abs(n - i) + currDigit;
//        pressCount = Math.Min(pressCount, currPressCount);     
//    }

//    return pressCount;
//}

//bool ContainsBrokenButton(int value, bool[] brokenStates)
//{
//    if (value == 0)
//        return brokenStates[value];

//    while (value > 0)
//    {
//        var numOfEnd = value % 10;
//        if (brokenStates[numOfEnd])
//            return true;

//        value /= 10;
//    }

//    return false;
//}

//int GetDigit(int value) => value <= 0 ? 1 : (int)Math.Log10(value) + 1;
#endregion
#region 4
const int CURRENT_CHANNEL = 100;

using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
var n = int.Parse(rs.ReadLine());
var m = int.Parse(rs.ReadLine());
var brokenButtons = m > 0 ? rs.ReadLine().Split().Select(int.Parse).ToArray() : new int[0];

ws.WriteLine(GetPressCount(n, brokenButtons));

int GetPressCount(int n, int[] brokenButtons)
{
    var unbrokenButtons = Enumerable.Range(0, 10).Except(brokenButtons).ToArray();
    var nLength = n <= 0 ? 1 : (int)Math.Log10(n) + 1;

    var pressCountWithChangedChannel = GetPressCountWithChangedChannel(n, nLength, 0, 0, unbrokenButtons);
    var pressCountWithCurrentChannel = GetPressCountWithCurrentChannel(n);

    return Math.Min(pressCountWithChangedChannel, pressCountWithCurrentChannel);
}

int GetPressCountWithChangedChannel(int n, int nLength, int value, int digit, int[] unbrokenButtons)
{
    if (digit > nLength)
        return CalculatePressCount(n, value, digit);

    var nextDigit = digit + 1;
    var pressCountMin = int.MaxValue;

    foreach (var unbrokenButton in unbrokenButtons)
    {
        var currValue = value + unbrokenButton * (int)Math.Pow(10, digit);

        var nextPressCount = GetPressCountWithChangedChannel(n, nLength, currValue, nextDigit, unbrokenButtons);
        var currPressCount = CalculatePressCount(n, currValue, nextDigit);

        pressCountMin = Math.Min(pressCountMin, Math.Min(nextPressCount, currPressCount));
    }

    return pressCountMin;
}


int GetPressCountWithCurrentChannel(int n) => Math.Abs(n - CURRENT_CHANNEL);

int CalculatePressCount(int n, int value, int valueLength)
{
    if (value <= 0)
        return Math.Abs(n - value) + 1;

    return Math.Abs(n - value) + valueLength;
}
#endregion