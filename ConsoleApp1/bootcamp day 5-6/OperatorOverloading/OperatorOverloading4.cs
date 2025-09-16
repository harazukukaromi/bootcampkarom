/*using System;
// equality operators
public struct Note : IEquatable<Note>
{
    public int SemitonesFromA { get; }

    public Note(int semitonesFromA)
    {
        SemitonesFromA = semitonesFromA;
    }

    // Override Equals
    public override bool Equals(object obj)
        => obj is Note other && Equals(other);

    public bool Equals(Note other)
        => this.SemitonesFromA == other.SemitonesFromA;

    // Override GetHashCode
    public override int GetHashCode()
        => SemitonesFromA.GetHashCode();

    // Overload == and !=
    public static bool operator ==(Note left, Note right)
        => left.Equals(right);

    public static bool operator !=(Note left, Note right)
        => !left.Equals(right);

    public override string ToString() => $"Note({SemitonesFromA})";
}
class Program
{
    static void Main()
    {
        Note note1 = new Note(5);   // F note
        Note note2 = new Note(5);   // Another F note
        Note note3 = new Note(7);   // G note

        Console.WriteLine($"Note1: {note1.SemitonesFromA} semitones");
        Console.WriteLine($"Note2: {note2.SemitonesFromA} semitones");
        Console.WriteLine($"Note3: {note3.SemitonesFromA} semitones");

        // Test equality operators
        Console.WriteLine($"\nEquality tests:");
        Console.WriteLine($"note1 == note2: {note1 == note2}");  // True
        Console.WriteLine($"note1 == note3: {note1 == note3}");  // False
        Console.WriteLine($"note1 != note3: {note1 != note3}");  // True

        // Test Equals method (overridden)
        Console.WriteLine($"\nEquals method tests:");
        Console.WriteLine($"note1.Equals(note2): {note1.Equals(note2)}");
        Console.WriteLine($"note1.Equals(note3): {note1.Equals(note3)}");

        // Test GetHashCode (same values should have same hash)
        Console.WriteLine($"\nHash codes:");
        Console.WriteLine($"note1.GetHashCode(): {note1.GetHashCode()}");
        Console.WriteLine($"note2.GetHashCode(): {note2.GetHashCode()}");
        Console.WriteLine($"note3.GetHashCode(): {note3.GetHashCode()}");

        Console.WriteLine();
    }
}*/

