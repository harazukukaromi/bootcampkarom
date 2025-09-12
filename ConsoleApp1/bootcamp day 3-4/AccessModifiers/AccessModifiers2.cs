/*using System;

namespace AccessModifiers2
{
    //Example by value
    class BaseClass
    {
        public int publicValue = 10;
        private int privateValue = 20;
        protected int protectedValue = 30;
        internal int internalValue = 40;
        protected internal int protectedInternalValue = 50;
        private protected int privateProtectedValue = 60;

        public void ShowAllValues()
        {
            Console.WriteLine("Inside BaseClass:");
            Console.WriteLine($"publicValue = {publicValue}");
            Console.WriteLine($"privateValue = {privateValue}");
            Console.WriteLine($"protectedValue = {protectedValue}");
            Console.WriteLine($"internalValue = {internalValue}");
            Console.WriteLine($"protectedInternalValue = {protectedInternalValue}");
            Console.WriteLine($"privateProtectedValue = {privateProtectedValue}");
            Console.WriteLine();
        }
    }

    class DerivedClass : BaseClass
    {
        public void ShowAccessibleValuesFromDerived()
        {
            Console.WriteLine("Inside DerivedClass:");
            Console.WriteLine($"publicValue = {publicValue}");
            //Console.WriteLine($"privateValue = {privateValue}"); //cant be access because protection level 
            Console.WriteLine($"protectedValue = {protectedValue}");
            Console.WriteLine($"internalValue = {internalValue}");
            Console.WriteLine($"protectedInternalValue = {protectedInternalValue}");
            Console.WriteLine($"privateProtectedValue = {privateProtectedValue}"); 
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            BaseClass baseObj = new BaseClass();
            baseObj.ShowAllValues();

            DerivedClass derivedObj = new DerivedClass();
            derivedObj.ShowAccessibleValuesFromDerived();

            Console.WriteLine("Access from Program (outside classes):");
            Console.WriteLine($"publicValue = {baseObj.publicValue}");
            // Console.WriteLine($"privateValue = {baseObj.privateValue}"); // can't be access
            // Console.WriteLine($"protectedValue = {baseObj.protectedValue}"); // can't be access also
            Console.WriteLine($"internalValue = {baseObj.internalValue}"); 
            Console.WriteLine($"protectedInternalValue = {baseObj.protectedInternalValue}"); // 
            // Console.WriteLine($"privateProtectedValue = {baseObj.privateProtectedValue}"); // can't be access
        }
    }
}*/
