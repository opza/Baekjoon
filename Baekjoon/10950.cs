var inputCounts = int.Parse(Console.ReadLine());
for (int i = 0; i < inputCounts; i++)
{
    var inputs = Console.ReadLine().Split();
    var a = int.Parse(inputs[0]);
    var b = int.Parse(inputs[1]);

    Console.WriteLine(a + b);
}