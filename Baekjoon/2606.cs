
using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var nodeCount = int.Parse(rs.ReadLine());
var connectionCount = int.Parse(rs.ReadLine());

var nodes = new Node[nodeCount + 1];
for (int i = 1; i < nodes.Length; i++)
{
    nodes[i] = new Node();
}

for (int i = 0; i < connectionCount; i++)
{
    var inputConnections = rs.ReadLine().Split().Select(int.Parse).ToArray();
    var nodeA = nodes[inputConnections[0]];
    var nodeB = nodes[inputConnections[1]];

    nodeA.Neighbors.Add(nodeB);
    nodeB.Neighbors.Add(nodeA);
}

ws.WriteLine(GetVisitedNodes(nodes[1]) - 1);

int GetVisitedNodes(Node currNode)
{
    if (currNode.IsVisited)
        return 0;

    currNode.IsVisited = true;

    var sum = 1;
    foreach (var neighbor in currNode.Neighbors)
    {
        sum += GetVisitedNodes(neighbor);
    }

    return sum;
}

class Node
{
    public List<Node> Neighbors { get; } = new List<Node>();
    public bool IsVisited { get; set; }
}