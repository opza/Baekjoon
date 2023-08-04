//using System.Diagnostics;

using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var n = int.Parse(rs.ReadLine());

var schedules = new Schedule[n];
for (int i = 0; i < n; i++)
{
    var inputSchedule = rs.ReadLine().Split().Select(int.Parse).ToArray();
    schedules[i] = new Schedule(inputSchedule[0], inputSchedule[1]);
}

Array.Sort(schedules, new ScheduleComparer());

ws.WriteLine(GetMaxScheduleCount(schedules));


int GetMaxScheduleCount(Schedule[] schedules)
{
    var currSchedule = schedules[0];
    var count = 1;

    for (int i = 0; i < schedules.Length - 1; i++)
    {
        var nextSchedule = schedules[i + 1];
        if (currSchedule.IsOverlap(nextSchedule))
            continue;

        currSchedule = nextSchedule;
        count++;
    }

    return count;
}

//[DebuggerDisplay("{StartTime} {EndTime}")]
class Schedule
{
    int _startTime;
    int _endTime;

    public int StartTime => _startTime;
    public int EndTime => _endTime;

    public Schedule(int startTime, int endTime)
    {
        _startTime = startTime;
        _endTime = endTime;
    }

    public bool IsOverlap(Schedule other) => other._startTime < _endTime;

}

class ScheduleComparer : IComparer<Schedule>
{
    public int Compare(Schedule? x, Schedule? y)
    {
        var compared = x.EndTime.CompareTo(y.EndTime);
        if(compared == 0)
            return x.StartTime.CompareTo(y.StartTime);

        return compared;
    }

}