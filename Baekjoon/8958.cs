var inputCount = int.Parse(Console.ReadLine());
var quizTables = new List<string>();
for (int i = 0; i < inputCount; i++)
{
    quizTables.Add(Console.ReadLine());
}

foreach (var quizTable in quizTables)
{
    Console.WriteLine(CalculateQuizPoint(quizTable));
}

int CalculateQuizPoint(string quizTable)
{
    var totalPoint = 0;
    var lastPoint = 0;
    foreach (var answer in quizTable)
    {
        if (answer == 'O')
            totalPoint += ++lastPoint;
        else
            lastPoint = 0;
    }

    return totalPoint;
}