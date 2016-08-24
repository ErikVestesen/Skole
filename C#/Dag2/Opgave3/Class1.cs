using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMath
{
    public static class MathExtension
    {
        public static int factorial(this int x)
        {
            if (x <= 1)
                return 1;
            else
                return x * factorial(x - 1);
        }

        public static string FixedDigits(this string str, int n)
        {
            if (str.Contains('-'))
                return "-" + str.Substring(1, str.Length - 1).PadLeft(n, '0');
            return str.PadLeft(n, '0');
        }
    }
  }

