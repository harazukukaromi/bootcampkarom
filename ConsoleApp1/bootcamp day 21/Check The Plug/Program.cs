using System;
using System.IO;

namespace CheckThePlugSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Check The Plug Debugging - Simple Version";

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("   ⚡ CHECK THE PLUG - SIMPLE DEMO ");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Jalankan TANPA Check The Plug");
                Console.WriteLine("2. Jalankan DENGAN Check The Plug");
                Console.WriteLine("3. Hapus file data.txt (reset latihan)");
                Console.WriteLine("0. Keluar");
                Console.Write("Pilih (0-3): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RunWithoutCheck();
                        break;
                    case "2":
                        RunWithCheck();
                        break;
                    case "3":
                        DeleteFile();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("❌ Pilihan tidak dikenal.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nTekan tombol apa saja untuk lanjut...");
                    Console.ReadKey();
                }
            }
        }

        // 🔴 Tanpa Check The Plug
        static void RunWithoutCheck()
        {
            Console.Clear();
            Console.WriteLine("=== TANPA CHECK THE PLUG ===");
            Console.WriteLine("Langsung mencoba membaca file tanpa cek dulu.\n");

            string filePath = "data.txt";

            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine("📄 Isi file:");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERROR: {ex.Message}");
                Console.WriteLine("\n➡️ Karena kita tidak melakukan 'Check The Plug', " +
                                  "error terjadi hanya karena file tidak ada.");
            }
        }

        // 🟢 Dengan Check The Plug
        static void RunWithCheck()
        {
            Console.Clear();
            Console.WriteLine("=== DENGAN CHECK THE PLUG ===");
            Console.WriteLine("Memastikan file tersedia sebelum dibaca.\n");

            string filePath = "data.txt";

            // ✅ Check The Plug: cek file dulu
            if (!File.Exists(filePath))
            {
                Console.WriteLine("⚠️ File tidak ditemukan. Membuat file baru...");
                File.WriteAllText(filePath, "Halo! Ini isi file baru untuk latihan Check The Plug.");
            }

            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine("📄 Isi file:");
                Console.WriteLine(content);
                Console.WriteLine("\n🎯 Dengan Check The Plug, kita menghindari error sederhana.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Gagal membaca file: {ex.Message}");
            }
        }

        // 🧹 Fitur tambahan: Hapus file data.txt
        static void DeleteFile()
        {
            Console.Clear();
            Console.WriteLine("=== HAPUS FILE DATA.TXT ===\n");

            string filePath = "data.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("🗑️ File data.txt berhasil dihapus!");
                }
                else
                {
                    Console.WriteLine("⚠️ File data.txt tidak ditemukan. Tidak ada yang perlu dihapus.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Gagal menghapus file: {ex.Message}");
            }
        }
    }
}


