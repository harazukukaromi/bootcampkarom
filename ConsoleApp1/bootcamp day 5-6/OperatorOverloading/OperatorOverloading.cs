/*using System;

//Basic Operator Overloading
class Note
{
    public int SemitonesFromA { get; private set; }

    public Note(int semitonesFromA)
    {
        SemitonesFromA = semitonesFromA;
    }

    // Overload + operator to transpose note by a number of semitones
    public static Note operator +(Note note, int semitones)
    {
        return new Note(note.SemitonesFromA + semitones);
    }

    // Overload - operator to calculate interval between notes
    public static int operator -(Note a, Note b)
    {
        return a.SemitonesFromA - b.SemitonesFromA;
    }

    // Overload * operator to raise note by octaves (each octave = 12 semitones)
    public static Note operator *(Note note, int octaves)
    {
        return new Note(note.SemitonesFromA + 12 * octaves);
    }
}

class Program
{
    static void Main()
    {
        BasicArithmeticOverloadingDemo();
    }

    static void BasicArithmeticOverloadingDemo()
    {

        // Create some musical notes
        Note noteA = new Note(0);    // A note (reference point)
        Note noteB = new Note(2);    // B note (2 semitones from A)
        Note noteC = new Note(3);    // C note (3 semitones from A)

        Console.WriteLine($"Note A: {noteA.SemitonesFromA} semitones from A");
        Console.WriteLine($"Note B: {noteB.SemitonesFromA} semitones from A");
        Console.WriteLine($"Note C: {noteC.SemitonesFromA} semitones from A");

        // Use overloaded + operator to transpose notes
        Note cSharp = noteC + 1;     // Add 1 semitone to C to get C#
        Note fSharp = noteA + 9;     // Add 9 semitones to A to get F#

        Console.WriteLine($"\nAfter transposition:");
        Console.WriteLine($"C + 1 semitone = C# ({cSharp.SemitonesFromA} semitones)");
        Console.WriteLine($"A + 9 semitones = F# ({fSharp.SemitonesFromA} semitones)");

        // Use overloaded - operator to find intervals
        int intervalBC = noteC - noteB;  // Distance between B and C
        Console.WriteLine($"\nInterval between B and C: {intervalBC} semitones");

        // Use overloaded * operator for octave multiplication
        Note highC = noteC * 2;      // C note, 2 octaves higher
        Console.WriteLine($"C note 2 octaves higher: {highC.SemitonesFromA} semitones");

        Console.WriteLine();
    }
}*/
