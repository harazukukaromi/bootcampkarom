/*
using System;
using System.Threading;
//System.Threading.Timer is a class that represents a timer that invokes a callback method at specified intervals.
class Program
{
    static void Main()
    {
        // tmr is a local variable, eligible for GC once out of scope
        var tmr = new System.Threading.Timer(TimerTick, null, 1000, 1000);

        // Force garbage collection — this *may* collect the timer if not strongly rooted
        GC.Collect();
        GC.WaitForPendingFinalizers(); // Optional: wait for finalizers to complete

        // Wait 10 seconds to see if the timer keeps ticking
        Thread.Sleep(10000);
    }

    static void TimerTick(object state)
    {
        Console.WriteLine("tick at " + DateTime.Now.ToString("HH:mm:ss"));
    }
}
*/