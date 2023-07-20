const int CHANNEL_MAX = 500000;
const int CURRENT_CHANNEL = 100;

using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
var n = int.Parse(rs.ReadLine());
var m = int.Parse(rs.ReadLine());
var brokenButtons = m > 0 ? rs.ReadLine().Split().Select(int.Parse).ToArray() : new int[0];

ws.WriteLine(GetPressCount(n, brokenButtons));

//var unbrokenButtons = Enumerable.Range(0, 10).Except(brokenButtons).ToArray();
//ws.WriteLine(Test(n, 0, 0, unbrokenButtons));

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
        return CalculatePressCount(n, value);

    var nextDigit = digit + 1;
    var pressCountMin = int.MaxValue;

    foreach (var unbrokenButton in unbrokenButtons)
    {
        var currValue = value + unbrokenButton * (int)Math.Pow(10, digit);

        var nextPressCount = GetPressCountWithChangedChannel(n, nLength, currValue, nextDigit, unbrokenButtons);
        var currPressCount = CalculatePressCount(n, currValue);

        pressCountMin = Math.Min(pressCountMin, Math.Min(nextPressCount, currPressCount));
    }

    return pressCountMin;
}


int GetPressCountWithCurrentChannel(int n) => Math.Abs(n - CURRENT_CHANNEL);

int CalculatePressCount(int n, int value)
{
    if (value <= 0)
        return Math.Abs(n - value) + 1;

    return Math.Abs(n - value) + (int)Math.Log10(value) + 1;
}

(int, int) Test(int n, int currValue, int currDigit, int[] unbrokenButtons)
{
    var digitMaxValue = currDigit > 0 ? (int)Math.Pow(10, currDigit) : 0;
    if (digitMaxValue / 10 >= n)
    {
        //if(digitMaxValue / 10 >= n)
        //    return (Math.Abs(n - currValue) + currDigit, currValue);

        var topValue = (Math.Abs(n - currValue) + currDigit, currValue);
        var bottomValue = (Math.Abs(n - currValue % (digitMaxValue / 10)) + currDigit - 1, currValue % (digitMaxValue / 10));

        return topValue.Item1 < bottomValue.Item1 ? topValue : bottomValue;
    }

    var pressCount = (int.MaxValue, int.MaxValue);

    foreach (var unbrokenButton in unbrokenButtons)
    {
        var nextValue = currValue + unbrokenButton * (int)Math.Pow(10, currDigit);

        var nextDigit = currDigit + 1;
        var val = Test(n, nextValue, nextDigit, unbrokenButtons);
        pressCount = val.Item1 < pressCount.Item1 ? val : pressCount;
    }

    return pressCount;
}


//ws.WriteLine(GetPressCount(n, brokenButtons));

//int GetPressCount(int n, int[] brokenButtons)
//{
//    var pressCountWithChangedChannel = GetPressCountWithChangedChannel(n, brokenButtons);
//    var pressCountWithCurrentChannel = GetPressCountWithCurrentChannel(n);

//    if (pressCountWithChangedChannel < 0)
//        return pressCountWithCurrentChannel;

//    return Math.Min(pressCountWithChangedChannel, pressCountWithCurrentChannel);
//}

//int GetPressCountWithChangedChannel(int n, int[] brokenButtons)
//{
//    var pressCount = 0;
//    var oriN = n;
//    var nearbyCh = 0;
//    var unbrokenButtons = Enumerable.Range(0, 10).Except(brokenButtons).ToArray();

//    var currDigit = 1;
//    while (n > 0)
//    {
//        var target = n % 10;
//        var nearbyValue = GetNearestValue(target, unbrokenButtons);
//        if (nearbyValue < 0)
//            return -1;

//        nearbyCh += nearbyValue * currDigit;

//        n /= 10;
//        currDigit *= 10;
//        pressCount++;
//    }

//    pressCount += Math.Abs(oriN - nearbyCh);

//    return pressCount;
//}

//int GetPressCountWithCurrentChannel(int n) => Math.Abs(n - CURRENT_CHANNEL);

//int GetNearestValue(int target, int[] unbrokenButtons)
//{
//    if (unbrokenButtons.Length <= 0)
//        return -1;

//    if (unbrokenButtons.Length == 1)
//        return unbrokenButtons[0];

//    if (target <= unbrokenButtons[0])
//        return unbrokenButtons[0];

//    if (target >= unbrokenButtons[unbrokenButtons.Length - 1])
//        return unbrokenButtons[unbrokenButtons.Length - 1];

//    for (int i = 0; i < unbrokenButtons.Length - 1; i++)
//    {
//        var lastValue = unbrokenButtons[i];
//        var nextValue = unbrokenButtons[i + 1];

//        if (target >= lastValue && target <= nextValue)
//            return target - lastValue <= nextValue - target ? lastValue : nextValue;
//    }

//    return -1;
//}

