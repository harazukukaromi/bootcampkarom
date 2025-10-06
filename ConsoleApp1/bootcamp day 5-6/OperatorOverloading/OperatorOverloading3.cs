/*using System;
//Checked and unchecked Operator
public struct Note
{
    private readonly int value;

    public Note(int value)
    {
        this.value = value;
    }

    public override string ToString() => $"Note({value})";

    // Unchecked + operator
    public static Note operator +(Note x, int semitones)
        => new Note(x.value + semitones);

    // Checked + operator
    public static Note operator checked +(Note x, int semitones)
        => checked(new Note(checked(x.value + semitones)));
}

class Program
{
    static void Main()
    {
        try
        {
            Note B = new Note(3);

            // This will trigger the 'checked' operator and cause an OverflowException
            Note other = checked(B + int.MaxValue);

            Console.WriteLine(other);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Overflow detected: " + ex.Message);
        }

        // Demonstrating unchecked version
        try
        {
            Note B = new Note(3);

            // This will use the unchecked version and wrap around
            Note result = B + int.MaxValue;

            Console.WriteLine("Unchecked result: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}*/
