/*
using System;

class Host
{
    public event EventHandler Click;

    public void RaiseClick()
    {
        Click?.Invoke(this, EventArgs.Empty);
    }
}

class Client : IDisposable
{
    private Host _host;
    private bool _disposed;
    private byte[] _bigMemory = new byte[1024 * 1024 * 10]; // 10 MB block for demonstration

    public Client(Host host)
    {
        _host = host;
        _host.Click += HostClicked; // Subscribe
        Console.WriteLine("Client created.");
    }

    void HostClicked(object sender, EventArgs e)
    {
        Console.WriteLine("Client handled Click.");
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            if (_host != null)
            {
                _host.Click -= HostClicked; // Unsubscribe to prevent leak
                _host = null;
            }
            _disposed = true;
            Console.WriteLine("Client disposed (unsubscribed).");
        }
    }

    ~Client()
    {
        Dispose(); // fallback if Dispose not called
    }
}

class Test
{
    static Host _host = new Host(); // long-lived static Host

    public static void CreateClients()
    {
        for (int i = 0; i < 1000; i++)
        {
            using (var client = new Client(_host))
            {
                // do something with client
            } // Dispose is called automatically here
        }
        Console.WriteLine("Created and disposed 1000 clients.");
    }
}

class Program
{
    static void Main()
    {
        Test.CreateClients();

        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("GC run finished. Press Enter...");
        Console.ReadLine();

        Console.WriteLine("Raising click...");
        _host.RaiseClick(); // No leaked clients will handle this
    }

    static Host _host = new Host(); // added here for RaiseClick test
}
*/
