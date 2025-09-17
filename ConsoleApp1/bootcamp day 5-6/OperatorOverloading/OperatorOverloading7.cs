/*using System;
//Overloading Increment and Decrement
public class Counter
{
    public int Value { get; private set; }

    public Counter(int initialValue)
    {
        Value = initialValue;
    }

    // Pre- and post-increment
    public static Counter operator ++(Counter c)
    {
        // We assume pre-increment behavior: modify and return
        c.Value++;
        return c;
    }

    // Pre- and post-decrement
    public static Counter operator --(Counter c)
    {
        c.Value--;
        return c;
    }

    // Clone method to get a copy (needed to simulate post behavior manually)
    public Counter Clone()
    {
        return new Counter(this.Value);
    }
}

class Program
{
    static void Main()
    {
        Counter counter = new Counter(5);
        Console.WriteLine($"Initial counter: {counter.Value}");

        // Pre-increment
        Counter preInc = ++counter;
        Console.WriteLine($"After pre-increment (++counter): counter={counter.Value}, returned={preInc.Value}");

        // Post-increment (simulate manually)
        Counter postInc = counter.Clone();
        counter++;
        Console.WriteLine($"After post-increment (counter++): counter={counter.Value}, returned={postInc.Value}");

        // Pre-decrement
        Counter preDec = --counter;
        Console.WriteLine($"After pre-decrement (--counter): counter={counter.Value}, returned={preDec.Value}");

        // Post-decrement (simulate manually)
        Counter postDec = counter.Clone();
        counter--;
        Console.WriteLine($"After post-decrement (counter--): counter={counter.Value}, returned={postDec.Value}");
    }
}*/
