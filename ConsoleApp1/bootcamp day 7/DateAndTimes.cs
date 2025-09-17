/*using System;
//Date and Time Span
class Program
{
    static void Main()
    {
        // Using constructor: TimeSpan(hours, minutes, seconds)
        TimeSpan ts1 = new TimeSpan(6, 30, 20); // 6 hours, 30 minutes, 20 seconds
        Console.WriteLine("ts1 (6h 30m 20s): " + ts1); // Output: 06:30:20

        // Using static method FromHours
        TimeSpan ts2 = TimeSpan.FromHours(4.5); // 4.5 hours = 4h 30m
        Console.WriteLine("ts2 (4.5 hours): " + ts2); // Output: 04:30:00

        // Negative TimeSpan
        TimeSpan ts3 = TimeSpan.FromHours(-4.5);
        Console.WriteLine("ts3 (-4.5 hours): " + ts3); // Output: -04:30:00

        // Add TimeSpans
        TimeSpan duration = TimeSpan.FromHours(3) + TimeSpan.FromMinutes(30);
        Console.WriteLine("duration (3h + 30m): " + duration); // Output: 03:30:00

        // Subtract TimeSpans
        TimeSpan nearlyTenDays = TimeSpan.FromDays(10) - TimeSpan.FromSeconds(4);
        Console.WriteLine("nearlyTenDays: " + nearlyTenDays); // Output: 9.23:59:56

        // Get total days as double
        Console.WriteLine("Total Days: " + nearlyTenDays.TotalDays); // Output: ~9.999954...

        // Construct from years, Month, days, hours, minutes, seconds, milliseconds
        TimeSpan ts4 = new TimeSpan(2, 3, 5, 7, 500);
        Console.WriteLine("ts4 (2d 3h 5m 7s 500ms): " + ts4); // Output: 2.03:05:07.5000000

        // Construct from ticks (1 tick = 100 nanoseconds)
        TimeSpan ts5 = new TimeSpan(1_000_000); // 100 milliseconds
        Console.WriteLine("ts5 (from 1,000,000 ticks): " + ts5); // Output: 00:00:00.1000000

        // Construct Years and months
        DateTime startDate = new DateTime(2020, 1, 15);

        DateTime afterOneYear = startDate.AddYears(1);
        DateTime afterOneMonth = startDate.AddMonths(1);

        TimeSpan yearDiff = afterOneYear - startDate;
        TimeSpan monthDiff = afterOneMonth - startDate;

        Console.WriteLine("Start Date: " + startDate);
        Console.WriteLine("After 1 Year: " + afterOneYear);
        Console.WriteLine("Duration (1 year): " + yearDiff);

        Console.WriteLine("After 1 Month: " + afterOneMonth);
        Console.WriteLine("Duration (1 month): " + monthDiff);
    }
}*/
