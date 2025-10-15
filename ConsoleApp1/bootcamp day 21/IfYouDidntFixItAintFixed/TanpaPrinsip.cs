using System;

namespace IfYouDidntFixItAintFixed
{
    public class TanpaPrinsip
    {
        public void Jalankan()
        {
            Console.WriteLine("--- Contoh Tanpa Prinsip ---");

            string input = null;

            try
            {
                // BUG: input null menyebabkan NullReferenceException
                Console.WriteLine("Panjang input: " + input.Length);
            }
            catch (Exception ex)
            {
                // Fake fix: error disembunyikan, tidak diperbaiki
                Console.WriteLine($"Terjadi error ({ex.Message}), tapi kita abaikan biar program tetap jalan ");
            }

            Console.WriteLine("Program lanjut, tapi bug masih tersembunyi...\n");
        }
    }
}

