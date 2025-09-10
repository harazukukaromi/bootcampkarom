// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ConsoleApp1
{
    static void Main()
    {
        //string kalimat
        Console.Write("input kalimat: ");
        string kalimat = Console.ReadLine();

        string HasilAwal = kalimat.ToLower();
        HasilAwal = Regex.Replace(HasilAwal, @"[^\w\s]", "");
        HasilAwal = Regex.Replace(HasilAwal, @"\s+", "");
        HasilAwal = Regex.Replace(HasilAwal, @"\d", "");
        Console.WriteLine("Kalimat akhir: " + HasilAwal);
    }
}

