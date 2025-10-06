/*using System;
//matematics in Date and times
class Program
{
    static void Main()
    {
        // Starting date
        DateTime startDate = new DateTime(2024, 1, 15, 9, 0, 0);
        Console.WriteLine($"Starting date: {startDate}");

        // Adding time intervals - very common in business logic
        DateTime deadline = startDate.AddDays(30);
        DateTime reminder = deadline.AddDays(-7);
        DateTime urgentReminder = deadline.AddHours(-24);

        Console.WriteLine($"Project deadline: {deadline}");
        Console.WriteLine($"First reminder: {reminder}");
        Console.WriteLine($"Urgent reminder: {urgentReminder}");

        // Adding different time units
        DateTime scheduleExample = startDate
            .AddYears(1)
            .AddMonths(2)
            .AddDays(15)
            .AddHours(3)
            .AddMinutes(30)
            .AddSeconds(30);

        Console.WriteLine($"Complex schedule: {scheduleExample}");

        // Calculating business days (excluding weekends)
        DateTime businessStart = new DateTime(2024, 5, 27); // Monday
        int businessDaysToAdd = 10;
        DateTime businessEnd = AddBusinessDays(businessStart, businessDaysToAdd);

        Console.WriteLine("Business days calculation:");
        Console.WriteLine($"  Start: {businessStart:yyyy-MM-dd} ({businessStart.DayOfWeek})");
        Console.WriteLine($"  Add {businessDaysToAdd} business days");
        Console.WriteLine($"  End: {businessEnd:yyyy-MM-dd} ({businessEnd.DayOfWeek})");

        // Finding the next occurrence of a specific day
        DateTime nextFriday = GetNextWeekday(DateTime.Today, DayOfWeek.Friday);
        Console.WriteLine($"Next Friday: {nextFriday:yyyy-MM-dd}");

        Console.WriteLine();
    }

    // Helper to add business days (excludes weekends)
    static DateTime AddBusinessDays(DateTime startDate, int businessDays)
    {
        int addedDays = 0;
        DateTime currentDate = startDate;

        while (addedDays < businessDays)
        {
            currentDate = currentDate.AddDays(1);
            if (currentDate.DayOfWeek != DayOfWeek.Saturday &&
                currentDate.DayOfWeek != DayOfWeek.Sunday)
            {
                addedDays++;
            }
        }

        return currentDate;
    }

    // Helper to get the next occurrence of a specific weekday
    static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
    {
        int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
        return start.AddDays(daysToAdd == 0 ? 7 : daysToAdd);
    }
}*/
