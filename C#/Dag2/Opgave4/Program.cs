using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave4 {
    class Program {
        static void Main(string[] args)
        {
            Person p = new Person {CPR = "1234567891" };

            Console.WriteLine(p.CPR = "1234567890");
            Console.WriteLine(p.CPR = "123456789");
            Console.ReadLine();
        }
    }
}
