using System;
using FactoryDemo.TanpaFactory;
using FactoryDemo.DenganFactory;


namespace FactoryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Demo Factory Method Calculator ===");
            Console.WriteLine("1. Tanpa Factory Method");
            Console.WriteLine("2. Dengan Factory Method");
            Console.Write("Pilih: ");
            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    TanpaFactoryMethod.Run();
                    break;
                case "2":
                    FactoryMethod.Run();
                    break;
                default:
                    Console.WriteLine("Pilihan tidak dikenal!");
                    break;
            }
        }
    }
}

