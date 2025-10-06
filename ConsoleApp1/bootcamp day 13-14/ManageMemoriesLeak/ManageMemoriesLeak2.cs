/*
using System;
using System.Timers;

//System.Timers.Timer
class Foo
{
    private System.Timers.Timer _timer;

    public Foo()
    {
        _timer = new System.Timers.Timer
        {
            Interval = 1000,   // 1 second
            AutoReset = true,  // Keep raising the event
            Enabled = true     // Start timer immediately
        };

        _timer.Elapsed += tmr_Elapsed;
        _timer.Start();
    }

    private void tmr_Elapsed(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine($"Timer elapsed at {e.SignalTime:HH:mm:ss}");
    }
}

class Program
{
    static void Main()
    {
        Foo foo = new Foo();

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine(); // Keep the app running
    }
}
*/
