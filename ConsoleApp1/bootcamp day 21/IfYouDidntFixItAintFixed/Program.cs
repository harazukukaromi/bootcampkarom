using System;

namespace IfYouDidntFixItAintFixed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("=== DEMO DEBUGGING PRINCIPLE ===");
            Console.WriteLine("If You Didn't Fix It, It Ain't Fixed");
            Console.WriteLine("----------------------------------\n");

            bool running = true;

            while (running)
            {
                Console.WriteLine("Pilih opsi:");
                Console.WriteLine("1. Jalankan contoh TANPA prinsip (Fake Fix)");
                Console.WriteLine("2. Jalankan contoh DENGAN prinsip (Real Fix)");
                Console.WriteLine("3. Keluar");
                Console.Write("\nMasukkan pilihan (1/2/3): ");

                string pilihan = Console.ReadLine();
                Console.WriteLine();

                switch (pilihan)
                {
                    case "1":
                        var tanpa = new TanpaPrinsip();
                        tanpa.Jalankan();
                        break;

                    case "2":
                        var dengan = new DenganPrinsip();
                        dengan.Jalankan();
                        break;

                    case "3":
                        running = false;
                        Console.WriteLine("Keluar dari program...");
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak valid. Coba lagi.\n");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nTekan Enter untuk kembali ke menu...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}


