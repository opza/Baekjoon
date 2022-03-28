const int MASK_HEIGHT = 8;
const int MASK_WIDTH = 8;

var mask1 = new char[MASK_HEIGHT, MASK_WIDTH]
{
    {'W', 'B', 'W', 'B', 'W', 'B', 'W', 'B' },
    {'B', 'W', 'B', 'W', 'B', 'W', 'B', 'W',},
    {'W', 'B', 'W', 'B', 'W', 'B', 'W', 'B' },
    {'B', 'W', 'B', 'W', 'B', 'W', 'B', 'W',},
    {'W', 'B', 'W', 'B', 'W', 'B', 'W', 'B' },
    {'B', 'W', 'B', 'W', 'B', 'W', 'B', 'W',},
    {'W', 'B', 'W', 'B', 'W', 'B', 'W', 'B' },
    {'B', 'W', 'B', 'W', 'B', 'W', 'B', 'W',}
};

var mask2 = new char[MASK_HEIGHT, MASK_WIDTH]
{
    {'B', 'W', 'B', 'W', 'B', 'W', 'B', 'W',},
    {'W', 'B', 'W', 'B', 'W', 'B', 'W', 'B' },
    {'B', 'W', 'B', 'W', 'B', 'W', 'B', 'W',},
    {'W', 'B', 'W', 'B', 'W', 'B', 'W', 'B' },
    {'B', 'W', 'B', 'W', 'B', 'W', 'B', 'W',},
    {'W', 'B', 'W', 'B', 'W', 'B', 'W', 'B' },
    {'B', 'W', 'B', 'W', 'B', 'W', 'B', 'W',},
    {'W', 'B', 'W', 'B', 'W', 'B', 'W', 'B' }
};

var inputCounts = Console.ReadLine().Split();
var h = int.Parse(inputCounts[0]);
var w = int.Parse(inputCounts[1]);

var matrix = new char[h, w];

for (int y = 0; y < h; y++)
{
    var chars = Console.ReadLine().ToCharArray();
    for (int x = 0; x < w; x++)
    {
        matrix[y, x] = chars[x];
    }
}

var minCount = int.MaxValue;
for (int offsetY = 0; offsetY + MASK_HEIGHT <= h; offsetY++)
{
    for (int offsetX = 0; offsetX + MASK_WIDTH <= w; offsetX++)
    {
        var count = CountChangedBox(matrix, mask1, offsetY, offsetX);
        if (count < minCount)
            minCount = count;

        count = CountChangedBox(matrix, mask2, offsetY, offsetX);
        if (count < minCount)
            minCount = count;

        if(minCount == 0)
        {
            Console.WriteLine(minCount);
            return;
        }
    }
}

Console.WriteLine(minCount);

int CountChangedBox(char[,] matrix, char[,] mask, int offsetY, int offsetX)
{
    var changedCount = 0;
    for (int y = 0; y < MASK_HEIGHT; y++)
    {
        for (int x = 0; x < MASK_WIDTH; x++)
        {
            if (matrix[y + offsetY, x + offsetX] != mask[y, x])
                changedCount++;
        }
    }

    return changedCount;
}
