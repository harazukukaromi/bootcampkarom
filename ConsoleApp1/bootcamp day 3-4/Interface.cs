using System;

class Interface
{
    public interface IAnimal
    {
        bool IsMammal();
        object CurrentAge{ get;}
        void Eat();
    }
    public class Kelinci : IAnimal
    {
        public int age;
        public Kelinci(int age)
        {
            this.age = age;
        }
        public bool IsMammal()
        {
            return false;
        }
        public object CurrentAge
        {
            get { return age; }
        }
        public void Eat()
        {
            Console.WriteLine("Kelinci is eating");
        }
    }
    static void Main(string[] args)
    {
        Kelinci kelinci = new Kelinci(5);
        Console.WriteLine($"Is kelinci mammal? {kelinci.IsMammal()}");
        Console.WriteLine($"Kelinci's age: {kelinci.CurrentAge}");
        kelinci.Eat();
    }
}