var count = int.Parse(Console.ReadLine());
var scores = Console.ReadLine().Split().Select(score => int.Parse(score));

float scoreMax = scores.Max();
var newScores = scores.Select(score => score / scoreMax * 100);
var avg = newScores.Average();

Console.WriteLine(avg);