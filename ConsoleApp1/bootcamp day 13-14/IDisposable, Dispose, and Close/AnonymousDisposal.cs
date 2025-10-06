/*
using System;

class Foo
{
    private int _suspendCount = 0;

    // Method that returns an anonymous IDisposable
    public IDisposable SuspendEvents()
    {
        _suspendCount++;
        Console.WriteLine($"Events suspended. Count: {_suspendCount}");

        return new AnonymousDisposable(() =>
        {
            _suspendCount--;
            Console.WriteLine($"Events resumed. Count: {_suspendCount}");
        });
    }

    private class AnonymousDisposable : IDisposable
    {
        private Action _disposeAction;
        private bool _disposed;

        public AnonymousDisposable(Action disposeAction)
        {
            _disposeAction = disposeAction;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposeAction?.Invoke();
                _disposeAction = null;
                _disposed = true;
            }
        }
    }
}
class Program
{
    static void Main()
    {
        var foo = new Foo();

        using (foo.SuspendEvents())
        {
            Console.WriteLine("Inside suspended block...");
            // Events are suspended here
        } // Dispose is automatically called here, resuming events

        Console.WriteLine("Outside suspended block...");
    }
}
*/

