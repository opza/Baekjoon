using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var inputs = rs.ReadLine().Split().Select(int.Parse).ToArray();
var cardCount = inputs[0];
var maxValue = inputs[1];

var cards = rs.ReadLine().Split().Select(int.Parse).ToArray();
Array.Sort(cards);

var currMax = -1;
for (int i = cardCount - 1; i >= 2 ; i--)
{
    var cardA = cards[i];
    for (int j = i - 1; j >= 1 ; j--)
    {
        var cardB = cards[j];

        var cardSumAB = cardA + cardB;
        if (cardSumAB >= maxValue)
            continue;

        for (int k = j - 1; k >= 0; k--)
        {
            var cardC = cards[k];
            var cardSumABC = cardSumAB + cardC;
            if (cardSumABC <= maxValue && cardSumABC > currMax)
                currMax = cardSumABC;
        }
    }
}

ws.WriteLine(currMax);