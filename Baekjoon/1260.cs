using System.Text;

using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var inputs = rs.ReadLine().Split()
    .Select(s => int.Parse(s))
    .ToArray();

var n = inputs[0];
var m = inputs[1];
var v = inputs[2];

var nodes = new Dictionary<int, Node>();

for (int i = 0; i < n; i++)
{
    nodes.Add(i + 1, new Node());
}

for (int i = 0; i < m; i++)
{
    var points = rs.ReadLine().Split()
        .Select(s => int.Parse(s))
        .ToArray();

    nodes[points[0]].Neighbors.Add(points[1]);
    nodes[points[1]].Neighbors.Add(points[0]);
}

foreach (var node in nodes.Values)
{
    node.Neighbors.Sort();
}

PrintDFS(nodes, v);
PrintBFS(nodes, v);

void PrintDFS(Dictionary<int, Node> nodes, int startPos)
{
    var dfsNodes = new Dictionary<int, Node>(nodes);
    var strBuilder = new StringBuilder();
    foreach (var value in ExploreDFS(dfsNodes, startPos))
    {
        strBuilder.Append(value);
        strBuilder.Append(" ");
    }
    strBuilder = strBuilder.Remove(strBuilder.Length - 1, 1);

    ws.WriteLine(strBuilder);
}

void PrintBFS(Dictionary<int, Node> nodes, int startPos)
{
    var bfsNodes = new Dictionary<int, Node>(nodes);
    var strBuilder = new StringBuilder();
    foreach (var value in ExploreBFS(bfsNodes, startPos))
    {
        strBuilder.Append(value);
        strBuilder.Append(" ");
    }
    strBuilder = strBuilder.Remove(strBuilder.Length - 1, 1);

    ws.WriteLine(strBuilder);
}

IEnumerable<int> ExploreDFS(Dictionary<int, Node> nodes, int pos)
{
    if (nodes.ContainsKey(pos))
    {
        var node = nodes[pos];
        nodes.Remove(pos);

        yield return pos;

        foreach (var neighborNodePos in node.Neighbors)
        {
            foreach (var item in ExploreDFS(nodes, neighborNodePos))
            {
                yield return item;
            }
        }
    }
}

IEnumerable<int> ExploreBFS(Dictionary<int, Node> nodes, int pos)
{
    var searchSet = new Dictionary<int, Node>(nodes);

    yield return pos;
    nodes.Remove(pos);

    var nodePosQueue = new Queue<int>();
    nodePosQueue.Enqueue(pos);

    while (nodePosQueue.Count > 0)
    {
        var currPos = nodePosQueue.Dequeue();
        var node = searchSet[currPos];

        foreach (var neighbor in node.Neighbors)
        {
            if (!nodes.ContainsKey(neighbor))
                continue;

            yield return neighbor;
            nodes.Remove(neighbor);
            nodePosQueue.Enqueue(neighbor);
        }
    }
}


class Node
{
    public List<int> Neighbors { get; } = new List<int>();
}