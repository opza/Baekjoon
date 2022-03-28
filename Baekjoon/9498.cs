var score = int.Parse(Console.ReadLine());
if (score <= 100 && score >= 90)
    Console.WriteLine("A");
else if (score <= 89 && score >= 80)
    Console.WriteLine("B");
else if (score <= 79 && score >= 70)
    Console.WriteLine("C");
else if(score <= 69 && score >= 60)
    Console.WriteLine("D");
else
    Console.WriteLine("F");