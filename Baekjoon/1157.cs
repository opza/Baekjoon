var input = Console.ReadLine();
var upperInput = input.ToUpper();

var charCounts = new Dictionary<char, int>();

char maxChar = ' ';
var lastMaxCount = -1;
var maxCount = -1;

foreach (var item in upperInput)
{
    if (charCounts.ContainsKey(item))
        charCounts[item]++;
    else
        charCounts.Add(item, 1);

    var count = charCounts[item];
    if(count >= maxCount)
    {
        lastMaxCount = maxCount;
        maxCount = count;
        maxChar = item;
    }
}

if (lastMaxCount == maxCount)
    Console.WriteLine("?");
else
    Console.WriteLine(maxChar);