/*using System;

namespace EventModifiersExample
{
    // 1. Static Event Example
    public static class SystemMonitor
    {
        public static event Action<string> SystemAlert;

        public static void TriggerAlert(string message)
        {
            SystemAlert?.Invoke(message);
        }
    }

    // 2. Base class with a virtual event
    public class BaseService
    {
        public virtual event EventHandler<string> StatusChanged;

        public virtual void ChangeStatus(string status)
        {
            StatusChanged?.Invoke(this, status);
        }
    }

    // 3. Derived class that overrides the virtual event
    public class EnhancedService : BaseService
    {
        private EventHandler<string> _handler;

        public override event EventHandler<string> StatusChanged
        {
            add
            {
                Console.WriteLine("  Handler added to EnhancedService");
                _handler += value;
            }
            remove
            {
                Console.WriteLine("  Handler removed from EnhancedService");
                _handler -= value;
            }
        }

        public override void ChangeStatus(string status)
        {
            _handler?.Invoke(this, "[Enhanced] " + status);
        }
    }

    // 4. Demo Method
    static class Program
    {
        static void Main()
        {
            EventModifiersDemo();
        }

        static void EventModifiersDemo()
        {

            // Demonstrate static events
            Console.WriteLine("Static event demonstration:");
            SystemMonitor.SystemAlert += (msg) => Console.WriteLine($"  System Alert: {msg}");
            SystemMonitor.TriggerAlert("High CPU usage detected");

            // Demonstrate virtual/override events
            Console.WriteLine("\nVirtual/Override event demonstration:");
            BaseService baseService = new EnhancedService();

            baseService.StatusChanged += (sender, status) =>
                Console.WriteLine($"  Status update from {sender.GetType().Name}: {status}");

            // This will use the overridden event behavior
            baseService.ChangeStatus("Enhanced service is running");

            Console.WriteLine();
        }
    }
}*/
