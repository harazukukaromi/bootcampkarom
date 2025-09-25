/*
using System;
using System.IO;

//Calling Dispose() from a Finalizer (The Dispose Pattern)
class Test : IDisposable
{
    private FileStream? _fileStream;
    private bool _disposed = false;

    public Test(string filePath)
    {
        // Simulate managed resource
        _fileStream = new FileStream(filePath, FileMode.Create);
        Console.WriteLine("FileStream opened.");
    }

    // Public Dispose method — called explicitly or by using-statement
    public void Dispose()
    {
        Dispose(true); // Dispose managed + unmanaged
        GC.SuppressFinalize(this); // Finalizer not needed
    }

    // Protected virtual Dispose method
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            // Dispose managed resources
            if (_fileStream != null)
            {
                _fileStream.Close();
                _fileStream.Dispose();
                _fileStream = null;
                Console.WriteLine("FileStream disposed.");
            }
        }

        // Release unmanaged resources here if any (none in this example)
        // Example: free unmanaged memory, close OS handles, etc.

        _disposed = true;
    }

    // Finalizer — called by GC if Dispose() is not called manually
    ~Test()
    {
        Dispose(false);
        Console.WriteLine("Finalizer called.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Program started.\n");

        using (Test test = new Test("test.txt"))
        {
            Console.WriteLine("Using Test object.");
            // Use the object...
        } // Dispose() is called automatically here

        Console.WriteLine("\nExited using block.");

        // Force GC to show finalizer is skipped (because we used Dispose)
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("\nProgram ended.");
    }
}*/
