#region 0
//using System.Diagnostics;
//using System.Runtime.CompilerServices;

//using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
//using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
//var size = rs.ReadLine().Split().Select(int.Parse).ToArray();

//var world = new World(size[1], size[0]);
//for (int y = 0; y < world.Height; y++)
//{
//	var lineX = rs.ReadLine().Select(Char.GetNumericValue).ToArray();
//	for (int x = 0; x < lineX.Length; x++)
//	{
//		var tile = world.Tiles[x, y];
//		if (lineX[x] == 1)
//			tile.Walkable = true;
//	}
//}

//ws.WriteLine(world.FindShortestPath(0, 0, world.Width - 1, world.Height - 1));

//class World
//{
//	int _width;
//	int _height;
//	Tile[,] _tiles;

//	public int Width => _width;
//	public int Height => _height;
//	public Tile[,] Tiles => _tiles;

//	public World(int width, int height)
//	{
//		_width = width;
//		_height = height;

//		_tiles = new Tile[_width, _height];
//		for (int x = 0; x < _width; x++)
//		{
//			for (int y = 0; y < _height; y++)
//			{
//				_tiles[x, y] = new Tile(x, y);
//			}
//		}
//	}

//	public int FindShortestPath(int startX, int startY, int destX, int destY)
//	{
//		var startTile = _tiles[startX, startY];
//		var destTile = _tiles[destX, destY];

//		var openSet = new Queue<Tile>();
//		var closeSet = new List<Tile>();
//		var distances = new Dictionary<Tile, int>();

//		openSet.Enqueue(startTile);
//		distances.Add(startTile, 1);

//		while (openSet.Count > 0)
//		{
//			var currTile = openSet.Dequeue();
//			var currTileDistance = distances[currTile];

//			closeSet.Add(currTile);

//			var neighbors = GetNeighbors(currTile);
//			foreach (var neighbor in neighbors)
//			{
//				if (neighbor == destTile)
//					return currTileDistance + 1;

//				if (!neighbor.Walkable)
//					continue;

//				if (closeSet.Contains(neighbor))
//					continue;

//				if (openSet.Contains(neighbor))
//					continue;

//				openSet.Enqueue(neighbor);
//				distances[neighbor] = currTileDistance + 1;
//			}
//		}

//		throw new Exception("경로 없음");
//	}

//	Tile[] GetNeighbors(Tile tile)
//	{
//		var neighbors = new List<Tile>();
//		if (tile.Y - 1 >= 0)
//			neighbors.Add(_tiles[tile.X, tile.Y - 1]);

//		if (tile.X + 1 < _width)
//			neighbors.Add(_tiles[tile.X + 1, tile.Y]);

//		if(tile.X - 1 >= 0)
//			neighbors.Add(_tiles[tile.X - 1, tile.Y]);

//		if (tile.Y + 1 < _height)
//			neighbors.Add(_tiles[tile.X, tile.Y + 1]);

//		return neighbors.ToArray();
//	}
//}

//[DebuggerDisplay("{X},{Y}")]
//class Tile
//{
//	int _x;
//	int _y;

//	public int X => _x;
//	public int Y => _y;
//	public bool Walkable { get; set; }

//	public Tile(int x, int y)
//	{
//		_x = x;
//		_y = y;
//	}
//}
#endregion
#region 1
using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
var size = rs.ReadLine().Split().Select(int.Parse).ToArray();

var world = new World(size[1], size[0]);
for (int y = 0; y < world.Height; y++)
{
    var lineX = rs.ReadLine().Select(Char.GetNumericValue).ToArray();
    for (int x = 0; x < lineX.Length; x++)
    {
        var tile = world.Tiles[x, y];
        if (lineX[x] == 1)
            tile.Walkable = true;
    }
}

ws.WriteLine(world.FindShortestPath(0, 0, world.Width - 1, world.Height - 1));

class World
{
    int _width;
    int _height;
    Tile[,] _tiles;

    public int Width => _width;
    public int Height => _height;
    public Tile[,] Tiles => _tiles;

    public World(int width, int height)
    {
        _width = width;
        _height = height;

        _tiles = new Tile[_width, _height];
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _tiles[x, y] = new Tile(x, y);
            }
        }
    }

    public int FindShortestPath(int startX, int startY, int destX, int destY)
    {
        var startTile = _tiles[startX, startY];
        var destTile = _tiles[destX, destY];

        var openSet = new Queue<Tile>();
        var distances = new Dictionary<Tile, int>();

        openSet.Enqueue(startTile);
        distances.Add(startTile, 1);

        while (openSet.Count > 0)
        {
            var currTile = openSet.Dequeue();
            var currTileDistance = distances[currTile];

            var neighbors = GetNeighbors(currTile);
            foreach (var neighbor in neighbors)
            {
                if (neighbor == destTile)
                    return currTileDistance + 1;

                if (!neighbor.Walkable)
                    continue;

                if (distances.ContainsKey(neighbor))
                    continue;

                openSet.Enqueue(neighbor);
                distances.Add(neighbor, currTileDistance + 1);
            }
        }

        throw new Exception("경로 없음");
    }

    Tile[] GetNeighbors(Tile tile)
    {
        var neighbors = new List<Tile>();
        if (tile.Y - 1 >= 0)
            neighbors.Add(_tiles[tile.X, tile.Y - 1]);

        if (tile.X + 1 < _width)
            neighbors.Add(_tiles[tile.X + 1, tile.Y]);

        if (tile.X - 1 >= 0)
            neighbors.Add(_tiles[tile.X - 1, tile.Y]);

        if (tile.Y + 1 < _height)
            neighbors.Add(_tiles[tile.X, tile.Y + 1]);

        return neighbors.ToArray();
    }
}

class Tile
{
    int _x;
    int _y;

    public int X => _x;
    public int Y => _y;
    public bool Walkable { get; set; }

    public Tile(int x, int y)
    {
        _x = x;
        _y = y;
    }
}
#endregion