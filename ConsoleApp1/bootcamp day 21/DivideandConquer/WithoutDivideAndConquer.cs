using System;

namespace DivideandConquer
{
    public static class WithoutDivideAndConquer
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Versi TANPA Divide and Conquer ===\n");

            Console.WriteLine("Langkah 1: Program menghitung rata-rata bilangan [2, 4, 6, 8, 10].");
            Console.WriteLine("Langkah 2: Semua dilakukan dalam satu fungsi besar (tanpa pemisahan logika).");

            try
            {
                int[] numbers = { 2, 4, 6, 8, 10 };
                double result = ComputeAverage(numbers);

                Console.WriteLine($"\nHasil rata-rata (salah): {result}");
                Console.WriteLine("⚠️ BUG: Karena pembagian integer, hasilnya dibulatkan ke bawah.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi error: {ex.Message}");
            }
        }

        private static double ComputeAverage(int[] numbers)
        {
            int sum = 0;

            // Tidak ada pemisahan fungsi -> susah cari bug di sini
            foreach (var n in numbers)
            {
                sum += n;
                Console.WriteLine($"Menambahkan {n}, total sementara: {sum}");
            }

            Console.WriteLine($"\nMelakukan pembagian: {sum} / {numbers.Length}");
            return sum / numbers.Length; // bug: integer division
        }
    }
}

