// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ConsoleApp1
{
    static void Main()
    {
        //array
        int[] angka = { 2, 4, 6, 8, 10 };
        Console.WriteLine("elemen angka:");
        foreach (int number in angka)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();
        //mengubah elemen array
        angka[1] = 5; //mengubah elemen array pada index ke 1
        angka[0] = 1; //mengubah elemen array pada index ke 0
        Console.WriteLine("elemen angka setelah diubah:");
        foreach (int number in angka)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();
        //menambahkan angka ke array
        int[] angkaBaru = new int[angka.Length + 1]; //membuat array baru dengan ukuran 1 lebih besar
        for (int i = 0; i < angka.Length; i++) //mengcopy elemen array lama ke array baru
        {
            angkaBaru[i] = angka[i];
        }
        angkaBaru[angkaBaru.Length - 1] = 12; //menambahkan angka 12 ke array
        angka = angkaBaru; //mengganti array lama dengan array baru
        Console.WriteLine("elemen angka setelah ditambahkan:");
        foreach (int number in angka)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();
        //menghapus angka dari array
        int[] angkaHapus = new int[angka.Length - 1]; //membuat array baru dengan ukuran 1 lebih kecil
        for (int i = 0, j = 0; i < angka.Length; i++) //mengcopy elemen array lama ke array baru kecuali elemen yang akan dihapus
        {
            if (angka[i] != 6) //menghapus angka 6
            {
                angkaHapus[j] = angka[i];
                j++;
            }
        }
        angka = angkaHapus; //mengganti array lama dengan array baru
        Console.WriteLine("elemen angka setelah dihapus:");
        foreach (int number in angka)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();
        //mengurutkan array
        Array.Sort(angka); //mengurutkan array secara ascending
        Console.WriteLine("elemen angka setelah diurutkan:");
        foreach (int number in angka)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();
        /*Array.Reverse(angka); //mengurutkan array secara descending
        Console.WriteLine("elemen angka setelah diurutkan secara descending:");
        foreach (int number in angka)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();*/
        //mencari elemen dalam array
        int cari = 0; //angka yang akan dicari
        int index = Array.IndexOf(angka, cari); //mencari index elemen
        if (index >= 0)
        {
            Console.WriteLine("angka " + cari + " ditemukan pada index ke " + index);
        }
        else
        {
            Console.WriteLine("angka " + cari + " tidak ditemukan");
        }
        Console.WriteLine();
        //menghitung jumlah elemen dalam array
        Console.WriteLine("jumlah elemen dalam array: " + angka.Length);
        Console.WriteLine();
        //menampilkan elemen index angka terakhir jika n tidak diketahui
        int lastelement = angka[^1]; //menggunakan indeks dari belakang
        Console.WriteLine("elemen index angka terakhir: " + lastelement);
        Console.WriteLine();
        //menampilkan elemen index angka kedua terakhir jika n tidak diketahui
        int secondlastelement = angka[^2]; //menggunakan indeks dari belakang
        Console.WriteLine("elemen index angka kedua terakhir: " + secondlastelement);
        Console.WriteLine();
        //menampilkan elemen index  tertentu
        int[] middleelement = angka[2..4]; //menampilkan index ke 2 hingga 4
        Console.WriteLine("elemen index angka dari baris tertentu: " + string.Join(", ", middleelement));
        Console.WriteLine(); 
        //menampilkan elemen index dari awal hingga index tertentu
        int[] startelement = angka[..2]; //menampilkan index ke 0 hingga
        Console.WriteLine("elemen index angka dari baris tertentu: " + string.Join(", ", startelement));
        Console.WriteLine(); 
        //menampilkan elemen index dari index tertentu hingga akhir
        int[] endelement = angka[2..]; //menampilkan index ke 2 hingga
        Console.WriteLine("elemen index angka dari baris tertentu: " + string.Join(", ", endelement));
        Console.WriteLine();     
    }
}

