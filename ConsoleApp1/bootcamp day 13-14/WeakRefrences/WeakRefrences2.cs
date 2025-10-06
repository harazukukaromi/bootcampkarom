/*
//Use Case: Tracking Objects Without Preventing Collection
using System;
using System.Collections.Generic;

class Widget
{
    private static List<WeakReference> _allWidgets = new List<WeakReference>();
    public readonly string Name;

    public Widget(string name)
    {
        Name = name;
        _allWidgets.Add(new WeakReference(this));
    }

    public static void ListAllWidgets()
    {
        Console.WriteLine("Alive Widgets:");
        foreach (WeakReference weak in _allWidgets)
        {
            Widget w = weak.Target as Widget;
            if (w != null)
            {
                Console.WriteLine($" - {w.Name}");
            }
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Create widgets
        var w1 = new Widget("Alpha");
        var w2 = new Widget("Beta");
        var w3 = new Widget("Gamma");

        // List widgets (all should be alive)
        Widget.ListAllWidgets();

        // Drop strong references to w2 and w3
        w2 = null;
        w3 = null;

        // Force garbage collection
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // List widgets again (w2 and w3 may be gone)
        Widget.ListAllWidgets();

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
*/