/*using System;
using System.IO;
using System.Linq;
using System.Text;
//text encodings and Unicode
class EncodingDemo
{
    static void Main()
    {
        string originalText = "Hello, World! Café résumé";
        Console.WriteLine($"Original text: {originalText}");
        Console.WriteLine($"Character count: {originalText.Length}");

        Console.WriteLine("\n=== DIFFERENT ENCODING SCHEMES ===");

        // UTF-8: Variable-length encoding (1-4 bytes per character)
        byte[] utf8Bytes = Encoding.UTF8.GetBytes(originalText);
        Console.WriteLine($"UTF-8 byte count: {utf8Bytes.Length}");
        Console.WriteLine($"UTF-8 first 20 bytes: {BitConverter.ToString(utf8Bytes.Take(20).ToArray())}...");

        // UTF-16: Variable-length encoding (2 or 4 bytes per character)
        byte[] utf16Bytes = Encoding.Unicode.GetBytes(originalText);
        Console.WriteLine($"UTF-16 (Unicode) byte count: {utf16Bytes.Length}");
        Console.WriteLine($"UTF-16 first 20 bytes: {BitConverter.ToString(utf16Bytes.Take(20).ToArray())}...");

        // UTF-32: Fixed-length encoding (4 bytes per character)
        byte[] utf32Bytes = Encoding.UTF32.GetBytes(originalText);
        Console.WriteLine($"UTF-32 byte count: {utf32Bytes.Length}");

        // ASCII: Limited to first 128 Unicode characters
        Console.WriteLine("\n=== ASCII ENCODING (LIMITED) ===");
        string asciiText = "Hello World 123";
        byte[] asciiBytes = Encoding.ASCII.GetBytes(asciiText);
        Console.WriteLine($"ASCII text: '{asciiText}' -> {asciiBytes.Length} bytes");

        // ASCII can't handle extended characters
        try
        {
            byte[] asciiWithEmoji = Encoding.ASCII.GetBytes("Hello ");
            string asciiDecoded = Encoding.ASCII.GetString(asciiWithEmoji);
            Console.WriteLine($"ASCII with emoji: '{asciiDecoded}' (emoji lost!)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ASCII encoding issue: {ex.Message}");
        }

        Console.WriteLine("\n=== ENCODING/DECODING ROUNDTRIP ===");

        // Demonstrate encoding and decoding roundtrip
        string[] testEncodings = { "UTF-8", "UTF-16", "UTF-32" };
        Encoding[] encodings = { Encoding.UTF8, Encoding.Unicode, Encoding.UTF32 };

        for (int i = 0; i < testEncodings.Length; i++)
        {
            byte[] encoded = encodings[i].GetBytes(originalText);
            string decoded = encodings[i].GetString(encoded);
            bool isIdentical = originalText == decoded;
            Console.WriteLine($"{testEncodings[i]}: {encoded.Length} bytes, roundtrip successful: {isIdentical}");
        }

        Console.WriteLine("\n=== PRACTICAL FILE I/O EXAMPLE ===");

        string tempFile = Path.GetTempFileName();

        try
        {
            // Write with UTF-8 (default)
            File.WriteAllText(tempFile, originalText);
            var utf8FileInfo = new FileInfo(tempFile);
            Console.WriteLine($"UTF-8 file size: {utf8FileInfo.Length} bytes");

            // Write with UTF-16
            File.WriteAllText(tempFile, originalText, Encoding.Unicode);
            var utf16FileInfo = new FileInfo(tempFile);
            Console.WriteLine($"UTF-16 file size: {utf16FileInfo.Length} bytes");

            // Read back and verify
            string readBack = File.ReadAllText(tempFile, Encoding.Unicode);
            Console.WriteLine($"Read back successfully: {originalText == readBack}");
        }
        finally
        {
            File.Delete(tempFile);
        }
    }
}*/
