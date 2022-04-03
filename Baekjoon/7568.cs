using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var caseCount = int.Parse(rs.ReadLine());

var humans = new Human[caseCount];
var humanComparer = new HumanComparer();

for (int i = 0; i < caseCount; i++)
{
    var inputs = rs.ReadLine().Split();
    var kg = int.Parse(inputs[0]);
    var stature = int.Parse(inputs[1]);

    var human = new Human(kg, stature);
    humans[i] = human;

    for (int j = i - 1; j >= 0; j--)
    {
        var comparedHuman = humans[j];
        var compared = humanComparer.Compare(human, comparedHuman);
        if (compared > 0)
            comparedHuman.Rank++;
        else if (compared < 0)
            human.Rank++;
    }
}

for (int i = 0; i < caseCount - 1; i++)
{
    ws.Write($"{humans[i].Rank} ");
}
ws.Write(humans[caseCount - 1].Rank);

class Human
{
    public int Rank { get; set; } = 1;
    public int Kg { get; }
    public int Stature { get; }

    public Human(int kg, int stature)
    {
        Kg = kg;
        Stature = stature;
    }
}

class HumanComparer : IComparer<Human>
{
    public int Compare(Human x, Human y)
    {
        var compared = x.Kg.CompareTo(y.Kg) + x.Stature.CompareTo(y.Stature);
        if (compared > 1)
            return 1;
        else if (compared < -1)
            return -1;
        else
            return 0;
    }
}