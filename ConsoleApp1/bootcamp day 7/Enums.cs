/*using System;
//basic Enums
enum Nut { Walnut, Hazelnut, Macadamia }
enum Size { Small, Medium, Large }

class Program
{
    static void Display(Enum value) // Accepts any enum type
    {
        Console.WriteLine(value.GetType().Name + "." + value.ToString());
    }

    static void Main()
    {
        Display(Nut.Macadamia); // Output: Nut.Macadamia
        Display(Size.Large);    // Output: Size.Large
        //Display(Nut.Peanut);  // can't output because not in enums
        //Display(Size.small);  // can't output because not in enums even only Uppercase or etc.
        //Display(size.small);  // can't output because not have same name in the enums
        Display(Size.Small);    // Output: Size.Small
    }
}*/
