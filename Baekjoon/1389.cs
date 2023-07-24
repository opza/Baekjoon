using System.Diagnostics;

using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
var inputNM = rs.ReadLine().Split().Select(int.Parse).ToArray();
var n = inputNM[0];
var m = inputNM[1];

var nodes = new Node[n + 1];
for (int i = 1; i < nodes.Length; i++)
{
    nodes[i] = new Node(i, nodes.Length);
}

for (int i = 0; i < m; i++)
{
    var inputsRelation = rs.ReadLine().Split().Select(int.Parse).ToArray();
    var indexA = inputsRelation[0];
    var indexB = inputsRelation[1];

    var nodeA = nodes[indexA];
    var nodeB = nodes[indexB];

    nodeA.Neighbors.Add(nodeB);
    nodeB.Neighbors.Add(nodeA);
}

var miniestKevinBaconValue = int.MaxValue;
Node nodeWithMiniestKevinBaconValue = null;
for (int i = 1; i < nodes.Length; i++)
{
    var nodeA = nodes[i];
    for (int j = i + 1; j < nodes.Length; j++)
    {
        var nodeB = nodes[j];
        var distance = GetShortestDistance(nodeA, nodeB);

        nodeA.Distances[j] = distance;
        nodeB.Distances[i] = distance;
    }

    var kevinBaconValue = nodeA.Distances.Sum();
    if(kevinBaconValue < miniestKevinBaconValue)
    {
        miniestKevinBaconValue = kevinBaconValue;
        nodeWithMiniestKevinBaconValue = nodeA;
    }

}

ws.WriteLine(nodeWithMiniestKevinBaconValue.Index);

int GetShortestDistance(Node startNode, Node destNode)
{
    var distance = 0;
    var openSet = new List<Node>();
    var nextOpenSet = new List<Node>();

    var closeSet = new List<Node>();

    openSet.Add(startNode);

    while (openSet.Count > 0)
    {
        foreach (var currNode in openSet)
        {
            //var calculatedDistance = currNode.Distances[destNode.Index];
            //if (calculatedDistance > 0)
            //    return calculatedDistance + distance;

            closeSet.Add(currNode);

            foreach (var neighbor in currNode.Neighbors)
            {
                if (neighbor == destNode)
                    return distance + 1;

                if (closeSet.Contains(neighbor))
                    continue;

                nextOpenSet.Add(neighbor);
            }
        }

        openSet = new List<Node>(nextOpenSet);
        nextOpenSet.Clear();

        distance++;
    }

    //var distance = 0;
    //var openSet = new Queue<Node>();
    //var closeSet = new List<Node>();

    //openSet.Enqueue(startNode);

    //while (openSet.Count > 0)
    //{
    //    var currNode = openSet.Dequeue();

    //    var calculatedDistance = currNode.Distances[destNode.Index];
    //    if (calculatedDistance > 0)
    //        return calculatedDistance + distance;

    //    distance++;
    //    closeSet.Add(currNode);

    //    foreach (var neighbor in currNode.Neighbors)
    //    {
    //        if (neighbor == destNode)
    //            return distance;

    //        if (closeSet.Contains(neighbor))
    //            continue;

    //        openSet.Enqueue(neighbor);
    //    }
    //}

    throw new Exception("경로 없음");
}

[DebuggerDisplay("Index = {Index}")]
class Node
{
    int _index;
    int[] _distances;

    public int Index => _index;
    public List<Node> Neighbors { get; } = new List<Node>();
    public int[] Distances => _distances;

    public Node(int index, int nodeCount)
    {
        _index = index;
        _distances = new int[nodeCount];
    }
}