const string END_OF_LINE = "0";

using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
ws.AutoFlush = true;

while (true)
{
    var value = rs.ReadLine();
    if (value == END_OF_LINE)
        break;

    var isPalindrome = IsPalindrome(value);
    if (isPalindrome)
        ws.WriteLine("yes");
    else
        ws.WriteLine("no");
}

bool IsPalindrome(string value)
{
    var half = value.Length / 2;
    for (int i = 0; i < half; i++)
    {
        if (value[i] != value[value.Length - 1 - i])
            return false;
    }

    return true;
}