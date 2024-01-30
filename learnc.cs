namespace myApp
{
    abstract class Shape {

    
    abstract void Types
    {
        console.WriteLine("there are may shapes in the world");
    }
    abstract class Polygon : Shape
    {
        console.WriteLine("there are may polygons in the world");
    }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
namespace myApp {
    class Program {
        static void string Convert(string rep, int srcBase, int destiBase) {
            string digits = "0123456789ABCDEF";
            bool sign = false;
            int value = 0;
            string result = "";
            if ((srcBase >= 2 && srcBase <= 16) && (destiBase >= 2 && destiBase <= 16)) {
                if (rep.StartsWith("-")) {
                    sign = true;
                    rep = rep.Substring(1);
                }
                if (rep.StartsWith("0b")) {
                    rep = rep.Substring(2);
                    if (srcBase != 2) return "Error (source base ambiguous)";
                }
                if (rep.StartsWith("0x")) {
                    rep = rep.Substring(2);
                    if (srcBase != 16) return "Error (source base ambiguous)";
                }
                if(rep.StartsWith("0")) {
                    rep = rep.Substring(1);
                    if (srcBase != 8) return "Error (source base ambiguous)";
                }
                foreach (char c in rep) {
                    int index = digits.IndexOf(Char.ToUpper(c));
                    if (index == -1 || index >= srcBase)
                        return "Error (Unrecognized digit)";
                    value = value * srcBase + index;
                }
                while (value > 0) {
                    int remainder = value % destiBase;
                    result = digits[remainder] + result;
                    value /= destiBase;
                }
            }
        }
    }
}