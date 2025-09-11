// See https://aka.ms/new-console-template for more information
using System;

class Inheritance
{
    //inheritance
    class Animal
    {
        public void Nyokot()
        {
            Console.WriteLine("Nyokot.Aw");
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
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Nyokot(); //inherited method
            dog.Gonggong();

            Cat cat = new Cat();
            cat.Nyokot(); //inherited method
            cat.Miaw();
        }
    }
}