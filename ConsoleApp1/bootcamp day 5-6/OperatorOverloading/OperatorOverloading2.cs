/*using System;
//compound operators
class Note
{
    public int SemitonesFromA { get; private set; }

    public Note(int semitonesFromA)
    {
        SemitonesFromA = semitonesFromA;
    }

    // Overload + operator: Note + int
    public static Note operator +(Note note, int semitones)
    {
        return new Note(note.SemitonesFromA + semitones);
    }

    // Overload - operator: Note - int (to move down semitones)
    public static Note operator -(Note note, int semitones)
    {
        return new Note(note.SemitonesFromA - semitones);
    }

    // Overload - operator: Note - Note (interval calculation)
    public static int operator -(Note a, Note b)
    {
        return a.SemitonesFromA - b.SemitonesFromA;
    }

    // Overload * operator: Note * int (octaves)
    public static Note operator *(Note note, int octaves)
    {
        return new Note(note.SemitonesFromA + 12 * octaves);
    }
    */
    /* // Compound assignment operators: 
    // in c# can't allow directly += ,-=, and *= can make auto overloading
    // +=
    public static Note operator +=(Note note, int semitones)
    {
        return note + semitones;
    }

    // -=
    public static Note operator -=(Note note, int semitones)
    {
        return note - semitones;
    }

    // *=
    public static Note operator *=(Note note, int octaves)
    {
        return note * octaves;
    }*/
/*
}

class Program
{
    static void Main()
    {
        Note currentNote = new Note(5);  // F note
        Console.WriteLine($"Starting note: {currentNote.SemitonesFromA} semitones (F)");

        // Compound assignments
        currentNote = currentNote + 2;  // or currentNote += 2; but with the way C# works with reference types, we need assignment here
        Console.WriteLine($"After += 2: {currentNote.SemitonesFromA} semitones (G)");

        currentNote = currentNote - 1;  // or currentNote -= 1;
        Console.WriteLine($"After -= 1: {currentNote.SemitonesFromA} semitones (F#)");

        currentNote = currentNote * 2;  // or currentNote *= 2;
        Console.WriteLine($"After *= 2: {currentNote.SemitonesFromA} semitones (F# high octave)");

        Console.WriteLine();
    }
}*/
