/*using System;
using System.Collections;
// Custom Enumerable and Enumerator


class EnumarationAndIteration3
{
    static void Main()
    {
        DemonstrateCustomEnumerable();
    }

    static void DemonstrateCustomEnumerable()
    {
        var countdown = new CountdownSequence(10);
        Console.WriteLine("Custom countdown sequence from 10 to 1:");

        foreach (int number in countdown)
        {
            Console.WriteLine($"  Count: {number}");
        }

        Console.WriteLine();
    }
}

// Custom enumerable class
public class CountdownSequence : IEnumerable<int>
{
    private int _start;

    public CountdownSequence(int start)
    {
        _start = start;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new CountdownEnumerator(_start);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Custom enumerator class
public class CountdownEnumerator : IEnumerator<int>
{
    private int _current;
    private int _start;

    public CountdownEnumerator(int start)
    {
        _start = start + 1; // start at one higher so first MoveNext brings it to start
        _current = _start;
    }

    public int Current => _current;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _current--;
        return _current > 0;
    }

    public void Reset()
    {
        _current = _start;
    }

    public void Dispose()
    {
        // No unmanaged resources to clean up, so nothing here.
    }
}*/
