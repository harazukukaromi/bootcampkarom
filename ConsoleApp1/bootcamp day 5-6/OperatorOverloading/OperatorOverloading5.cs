/*using System;
//Custom Implicit and Explicit Conversions

public struct Note
{
    private int value; // Semitones from A (A=0, A#=1, ..., G#=11, A=12)

    // Constructor: semitone distance from A4 (440Hz)
    public Note(int semitonesFromA)
    {
        value = semitonesFromA;
    }

    // Implicit conversion: Note -> double (frequency in Hz)
    public static implicit operator double(Note n)
    {
        return 440 * Math.Pow(2, n.value / 12.0);
    }

    // Explicit conversion: double -> Note (rounds to nearest semitone)
    public static explicit operator Note(double frequency)
    {
        double semitonesFromA = 12 * Math.Log(frequency / 440.0, 2);
        return new Note((int)Math.Round(semitonesFromA));
    }

    public override string ToString()
    {
        return $"Note({value} semitones from A4)";
    }
}

class Program
{
    static void Main()
    {
        // Explicit conversion: frequency (double) to Note
        double freq = 590.32;
        Note noteFromFreq = (Note)freq;
        Console.WriteLine($"Converted frequency {freq} Hz to {noteFromFreq}");

        // Implicit conversion: Note to frequency (double)
        Note n = new Note(3); // 3 semitones above A => C (roughly)
        double frequency = n; // Implicit conversion
        Console.WriteLine($"Note {n} corresponds to frequency {frequency:F2} Hz");

        // Round-trip conversion
        Note roundTrip = (Note)(double)n;
        Console.WriteLine($"After round-trip conversion: {roundTrip}");
    }
}*/
