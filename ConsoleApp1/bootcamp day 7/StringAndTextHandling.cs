/*using System;
using System.Globalization;

//single unicode character
class Program
{
    static void Main()
    {
        // Basic character declarations
        char c = 'B';                // A simple character
        char newLine = '\n';         // A special control character (newline)
        char tab = '\t';             // Tab character
        char unicodeChar = '\u0042'; // Unicode for 'A' (U+0041)

        // Output using interpolated strings
        Console.WriteLine($"Basic character: {c}");
        Console.WriteLine($"Unicode character \\u0042: {unicodeChar}");
        Console.WriteLine($"Special characters exist: newline={newLine}, tab={tab}");

        // Character casing
        Console.WriteLine(char.ToUpper('c'));     // C
        Console.WriteLine(char.ToLower('C'));     // c

        // Character type checks
        Console.WriteLine(char.IsWhiteSpace('\t')); // True

        // Culture-invariant methods
        Console.WriteLine($"Culture-invariant uppercase 'i': {char.ToUpperInvariant('i')}");
        Console.WriteLine($"Regular uppercase 'i': {char.ToUpper('i')}");

        // Character categorization
        Console.WriteLine($"Is 'A' a letter? {char.IsLetter('A')}");
        Console.WriteLine($"Is '1' a letter? {char.IsLetter('1')}");
        Console.WriteLine($"Is '5' a digit? {char.IsDigit('5')}");
        Console.WriteLine($"Is 'B' a digit? {char.IsDigit('B')}");
        Console.WriteLine($"Is '!' punctuation? {char.IsPunctuation('!')}");
        Console.WriteLine($"Is '?' punctuation? {char.IsPunctuation('?')}");
        Console.WriteLine($"Is '2' punctuation? {char.IsPunctuation('2')}");
        Console.WriteLine($"Is 'M' punctuation? {char.IsPunctuation('M')}");
        Console.WriteLine($"Is ' ' whitespace? {char.IsWhiteSpace(' ')}");
        Console.WriteLine($"Is 'A' whitespace? {char.IsWhiteSpace('A')}");

        // Unicode categorization
        char testChar = 'A';
        Console.WriteLine($"Unicode category of '{testChar}': {CharUnicodeInfo.GetUnicodeCategory(testChar)}");

        Console.WriteLine();
    }
}*/
