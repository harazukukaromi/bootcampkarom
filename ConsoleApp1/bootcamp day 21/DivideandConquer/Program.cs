using System;

namespace DivideandConquer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("==========================================");
                Console.WriteLine("      Divide and Conquer Debugging Demo   ");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Jalankan versi TANPA Divide and Conquer");
                Console.WriteLine("2. Jalankan versi DENGAN Divide and Conquer");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih opsi (1-3): ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        WithoutDivideAndConquer.Run();
                        break;
                    case "2":
                        WithDivideAndConquer.Run();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid!");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nTekan Enter untuk kembali ke menu...");
                    Console.ReadLine();
                }
            }
        }
    }
}

