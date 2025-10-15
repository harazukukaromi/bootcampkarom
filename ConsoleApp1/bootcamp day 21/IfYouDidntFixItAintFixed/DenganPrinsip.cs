using System;

namespace IfYouDidntFixItAintFixed
{
    public class DenganPrinsip
    {
        public void Jalankan()
        {
            Console.WriteLine("--- Contoh Dengan Prinsip ---");

            string input = null;

            // Perbaikan nyata: tangani kasus null sebelum digunakan
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input kosong atau null. Menggunakan nilai default.");
                input = "DefaultInput";
            }

            Console.WriteLine("Panjang input: " + input.Length);
            Console.WriteLine("Bug benar-benar diperbaiki \n");
        }
    }
}

