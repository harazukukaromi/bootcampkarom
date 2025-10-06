//Weak References and Events
/*
using System;
using System.Collections.Generic;
using System.Reflection;

public class WeakDelegate<TDelegate> where TDelegate : Delegate
{
    class MethodTarget
    {
        public readonly WeakReference Reference;
        public readonly MethodInfo Method;

        public MethodTarget(Delegate d)
        {
            if (d.Target != null)
                Reference = new WeakReference(d.Target);

            Method = d.Method;
        }
    }

    private List<MethodTarget> _targets = new List<MethodTarget>();

    public void Combine(TDelegate target)
    {
        if (target == null) return;

        foreach (Delegate d in target.GetInvocationList())
        {
            _targets.Add(new MethodTarget(d));
        }
    }

    public void Remove(TDelegate target)
    {
        if (target == null) return;

        foreach (Delegate d in target.GetInvocationList())
        {
            MethodTarget mt = _targets.Find(w =>
                Equals(d.Target, w.Reference?.Target) &&
                Equals(d.Method.MethodHandle, w.Method.MethodHandle));

            if (mt != null)
                _targets.Remove(mt);
        }
    }

    public TDelegate Target
    {
        get
        {
            Delegate combined = null;

            foreach (var mt in _targets.ToArray()) // To allow modification
            {
                var wr = mt.Reference;
                if (wr == null || wr.Target != null)
                {
                    try
                    {
                        Delegate del = Delegate.CreateDelegate(typeof(TDelegate), wr?.Target, mt.Method);
                        combined = Delegate.Combine(combined, del);
                    }
                    catch
                    {
                        // Could not recreate delegate (possibly mismatched target), ignore
                    }
                }
                else
                {
                    // Remove collected reference
                    _targets.Remove(mt);
                }
            }

            return combined as TDelegate;
        }
        set
        {
            _targets.Clear();
            Combine(value);
        }
    }
}

public class Foo
{
    private WeakDelegate<EventHandler> _click = new WeakDelegate<EventHandler>();

    public event EventHandler Click
    {
        add { _click.Combine(value); }
        remove { _click.Remove(value); }
    }

    public void RaiseClick()
    {
        _click.Target?.Invoke(this, EventArgs.Empty);
    }
}

public class Bar
{
    private readonly string _name;

    public Bar(string name)
    {
        _name = name;
    }

    public void HandleClick(object sender, EventArgs e)
    {
        Console.WriteLine($"Bar({_name}) received Click from {sender.GetType().Name}");
    }
}

class Program
{
    static void Main()
    {
        var foo = new Foo();

        // Create a Bar instance and subscribe to Foo.Click using weak delegate
        CreateAndSubscribe(foo);

        // Force GC and raise event — should not call handler if Bar was collected
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Console.WriteLine("Raising Click event...");
        foo.RaiseClick();

        Console.WriteLine("Done.");
        Console.ReadKey();
    }

    static void CreateAndSubscribe(Foo foo)
    {
        var bar = new Bar("WeakBar");
        foo.Click += bar.HandleClick;

        // After this method returns, 'bar' goes out of scope and can be collected
    }
}
*/