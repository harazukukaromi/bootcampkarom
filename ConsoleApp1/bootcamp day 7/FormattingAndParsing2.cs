/*using System;
using System.Globalization;
// Format Providers: Granular Control Over Formatting and Parsing
class Program
{
    static void Main()
    {
        // --- Custom Currency Symbol ---
        NumberFormatInfo customCurrencyFormat = new NumberFormatInfo();
        customCurrencyFormat.CurrencySymbol = "$$";
        Console.WriteLine("Custom Currency: " + 5.ToString("C", customCurrencyFormat)); // $$5.00

        // --- Using UK Culture for Currency Formatting ---
        CultureInfo ukCulture = CultureInfo.GetCultureInfo("en-GB");
        Console.WriteLine("UK Currency: " + 5.ToString("C", ukCulture)); // £5.00

        // --- Date Formatting with Invariant Culture ---
        DateTime dt = new DateTime(2025, 9, 17);
        CultureInfo invariantCulture = CultureInfo.InvariantCulture;
        Console.WriteLine("Invariant Full DateTime: " + dt.ToString(invariantCulture));      // 17/09/2025 00:00:00
        Console.WriteLine("Invariant Short Date: " + dt.ToString("d", invariantCulture));     // 17/09/2025

        // --- Custom Number Format (Thousands separator as space) ---
        NumberFormatInfo customNumberFormat = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
        customNumberFormat.NumberGroupSeparator = " ";
        Console.WriteLine("Formatted Number: " + 12345.6789.ToString("N3", customNumberFormat)); // 12 345.679

        // --- Composite Formatting ---
        Console.WriteLine("Credit={0:C}", 500); // Uses current culture

        // --- Composite Formatting with Invariant Culture ---
        string formatted = string.Format(CultureInfo.InvariantCulture, "Value={0}", 3.14159);
        Console.WriteLine(formatted); // Value=3.14159

        // --- Parsing Negative Number with Parentheses ---
        int minusFour = int.Parse("(4)", NumberStyles.Integer | NumberStyles.AllowParentheses);
        Console.WriteLine("Parsed Negative: " + minusFour); // -4

        // --- Parsing Currency using UK Format ---
        decimal fivePointTwo = decimal.Parse("£7.20", NumberStyles.Currency, ukCulture);
        Console.WriteLine("Parsed UK Currency: " + fivePointTwo); // 7.20
    }
}*/
