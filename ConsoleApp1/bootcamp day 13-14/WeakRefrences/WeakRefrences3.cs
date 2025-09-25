/*
// Weak References and Caching
using System;

class ExpensiveDataCache
{
    private WeakReference _weakCache;

    public object GetData()
    {
        var cache = _weakCache?.Target;

        if (cache == null)
        {
            Console.WriteLine("Cache miss — creating data...");
            cache = CreateExpensiveData();
            _weakCache = new WeakReference(cache);
        }
        else
        {
            Console.WriteLine("Cache hit — reusing data.");
        }

        return cache;
    }

    private object CreateExpensiveData()
    {
        // Simulate a large object (e.g., big array or graph)
        return new byte[1024 * 1024 * 10]; // 10 MB array
    }
}

class Program
{
    static void Main()
    {
        var cacheManager = new ExpensiveDataCache();

        // First access - cache miss
        var data1 = cacheManager.GetData();

        // Force GC to possibly collect the cached object
        data1 = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // Second access - could be hit or miss depending on GC
        var data2 = cacheManager.GetData();

        Console.WriteLine("Done. Press any key to exit.");
        Console.ReadKey();
    }
}
*/