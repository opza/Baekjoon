const int MAX_PRIORITY = 9;

using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var caseCount = int.Parse(rs.ReadLine());
for (int i = 0; i < caseCount; i++)
{
    var inputs = rs.ReadLine().Split();
    var docCount = int.Parse(inputs[0]);
    var targetIndex = int.Parse(inputs[1]);

    var docs = rs.ReadLine().Split()
        .Select(int.Parse)
        .Select(v => new PriorityElement(v, v))
        .ToArray();

    var targetDoc = docs[targetIndex];

    var queue = new Queue<PriorityElement>(docs);
    var count = 0;
    while (true)
    {
        var dequeuedDoc = queue.Dequeue();
        if (queue.Any(doc => doc.Priority > dequeuedDoc.Priority))
            queue.Enqueue(dequeuedDoc);
        else
        {
            count++;

            if (dequeuedDoc == targetDoc)
                break;
        }
    }

    ws.WriteLine(count);
}

class PriorityElement
{
    public int Value { get; }
    public int Priority { get; }

    public PriorityElement(int value, int priority)
    {
        Value = value;
        Priority = priority;
    }
}

