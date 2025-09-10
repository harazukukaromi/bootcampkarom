// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
class ConsoleApp1
{
    static void Main()
    {
        Console.WriteLine("Masukkan sebuah kata atau kalimat:");
        string input = Console.ReadLine();

        // Uppercase
        string upper = input.ToUpper();
        Console.WriteLine($"Uppercase: {upper}");

        // Lowercase
        string lower = input.ToLower();
        Console.WriteLine($"Lowercase: {lower}");

        // PascalCase
        string pascal = ToPascalCase(input);
        Console.WriteLine($"PascalCase: {pascal}");

        // camelCase
        string camel = ToCamelCase(input);
        Console.WriteLine($"camelCase: {camel}");
    }
    static string ToPascalCase(string text)
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        string[] words = text.Split(new[] { ' ', '_', '-' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = ti.ToTitleCase(words[i].ToLower());
        }
        return string.Join("", words);
    }
    static string ToCamelCase(string text)
    {
        string pascal = ToPascalCase(text);
        if (string.IsNullOrEmpty(pascal))
            return pascal;
        return char.ToLower(pascal[0]) + pascal.Substring(1);
        // Penjumlahan integer dan string
        Console.WriteLine("\nMasukkan angka pertama (integer):");
        int angka1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Masukkan angka kedua (string):");
        string angka2Str = Console.ReadLine();
        int angka2 = int.Parse(angka2Str);

        int hasil = angka1 + angka2;
        Console.WriteLine($"Hasil penjumlahan: {angka1} + {angka2} = {hasil}");
    }
}

