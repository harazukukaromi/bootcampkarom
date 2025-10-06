/*using System;

class Program
{
    static void Main()
    {
        double original = 4.5;

        Console.WriteLine("Bytes of double 4.5:");
        byte[] bytes = BitConverter.GetBytes(original);
        foreach (byte b in bytes)
        {
            Console.Write(b + " ");
        }
        Console.WriteLine();

        // Example bytes for 4.5 in little-endian order
        byte[] exampleBytes = new byte[] { 0, 0, 0, 0, 0, 0, 18, 64 };

        double restoredDouble = BitConverter.ToDouble(exampleBytes, 0);
        Console.WriteLine($"Restored double from bytes: {restoredDouble}");
    }
}*/
