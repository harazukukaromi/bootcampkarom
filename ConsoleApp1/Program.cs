// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;

class ConsoleApp1
{
    static void Main()
    {
        //null operators
        string? nama = null;
        Console.WriteLine(nama ?? "nama tidak diisi");
        nama = "Hikaromi";
        Console.WriteLine(nama ?? "nama tidak diisi");

        string s1 = null;
        string s2 = s1 ?? "s1 is null";
        Console.WriteLine(s2);

        //null-coalescing assignment operator
        string? s3 = null;
        s3 ??= "s3 is null";
        Console.WriteLine(s3);

        //null-conditional operator
        string? s4 = null;
        int? length = s4?.Length;
        Console.WriteLine(length ?? 0);
        s4 = "Hikaromi";
        length = s4?.Length;
        Console.WriteLine(length ?? 0);
    }
}
