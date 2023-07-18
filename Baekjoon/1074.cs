var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
var n = inputs[0];
var r = inputs[1];
var c = inputs[2];

Console.WriteLine(GetIndexOnMatrix(0, n, r, c));


int GetIndexOnMatrix(int pivot, int n, int r, int c)
{
    if(n <= 1)
    {
        return pivot + (r * 2 + c);
    }

    var height = (int)Math.Pow(2, n);
    var width = (int)Math.Pow(2, n);

    var quarterValue = (int)Math.Pow(Math.Pow(2, n-1), 2);
    if (r >= height / 2)
    {
        r -= height / 2;
        if (c >= width / 2)
        {
            pivot += quarterValue * 3;
            c -= width / 2;
        }
        else       
            pivot += quarterValue * 2;
        
    }
    else
    {
        if (c >= width / 2)
        {
            pivot += quarterValue * 1;
            c -= width / 2;
        }
        else
            pivot += quarterValue * 0;
    }

    return GetIndexOnMatrix(pivot, n - 1, r, c);
}

