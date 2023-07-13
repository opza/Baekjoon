using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var inputDate1 = rs.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
var inputDate2 = rs.ReadLine().Split().Select(s => int.Parse(s)).ToArray();

var todayDate = new DateTime(inputDate1[0], inputDate1[1], inputDate1[2]);
var dDayDate = new DateTime(inputDate2[0], inputDate2[1], inputDate2[2]);

if (IsDiffOver1000Year(todayDate, dDayDate))
    ws.WriteLine("gg");
else 
{ 
    var leftDate = dDayDate - todayDate;
    ws.WriteLine($"D-{leftDate.Days}");
}


static bool IsDiffOver1000Year(DateTime todayDate, DateTime dDayDate)
{
    var yearDiff = dDayDate.Year - todayDate.Year;
    if (yearDiff > 1000)
        return true;
    else if(yearDiff == 1000)
        return dDayDate.Month >= todayDate.Month && dDayDate.Day >= todayDate.Day;

    return false;
}

//static bool IsLeapYear(int year)
//{
//    if(year % 4 == 0)
//    {
//        if(year % 100 == 0)
//        {
//            if (year % 400 == 0)
//                return true;

//            return false;
//        }

//        return true;
//    }

//    return false;
//}