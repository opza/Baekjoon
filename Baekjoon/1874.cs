#region 1
//using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
//using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

//var inputCount = int.Parse(rs.ReadLine());
//var inputArray = new int[inputCount];
//for (int i = 0; i < inputCount; i++)
//{
//    inputArray[i] = int.Parse(rs.ReadLine());
//}


//var commands = new List<char>();
//var stack = new Stack<int>();

//var value = 0;

//for (int i = 0; i < inputCount; i++)
//{
//    var popTarget = inputArray[i];
//    if(popTarget > value)
//    {
//        while (true)
//        {
//            if (popTarget == value)
//            {
//                var popValue = stack.Pop();
//                commands.Add('-');
//                break;
//            }

//            value++;
//            stack.Push(value);
//            commands.Add('+');
//        }
//    }
//    else if(popTarget < value)
//    {
//        if(!stack.Contains(popTarget))
//        {
//            ws.WriteLine("NO");
//            return;
//        }

//        while (true)
//        {
//            var popValue = stack.Pop();
//            commands.Add('-');

//            if (popTarget == popValue)
//                break;          
//        }
//    }
//    else
//    {
//        value++;
//        commands.Add('+');
//        commands.Add('-');
//    }
//}

//foreach (var command in commands)
//{
//    ws.WriteLine(command);
//}
#endregion
#region 2
using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var inputCount = int.Parse(rs.ReadLine());
var inputArray = new int[inputCount];
for (int i = 0; i < inputCount; i++)
{
    inputArray[i] = int.Parse(rs.ReadLine());
}
var recordStack = new RecordStack<int>();
var value = 0;

for (int i = 0; i < inputCount; i++)
{
    var popTarget = inputArray[i];
    if (popTarget > value)
    {
        while (true)
        {
            if (popTarget == value)
            {
                recordStack.Pop();
                break;
            }

            value++;
            recordStack.Push(value);
        }
    }
    else if (popTarget < value)
    {
        if (!recordStack.Contains(popTarget))
        {
            ws.WriteLine("NO");
            return;
        }

        while (true)
        {
            var popValue = recordStack.Pop();
            if (popTarget == popValue)
                break;
        }
    }
    else
    {
        value++;
        recordStack.Push(value);
        recordStack.Pop();
    }
}

foreach (var command in recordStack.Commands)
{
    ws.WriteLine(command);
}

class RecordStack<T>
{
    const char PUSH_COMMAND = '+';
    const char POP_COMMAND = '-';

    Stack<T> stack = new Stack<T>();
    List<char> commands = new List<char>();

    public char[] Commands => commands.ToArray();

    public void Push(T item)
    {
        commands.Add(PUSH_COMMAND);
        stack.Push(item);
    }

    public T Pop()
    {
        commands.Add(POP_COMMAND);
        return stack.Pop();
    }

    public bool Contains(T item) => stack.Contains(item);
}

#endregion