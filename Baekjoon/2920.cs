var ascendingSequence = new int[]
{
    1, 2, 3, 4, 5, 6, 7, 8
};

var numbers = Console.ReadLine().Split().Select(int.Parse);

if (numbers.SequenceEqual(ascendingSequence))
    Console.WriteLine("ascending");
else if(numbers.Reverse().SequenceEqual(ascendingSequence))
    Console.WriteLine("descending");
else
    Console.WriteLine("mixed");

