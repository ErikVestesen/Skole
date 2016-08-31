using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave6
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleG();
            StringG();
            DateTimeG();
        }

        static void DoubleG() {
            Console.WriteLine("-----------DOUBLE-----------");
            GrowableArray<double> doubleG = new GrowableArray<double>();
            doubleG[0] = 1.3;
            doubleG[4] = 4.3;
            doubleG[22] = 21.3;
            Console.WriteLine(doubleG[0]);
            Console.WriteLine(doubleG[4]);
            Console.WriteLine(doubleG[22]);
            Console.ReadLine();
        }

        static void StringG()
        {
            Console.WriteLine("-----------STRING-----------");
            GrowableArray<string> doubleG = new GrowableArray<string>();
            doubleG[0] = "1";
            doubleG[4] = "2";
            doubleG[22] = "3";
            Console.WriteLine(doubleG[0]);
            Console.WriteLine(doubleG[4]);
            Console.WriteLine(doubleG[22]);
            Console.ReadLine();
        }

        static void DateTimeG()
        {
            Console.WriteLine("-----------DATETIME-----------");
            DateTime d0 = new DateTime(1994, 12, 28);
            DateTime d1 = new DateTime(1995, 12, 28);
            DateTime d2 = new DateTime(1996, 12, 28);
            GrowableArray<DateTime> doubleG = new GrowableArray<DateTime>();
            doubleG[0] = d1;
            doubleG[4] = d1;
            doubleG[22] = d2;
            Console.WriteLine(doubleG[0]);
            Console.WriteLine(doubleG[4]);
            Console.WriteLine(doubleG[22]);
            Console.ReadLine();
        }


    }
}
