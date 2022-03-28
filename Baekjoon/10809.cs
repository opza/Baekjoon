using System.Text;

var alphabetPositions = new Dictionary<char, int>()
{
    {'a', -1 },
    {'b', -1 },
    {'c', -1 },
    {'d', - 1 },
    {'e', -1 },
    {'f', - 1 },
    {'g', - 1 },
    {'h', - 1 },
    {'i', - 1 },
    {'j', - 1 },
    {'k', - 1 },
    {'l', -1 },
    {'m', - 1 },
    {'n', - 1 },
    {'o', - 1 },
    {'p', - 1 },
    {'q', - 1 },
    {'r', - 1 },
    {'s', - 1 },
    {'t', - 1 },
    {'u', - 1 },
    {'v', - 1 },
    {'w', - 1 },
    {'x', - 1 },
    {'y', - 1 },
    {'z', - 1 }
};


var str = Console.ReadLine();
for (int i = 0; i < str.Length; i++)
{
    var c = str[i];
    if (alphabetPositions[c] >= 0)
        continue;

    alphabetPositions[c] = i;
}

var strBuilder = new StringBuilder();
foreach (var position in alphabetPositions.Values)
{
    strBuilder.Append($"{position} ");
}
strBuilder.Remove(strBuilder.Length - 1, 1);

Console.WriteLine(strBuilder.ToString());
