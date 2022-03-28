#region 1
//var inputCount = int.Parse(Console.ReadLine());
//var words = new string[inputCount];
//for (int i = 0; i < words.Length; i++)
//{
//    words[i] = Console.ReadLine();
//}

//var wordComparer = new WordComparer();
//var sortedWords = words.Distinct().OrderBy(word => word, wordComparer);

//foreach (var word in sortedWords)
//{
//    Console.WriteLine(word);
//}

//class WordComparer : IComparer<string>
//{
//    public int Compare(string? x, string? y)
//    {
//        if (x.Length < y.Length)
//            return -1;
//        else if (x.Length > y.Length)
//            return 1;
//        else
//        {
//            for (int i = 0; i < x.Length; i++)
//            {
//                var compare = x[i].CompareTo(y[i]);
//                if (compare != 0)
//                    return compare;
//            }

//            return 0;
//        }
//    }
//}
#endregion
#region 2

using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var inputCount = int.Parse(rs.ReadLine());
var words = new string[inputCount];
for (int i = 0; i < words.Length; i++)
    words[i] = rs.ReadLine();

var sortedWords = from word in words.Distinct()
                  orderby word.Length, word
                  select word;

foreach (var word in sortedWords)
    ws.WriteLine(word);




#endregion