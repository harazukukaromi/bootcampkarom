/*using System;
using System.ComponentModel;
using System.Drawing; // For Color type
//Type Converters: Design-Time and XAML Conversions
class Program
{
    static void Main()
    {
        // Get the TypeConverter for Color
        TypeConverter cc = TypeDescriptor.GetConverter(typeof(Color));
        
        // Convert from color name string
        Color beige = (Color)cc.ConvertFromString("Beige");
        Console.WriteLine($"Beige color - ARGB: {beige.A}, {beige.R}, {beige.G}, {beige.B}");
        
        // Convert from hex string
        Color purple = (Color)cc.ConvertFromString("#800080");
        Console.WriteLine($"Purple color - ARGB: {purple.A}, {purple.R}, {purple.G}, {purple.B}");
        
        // Just to show the names again
        Console.WriteLine($"Beige.ToString(): {beige}");
        Console.WriteLine($"Purple.ToString(): {purple}");
    }
}*/
