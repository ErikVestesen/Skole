using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "blueberry", "chimpanzee", "abacus",
                "banana", "apple", "cheese" };

            //Without Lambda
            var query = from k in words
                        group k by k into g
                        orderby g.Key
                        select new { ord = g.Key };
            foreach(var j in query) {
                Console.WriteLine(j);
            }

            //With Lambda
            var query1 = words.OrderBy(k => k).GroupBy(k=>k.ToString()).Select(k => new { ord = k.ToString() });
                



            foreach (var j in query1)
            {
                Console.WriteLine(j);
            }

            Console.ReadLine();
        }
    }
}
