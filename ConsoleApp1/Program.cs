// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ConsoleApp1
{
    static void Main()
    {
        //string kalimat menghilangkan kondisi tidak perlukan
        Console.Write("input kalimat: ");
        string kalimat = Console.ReadLine();

        string HasilAwal = kalimat.ToLower();
        //HasilAwal = Regex.Replace(HasilAwal, @"[^\w\s]", ""); // menghilangkan tanda baca
        //HasilAwal = Regex.Replace(HasilAwal, @"\s+", ""); // menghilangkan spasi
        //HasilAwal = Regex.Replace(HasilAwal, @"\d", ""); // menghilangkan angka
        //HasilAwal = Regex.Replace(HasilAwal, @"[a-zA-Z]", ""); // menghilangkan huruf
        //HasilAwal = Regex.Replace(HasilAwal, @"[aAiIuUeEoO]", ""); // menghilangkan huruf vokal
        HasilAwal = Regex.Replace(HasilAwal, @"[BbRrIi]", ""); // menghilangkan huruf tertentu dalam konteks b, r, dan i
        Console.WriteLine("Kalimat akhir: " + HasilAwal);
    }
}

