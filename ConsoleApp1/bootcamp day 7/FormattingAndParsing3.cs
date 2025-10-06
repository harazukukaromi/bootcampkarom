/*using System;
using System.Globalization;
using System.Text;
//IFormatProvider and ICustomFormatter: Creating Custom Formatting Logic

public class WordyFormatProvider : IFormatProvider, ICustomFormatter
{
    private readonly IFormatProvider _parent;

    public WordyFormatProvider() : this(CultureInfo.CurrentCulture) { }

    public WordyFormatProvider(IFormatProvider parent)
    {
        _parent = parent ?? CultureInfo.CurrentCulture;
    }

    public object GetFormat(Type formatType)
    {
        if (formatType == typeof(ICustomFormatter)) return this;
        return null;
    }

    public string Format(string format, object arg, IFormatProvider formatProvider)
    {
        // If the argument is null or the format is not "W", defer to the parent provider
        if (arg == null || format != "W")
        {
            // Use the parent formatter to format the argument normally
            if (arg is IFormattable formattable)
                return formattable.ToString(format, _parent);
            else if (arg != null)
                return arg.ToString();
            else
                return string.Empty;
        }

        // Convert the argument to a string using InvariantCulture to get a consistent representation
        string digitList = string.Format(CultureInfo.InvariantCulture, "{0}", arg);
        StringBuilder result = new StringBuilder();

        foreach (char c in digitList)
        {
            switch (c)
            {
                case '-':
                    result.Append("minus ");
                    break;
                case '.':
                    result.Append("point ");
                    break;
                case '0':
                    result.Append("zero ");
                    break;
                case '1':
                    result.Append("one ");
                    break;
                case '2':
                    result.Append("two ");
                    break;
                case '3':
                    result.Append("three ");
                    break;
                case '4':
                    result.Append("four ");
                    break;
                case '5':
                    result.Append("five ");
                    break;
                case '6':
                    result.Append("six ");
                    break;
                case '7':
                    result.Append("seven ");
                    break;
                case '8':
                    result.Append("eight ");
                    break;
                case '9':
                    result.Append("nine ");
                    break;
                default:
                    // For any other character (like commas), just append it literally
                    result.Append(c);
                    result.Append(' ');
                    break;
            }
        }

        // Trim trailing space and return
        return result.ToString().TrimEnd();
    }
}

class Program
{
    static void Main()
    {
        double n = -135.49;
        IFormatProvider fp = new WordyFormatProvider();

        // Format output with currency using parent format provider and words using custom "W" format
        Console.WriteLine(string.Format(fp, "{0:C} in words is {0:W}", n));
    }
}*/
