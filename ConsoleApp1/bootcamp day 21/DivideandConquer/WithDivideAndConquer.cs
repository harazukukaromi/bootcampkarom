using System;

namespace DivideandConquer
{
    public static class WithDivideAndConquer
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Versi DENGAN Divide and Conquer ===\n");

            Console.WriteLine("Langkah 1: Pisahkan perhitungan jumlah dan pembagian.");
            Console.WriteLine("Langkah 2: Uji tiap bagian secara independen agar mudah menemukan bug.\n");

            try
            {
                int[] numbers = { 2, 4, 6, 8, 10 };

                double total = CalculateSum(numbers);
                Console.WriteLine($"\n✔️ Tahap 1 Berhasil: Total = {total}");

                double avg = Divide(total, numbers.Length);
                Console.WriteLine($"✔️ Tahap 2 Berhasil: Rata-rata = {avg}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi error: {ex.Message}");
            }
        }

        // Tahap 1: Pisahkan logika penjumlahan
        private static double CalculateSum(int[] numbers)
        {
            double sum = 0;
            foreach (var n in numbers)
            {
                sum += n;
                Console.WriteLine($"Menambahkan {n}, total sementara: {sum}");
            }
            return sum;
        }

        // Tahap 2: Pisahkan pembagian agar tipe data bisa dikontrol
        private static double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Penyebut tidak boleh nol!");

            Console.WriteLine($"Melakukan pembagian: {a} / {b}");
            return a / b; // hasil presisi
        }
    }
}

