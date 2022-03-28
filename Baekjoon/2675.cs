var caseCount = int.Parse(Console.ReadLine());
for (int i = 0; i < caseCount; i++)
{
    var inputs = Console.ReadLine().Split();
    var count = int.Parse(inputs[0]);
    var str = inputs[1];

    foreach (var c in str)
    {
        for (int j = 0; j < count; j++)
        {
            Console.Write(c);
        }       
    }

    Console.WriteLine();
}