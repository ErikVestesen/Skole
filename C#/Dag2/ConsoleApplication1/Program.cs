using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static double Max(params double[] a) {
            double i = 0;
            foreach(double x in a){
                if (x > i)
                    i = x;
            }
            return i;
        }

        public static string MaxString(out string longest, out int count, string input)
        {
            longest = "";
            string[] k = input.Split(' ');
            count = k.Length;
            foreach (string a in k) {
                if (a.Length > longest.Length)
                    longest = a;
            }
            return "Count: " + count + ", Longest: " + longest;
        }

        static void Main(string[] args) {
            double m1 = Max(28.5, 17.2);
            double m2 = Max(4.0, 10.8, 34.25, 2.0, 23.6);
            Console.WriteLine(m1 + " " + m2);
            Console.ReadLine();

            string tekst  = "Back to the Future";
            string longest = "";
            int count = 0;
            string res = MaxString(out longest, out count, tekst);

            Console.WriteLine(res+" ");
            Console.ReadLine();
        }
    }
}
