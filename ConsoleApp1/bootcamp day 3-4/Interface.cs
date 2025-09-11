using System;

class Interface
{

    // Interface dasar
    public interface IVehicle
    {
        void Start();
        void Stop();
    }

    // Interface yang memperluas IVehicle
    public interface ICar : IVehicle
    {
        void OpenTrunk();
    }
    // Implementasi dari interface ICar
    public class Sedan : ICar
    {
        public void Start()
        {
            Console.WriteLine("Car started.");
        }

        public void Stop()
        {
            Console.WriteLine("Car stopped.");
        }

        public void OpenTrunk()
        {
            Console.WriteLine("Trunk opened.");
        }
    }
    public static void Main(string[] args)
    {
        
        ICar myCar = new Sedan();
        myCar.Start();
        //myCar.Stop();
        //myCar.OpenTrunk();
    }
}
