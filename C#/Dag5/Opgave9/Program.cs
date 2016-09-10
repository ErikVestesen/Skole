using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Opgave 9
            //Without Lambda
            int[] numbers = { 5, 14, 1, 33, 9, 8, 20, 26, 44 };

            var tal = from k in numbers
                      group k by k into g
                      select new {tal = g.Key % 5 };
            foreach (var j in tal)
            {
                Console.WriteLine(j);
            }

            //With Lambda
            var tal2 = numbers
                .Select(x => x)
                .GroupBy(x => (x));

            foreach (var j in tal2)
            {
                Console.WriteLine(j);
            }

            Console.ReadLine();
        }
    }
}
