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
            int[] numbers = { 34, 8, 56, 31, 79, 150, 88, 7, 200, 47, 88, 20 };

            var query = from tal in numbers
                        where tal.ToString().Length == 2
                        orderby tal //descending // <-- opgave b
                        select tal;

            Console.WriteLine();
            foreach(int k in query) {
                Console.WriteLine(k);
            }
            Console.ReadLine();


        }
    }
}
