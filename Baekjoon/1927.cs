using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var n = int.Parse(rs.ReadLine());

var priorityQueue = new PriorityQueue<int, int>();
for (int i = 0; i < n; i++)
{
    var inputValue = int.Parse(rs.ReadLine());
    if (inputValue > 0)
        priorityQueue.Enqueue(inputValue, inputValue);
    else
    {
        if (priorityQueue.Count > 0)
            ws.WriteLine(priorityQueue.Dequeue());
        else
            ws.WriteLine("0");
    }
}