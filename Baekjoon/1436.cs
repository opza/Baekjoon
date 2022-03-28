#region 1
//using System.Text.RegularExpressions;

//var regex = new Regex(".*666.*");
//var n = int.Parse(Console.ReadLine());

//var curr = 0;
//var value = 0;
//while (true)
//{
//    if(HasDoomsdayNumber(value))
//    {
//        curr++;

//        if (curr == n)
//            break;
//    }

//    value++;
//}

//Console.WriteLine(value);

//bool HasDoomsdayNumber(int value) => regex.IsMatch(value.ToString());
#endregion
#region 2
//using System.Text.RegularExpressions;

const int DOOMSDAY_NUMBER = 666;

var n = int.Parse(Console.ReadLine());

var curr = 0;
var value = 0;
while (true)
{
    if (HasDoomsdayNumber(value))
    {
        curr++;

        if (curr == n)
            break;
    }

    value++;
}

Console.WriteLine(value);

bool HasDoomsdayNumber(int value)
{
    while(value != 0)
    {
        if (value % 1000 == DOOMSDAY_NUMBER)
            return true;

        value /= 10;
    }

    return false;
}
#endregion