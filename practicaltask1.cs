using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(Convert("1010000001J011101", 2, 16));
        Console.WriteLine(Convert("92312", 8, 8));
        Console.WriteLine(Convert("072312", 8, 8));
        Console.WriteLine(Convert("0b101", 2, 10));
        Console.WriteLine(Convert("59", 10, 2));
        Console.WriteLine(Convert("0xA", 10, 8));
        Console.WriteLine(Convert("-728", 10, 8));
    }

    static string Convert(string rep, int srcBase, int destiBase)
    {
        string digits = "0123456789ABCDEF";
        bool sign = false;
        int value = 0;

        string result = "";

        if ((srcBase >= 2 && srcBase <= 16) && (destiBase >= 2 && destiBase <= 16))
        {
            if (rep.StartsWith("-"))
            {
                sign = true;
                rep = rep.Substring(1);
            }
            if (rep.StartsWith("0b"))
            {
                rep = rep.Substring(2);
                if (srcBase != 2) return "Error (source base ambiguous)";
            }
            if (rep.StartsWith("0x"))
            {
                rep = rep.Substring(2);
                if (srcBase != 16) return "Error (source base ambiguous)";
            }
            if(rep.StartsWith("0"))
            {
                rep = rep.Substring(1);
                if (srcBase != 8) return "Error (source base ambiguous)";
            }

            foreach (char c in rep)
            {
                int index = digits.IndexOf(Char.ToUpper(c));
                if (index == -1 || index >= srcBase)
                    return "Error (Unrecognized digit)";
                value = value * srcBase + index;
            }

            while (value > 0)
            {
                int remainder = value % destiBase;
                result = digits[remainder] + result;
                value /= destiBase;
            }

            if (sign)
            {
                result = "-" + result;
            }

        }
        else
        {
            return "Error (Base out of range)";
        }
        return result;
    }
}
