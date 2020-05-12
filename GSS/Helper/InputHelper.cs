using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GSS.Helper
{
    public class InputHelper
    {
        public static double ParseDouble(string s)
        {
            string dec_separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (dec_separator == ",")
                s = s.Replace(".", ",");
            else if (dec_separator == ".")
                s = s.Replace(",", ".");

            return double.Parse(s);
        }
        public static bool TryParseDouble(string s, out double result)
        {
            string dec_separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (dec_separator == ",")
                s = s.Replace(".", ",");
            else if (dec_separator == ".")
                s = s.Replace(",", ".");

            return double.TryParse(s, out result);
        }

        public static decimal ParseDecimal(string s)
        {
            string dec_separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (dec_separator == ",")
                s = s.Replace(".", ",");
            else if (dec_separator == ".")
                s = s.Replace(",", ".");

            return decimal.Parse(s);
        }
        public static bool TryParseDecimal(string s, out decimal result)
        {
            string dec_separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (dec_separator == ",")
                s = s.Replace(".", ",");
            else if (dec_separator == ".")
                s = s.Replace(",", ".");

            return decimal.TryParse(s, out result);
        }
    }
}
