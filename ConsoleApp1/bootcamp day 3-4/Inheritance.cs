// See https://aka.ms/new-console-template for more information
using System;

class Inheritance
{
    //inheritance
    class Animal
    {
        public void Berbulu()
        {
            Console.WriteLine("Punya Bulu");
        }
    }
    class Dog : Animal
    {
        public void Gonggong()
        {
            Console.WriteLine("WangWang");
        }
    class Cat : Animal
    {
        public void Miaw()
        {
            Console.WriteLine("MiawMiaw");
        }
    }
        class Sheep : Animal
    {
        public void Mbeek()
        {
            Console.WriteLine("Mbeek");
        }
    }

        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Berbulu(); //inherited method
            dog.Gonggong();

            Cat cat = new Cat();
            cat.Berbulu(); //inherited method
            cat.Miaw();

            Sheep sheep = new Sheep();
            sheep.Berbulu(); //inherited method
            sheep.Mbeek();
        }
    }
}