using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var caseCount = int.Parse(rs.ReadLine());
var humans = new Human[caseCount];
for (int i = 0; i < caseCount; i++)
{
    var inputs = rs.ReadLine().Split();
    var age = int.Parse(inputs[0]);
    var name = inputs[1];

    humans[i] = new Human(name, age, i);
}

Array.Sort(humans, new HumanComparer());

foreach (var human in humans)
{
    ws.WriteLine($"{human.Age} {human.Name}");
}

class Human
{
    public string Name { get; }
    public int Age { get; }
    public int Priority { get; }

    public Human(string name, int age, int priority)
    {
        Name = name;
        Age = age;
        Priority = priority;
    }
}

class HumanComparer : IComparer<Human>
{
    public int Compare(Human? x, Human? y)
    {
        var compared = x.Age.CompareTo(y.Age);
        if (compared != 0)
            return compared;

        return x.Priority.CompareTo(y.Priority);
    }
}