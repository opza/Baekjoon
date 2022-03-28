const int LATE_MINUTE = 45;
const int DAY_MINUTE = 24 * 60;

var inputs = Console.ReadLine().Split();
var h = int.Parse(inputs[0]);
var mm = int.Parse(inputs[1]);

var totalMm = h * 60 + mm;

var lateTotalMinute = totalMm - LATE_MINUTE;
if (lateTotalMinute < 0)
    lateTotalMinute += DAY_MINUTE;

var lateH = lateTotalMinute / 60;
var lateMm = lateTotalMinute % 60;

Console.WriteLine($"{lateH} {lateMm}");

