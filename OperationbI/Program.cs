using System.Globalization;

namespace OperationbI;

internal static class Program
{
    static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

    class Number
    {
        readonly int _number;

        public Number(int number)
        {
            _number = number;
        }

        public override string ToString()
        {
            return _number.ToString(_ifp);
        }

        public static string operator +(Number someValue1, string someValue2)
        {
            try
            {
                var result = someValue1._number + int.Parse(someValue2);
                return result.ToString(_ifp);
            }
            catch (FormatException exception)
            {
                return exception.Message;
            }
        }
    }

    static void Main(string[] args)
    {
        int someValue1 = 10;
        int someValue2 = 5;

        string result = new Number(someValue1) + someValue2.ToString(_ifp);
        Console.WriteLine(result);
        Console.ReadKey();
    }
}