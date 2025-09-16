/*using System;
//Nullable Struct
public struct MyNullable<T> where T : struct
{
    private readonly T _value;

    public bool HasValue { get; }

    public T Value
    {
        get
        {
            if (!HasValue)
                throw new InvalidOperationException("No value present.");
            return _value;
        }
    }

    // Constructor to set value
    public MyNullable(T value)
    {
        _value = value;
        HasValue = true;
    }

    // GetValueOrDefault with no parameter
    public T GetValueOrDefault()
    {
        return HasValue ? _value : default;
    }

    // GetValueOrDefault with specified default
    public T GetValueOrDefault(T defaultValue)
    {
        return HasValue ? _value : defaultValue;
    }

    // Override ToString for display
    public override string ToString()
    {
        return HasValue ? _value.ToString() : "null";
    }
}

class Program
{
    static void Main()
    {
        MyNullable<int> i = new MyNullable<int>(); // No value assigned
        Console.WriteLine($"HasValue: {i.HasValue}");           // False
        //Console.WriteLine($"Value: {i.Value}"); // because no value will throw InvalidOperationException: No value present.
        Console.WriteLine($"GetValueOrDefault(): {i.GetValueOrDefault()}"); // 0 (default int)
        Console.WriteLine($"GetValueOrDefault(999): {i.GetValueOrDefault(999)}"); // 999
        Console.WriteLine($"ToString(): {i}"); // "null"

        Console.WriteLine();

        MyNullable<int> j = new MyNullable<int>(365); // Value assigned
        Console.WriteLine($"HasValue: {j.HasValue}");           // True
        Console.WriteLine($"Value: {j.Value}");                 // 365
        Console.WriteLine($"GetValueOrDefault(): {j.GetValueOrDefault()}"); // 365
        Console.WriteLine($"GetValueOrDefault(999): {j.GetValueOrDefault(999)}"); // 365
        Console.WriteLine($"ToString(): {j}"); // "365"
    }
}*/
